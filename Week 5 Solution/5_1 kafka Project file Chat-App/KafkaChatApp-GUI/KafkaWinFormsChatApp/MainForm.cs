using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Confluent.Kafka;

namespace KafkaWinFormsChatApp
{
    public partial class MainForm : Form
    {
        private const string BootstrapServers = "localhost:9092";
        private const string TopicName = "chat-topic";
        
        // UI Controls
        private TextBox txtUsername;
        private TextBox txtMessage;
        private RichTextBox rtbChatHistory;
        private Button btnSend;
        private Button btnConnect;
        private Button btnDisconnect;
        private Label lblStatus;
        private Label lblUsername;
        private Label lblInstructions;
        
        // Kafka components
        private IProducer<string, string> _producer;
        private IConsumer<string, string> _consumer;
        private CancellationTokenSource _cancellationTokenSource;
        private Task _consumerTask;
        private bool _isConnected = false;
        private string _groupId;

        public MainForm()
        {
            InitializeComponent();
            _groupId = $"chat-group-{Environment.MachineName}-{DateTime.Now.Ticks}";
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            
            // Form properties
            this.Text = "Kafka Chat Application - Windows Forms";
            this.Size = new Size(700, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(600, 400);

            // Instructions label
            lblInstructions = new Label
            {
                Text = "Enter your username and click Connect to join the chat",
                Location = new Point(10, 10),
                Size = new Size(400, 20),
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = Color.DarkBlue
            };
            this.Controls.Add(lblInstructions);

            // Username label
            lblUsername = new Label
            {
                Text = "Username:",
                Location = new Point(10, 40),
                Size = new Size(80, 23),
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            this.Controls.Add(lblUsername);

            // Username textbox
            txtUsername = new TextBox
            {
                Location = new Point(100, 37),
                Size = new Size(150, 23),
                Text = Environment.UserName,
                Font = new Font("Segoe UI", 9)
            };
            this.Controls.Add(txtUsername);

            // Connect button
            btnConnect = new Button
            {
                Text = "Connect",
                Location = new Point(260, 36),
                Size = new Size(80, 25),
                Font = new Font("Segoe UI", 9),
                BackColor = Color.LightGreen
            };
            btnConnect.Click += BtnConnect_Click;
            this.Controls.Add(btnConnect);

            // Disconnect button
            btnDisconnect = new Button
            {
                Text = "Disconnect",
                Location = new Point(350, 36),
                Size = new Size(80, 25),
                Enabled = false,
                Font = new Font("Segoe UI", 9),
                BackColor = Color.LightCoral
            };
            btnDisconnect.Click += BtnDisconnect_Click;
            this.Controls.Add(btnDisconnect);

            // Status label
            lblStatus = new Label
            {
                Text = "Status: Disconnected",
                Location = new Point(440, 40),
                Size = new Size(200, 23),
                ForeColor = Color.Red,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            this.Controls.Add(lblStatus);

            // Chat history
            rtbChatHistory = new RichTextBox
            {
                Location = new Point(10, 70),
                Size = new Size(660, 350),
                ReadOnly = true,
                BackColor = Color.White,
                ScrollBars = RichTextBoxScrollBars.Vertical,
                Font = new Font("Consolas", 9),
                BorderStyle = BorderStyle.Fixed3D
            };
            this.Controls.Add(rtbChatHistory);

            // Message input label
            var lblMessage = new Label
            {
                Text = "Message:",
                Location = new Point(10, 435),
                Size = new Size(60, 23),
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            this.Controls.Add(lblMessage);

            // Message input textbox
            txtMessage = new TextBox
            {
                Location = new Point(80, 432),
                Size = new Size(500, 23),
                Enabled = false,
                Font = new Font("Segoe UI", 9)
            };
            txtMessage.KeyPress += TxtMessage_KeyPress;
            this.Controls.Add(txtMessage);

            // Send button
            btnSend = new Button
            {
                Text = "Send",
                Location = new Point(590, 431),
                Size = new Size(80, 25),
                Enabled = false,
                Font = new Font("Segoe UI", 9),
                BackColor = Color.LightBlue
            };
            btnSend.Click += BtnSend_Click;
            this.Controls.Add(btnSend);

            // Form event handlers
            this.FormClosing += MainForm_FormClosing;
            this.Load += MainForm_Load;
            
            this.ResumeLayout();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AppendToChatHistory("System", "Welcome to Kafka Chat! Enter your username and click Connect.", Color.Blue);
            txtUsername.Focus();
        }

        private async void BtnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter a username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            try
            {
                btnConnect.Enabled = false;
                btnConnect.Text = "Connecting...";
                
                await ConnectToKafka();
                UpdateUIConnectionState(true);
                AppendToChatHistory("System", $"Connected to chat as '{txtUsername.Text}'", Color.Green);
                txtMessage.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to connect to Kafka:\n{ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnConnect.Enabled = true;
                btnConnect.Text = "Connect";
            }
        }

        private async void BtnDisconnect_Click(object sender, EventArgs e)
        {
            btnDisconnect.Enabled = false;
            btnDisconnect.Text = "Disconnecting...";
            
            await DisconnectFromKafka();
            UpdateUIConnectionState(false);
            AppendToChatHistory("System", "Disconnected from chat", Color.Red);
            
            btnDisconnect.Text = "Disconnect";
        }

        private async Task ConnectToKafka()
        {
            // Initialize producer
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = BootstrapServers,
                ClientId = $"chat-producer-{txtUsername.Text}",
                MessageTimeoutMs = 10000
            };
            _producer = new ProducerBuilder<string, string>(producerConfig).Build();

            // Initialize consumer
            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = BootstrapServers,
                GroupId = _groupId,
                AutoOffsetReset = AutoOffsetReset.Latest,
                EnableAutoCommit = true,
                ClientId = $"chat-consumer-{txtUsername.Text}",
                SessionTimeoutMs = 10000
            };
            _consumer = new ConsumerBuilder<string, string>(consumerConfig).Build();
            _consumer.Subscribe(TopicName);

            // Start consuming messages
            _cancellationTokenSource = new CancellationTokenSource();
            _consumerTask = Task.Run(() => ConsumeMessages(_cancellationTokenSource.Token));

            _isConnected = true;
        }

        private async Task DisconnectFromKafka()
        {
            _isConnected = false;

            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
                if (_consumerTask != null)
                {
                    try
                    {
                        await _consumerTask;
                    }
                    catch (OperationCanceledException)
                    {
                        // Expected
                    }
                }
            }

            _consumer?.Close();
            _consumer?.Dispose();
            _producer?.Dispose();
        }

        private void ConsumeMessages(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        var result = _consumer.Consume(TimeSpan.FromMilliseconds(1000));
                        if (result != null && !result.IsPartitionEOF)
                        {
                            var parts = result.Message.Value.Split(new[] { ": " }, 2, StringSplitOptions.None);
                            if (parts.Length == 2)
                            {
                                var username = parts[0];
                                var message = parts[1];
                                
                                // Don't display our own messages (they're already shown when sent)
                                if (username != txtUsername.Text)
                                {
                                    this.Invoke(new Action(() =>
                                    {
                                        AppendToChatHistory(username, message, Color.Blue);
                                    }));
                                }
                            }
                        }
                    }
                    catch (ConsumeException ex)
                    {
                        if (!cancellationToken.IsCancellationRequested)
                        {
                            this.Invoke(new Action(() =>
                            {
                                AppendToChatHistory("System", $"Error receiving message: {ex.Error.Reason}", Color.Red);
                            }));
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Expected when cancellation is requested
            }
        }

        private async void BtnSend_Click(object sender, EventArgs e)
        {
            await SendMessage();
        }

        private void TxtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                Task.Run(async () => await SendMessage());
            }
        }

        private async Task SendMessage()
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text) || !_isConnected)
                return;

            var messageText = txtMessage.Text;
            
            try
            {
                var kafkaMessage = new Message<string, string>
                {
                    Key = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Value = $"{txtUsername.Text}: {messageText}"
                };

                await _producer.ProduceAsync(TopicName, kafkaMessage);
                
                // Display our own message immediately
                this.Invoke(new Action(() =>
                {
                    AppendToChatHistory(txtUsername.Text, messageText, Color.DarkGreen);
                    txtMessage.Clear();
                }));
            }
            catch (ProduceException<string, string> ex)
            {
                this.Invoke(new Action(() =>
                {
                    AppendToChatHistory("System", $"Failed to send message: {ex.Error.Reason}", Color.Red);
                }));
            }
        }

        private void AppendToChatHistory(string username, string message, Color color)
        {
            var timestamp = DateTime.Now.ToString("HH:mm:ss");
            
            // Move to end
            rtbChatHistory.SelectionStart = rtbChatHistory.TextLength;
            rtbChatHistory.SelectionLength = 0;
            
            // Add timestamp
            rtbChatHistory.SelectionColor = Color.Gray;
            rtbChatHistory.AppendText($"[{timestamp}] ");
            
            // Add username
            rtbChatHistory.SelectionColor = color;
            rtbChatHistory.SelectionFont = new Font(rtbChatHistory.Font, FontStyle.Bold);
            rtbChatHistory.AppendText($"{username}: ");
            
            // Add message
            rtbChatHistory.SelectionColor = Color.Black;
            rtbChatHistory.SelectionFont = new Font(rtbChatHistory.Font, FontStyle.Regular);
            rtbChatHistory.AppendText($"{message}\n");
            
            // Reset formatting
            rtbChatHistory.SelectionColor = rtbChatHistory.ForeColor;
            rtbChatHistory.SelectionFont = rtbChatHistory.Font;
            
            // Auto-scroll
            rtbChatHistory.ScrollToCaret();
        }

        private void UpdateUIConnectionState(bool connected)
        {
            _isConnected = connected;
            btnConnect.Enabled = !connected;
            btnConnect.Text = "Connect";
            btnDisconnect.Enabled = connected;
            txtMessage.Enabled = connected;
            btnSend.Enabled = connected;
            txtUsername.Enabled = !connected;
            
            lblStatus.Text = connected ? "Status: Connected" : "Status: Disconnected";
            lblStatus.ForeColor = connected ? Color.Green : Color.Red;
            
            if (connected)
            {
                lblInstructions.Text = $"Connected as '{txtUsername.Text}' - Type messages below";
                lblInstructions.ForeColor = Color.DarkGreen;
            }
            else
            {
                lblInstructions.Text = "Enter your username and click Connect to join the chat";
                lblInstructions.ForeColor = Color.DarkBlue;
            }
        }

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isConnected)
            {
                await DisconnectFromKafka();
            }
        }
    }
}