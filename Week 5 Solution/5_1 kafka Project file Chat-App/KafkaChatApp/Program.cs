using System;
using System.Threading.Tasks;

namespace KafkaChatApp
{
    class Program
    {
        private const string BootstrapServers = "localhost:9092";
        private const string TopicName = "chat-topic";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Kafka Chat Application");
            Console.WriteLine("1. Producer (Send messages)");
            Console.WriteLine("2. Consumer (Receive messages)");
            Console.Write("Choose option (1 or 2): ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await RunProducer();
                    break;
                case "2":
                    RunConsumer();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Exiting...");
                    break;
            }
        }

        private static async Task RunProducer()
        {
            var producer = new ChatProducer(BootstrapServers, TopicName);
            await producer.StartProducing();
        }

        private static void RunConsumer()
        {
            var consumer = new ChatConsumer(BootstrapServers, TopicName, "chat-group");
            consumer.StartConsuming();
        }
    }
}