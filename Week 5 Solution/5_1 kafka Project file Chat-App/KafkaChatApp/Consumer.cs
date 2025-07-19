using Confluent.Kafka;
using System;
using System.Threading;

namespace KafkaChatApp
{
    public class ChatConsumer
    {
        private readonly string _bootstrapServers;
        private readonly string _topicName;
        private readonly string _groupId;

        public ChatConsumer(string bootstrapServers, string topicName, string groupId)
        {
            _bootstrapServers = bootstrapServers;
            _topicName = topicName;
            _groupId = groupId;
        }

        public void StartConsuming()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = _bootstrapServers,
                GroupId = _groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = true,
                ClientId = "chat-consumer"
            };

            using var consumer = new ConsumerBuilder<string, string>(config).Build();
            consumer.Subscribe(_topicName);

            Console.WriteLine($"Chat Consumer Started. Listening to topic: {_topicName}");
            Console.WriteLine("Press Ctrl+C to stop...");

            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
            };

            try
            {
                while (!cts.Token.IsCancellationRequested)
                {
                    try
                    {
                        var result = consumer.Consume(cts.Token);
                        if (result != null)
                        {
                            Console.WriteLine($"[{result.Message.Key}] {result.Message.Value}");
                        }
                    }
                    catch (ConsumeException ex)
                    {
                        Console.WriteLine($"✗ Consume error: {ex.Error.Reason}");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Shutting down consumer...");
            }
            finally
            {
                consumer.Close();
            }
        }
    }
}