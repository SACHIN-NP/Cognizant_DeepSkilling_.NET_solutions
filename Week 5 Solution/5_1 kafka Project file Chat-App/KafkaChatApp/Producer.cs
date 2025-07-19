using Confluent.Kafka;
using System;
using System.Threading.Tasks;

namespace KafkaChatApp
{
    public class ChatProducer
    {
        private readonly string _bootstrapServers;
        private readonly string _topicName;

        public ChatProducer(string bootstrapServers, string topicName)
        {
            _bootstrapServers = bootstrapServers;
            _topicName = topicName;
        }

        public async Task StartProducing()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = _bootstrapServers,
                ClientId = "chat-producer"
            };

            using var producer = new ProducerBuilder<string, string>(config).Build();

            Console.WriteLine("Chat Producer Started. Type messages (type 'exit' to quit):");
            Console.WriteLine("Format: username: message");

            string input;
            while ((input = Console.ReadLine()) != "exit")
            {
                if (string.IsNullOrWhiteSpace(input)) continue;

                try
                {
                    var message = new Message<string, string>
                    {
                        Key = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Value = input
                    };

                    var result = await producer.ProduceAsync(_topicName, message);
                    Console.WriteLine($"✓ Message sent: {result.TopicPartitionOffset}");
                }
                catch (ProduceException<string, string> ex)
                {
                    Console.WriteLine($"✗ Failed to send message: {ex.Error.Reason}");
                }
            }
        }
    }
}