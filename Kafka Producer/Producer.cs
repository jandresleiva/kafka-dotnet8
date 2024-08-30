using Confluent.Kafka;

namespace Kafka_Producer;

public class Producer
{
    const string topic = "test-topic";

    private readonly ProducerConfig _config;

    public Producer()
    {

        _config = new ProducerConfig
        {
            // User-specific properties that you must set
            BootstrapServers = "localhost:9091,localhost:9092,localhost:9093",
            // Fixed properties
            Acks = Acks.All
        };
    }

    public void Pub()
    {
        string[] users = { "eabara", "jsmith", "sgarcia", "jbernard", "htanaka", "awalther" };
        string[] items = { "book", "alarm clock", "t-shirts", "gift card", "batteries" };
        using (var producer = new ProducerBuilder<string, string>(_config).Build())
        {
            var numProduced = 0;
            Random rnd = new Random();
            const int numMessages = 10;
            for (int i = 0; i < numMessages; ++i)
            {
                var user = users[rnd.Next(users.Length)];
                var item = items[rnd.Next(items.Length)];

                producer.Produce(topic, new Message<string, string> { Key = user, Value = item },
                                    (deliveryReport) =>
                                    {
                                        if (deliveryReport.Error.Code != ErrorCode.NoError)
                                        {
                                            Console.WriteLine($"Failed to deliver message: {deliveryReport.Error.Reason}");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Produced event to topic {topic}: key = {user,-10} value = {item}");
                                            numProduced += 1;
                                        }
                                    });
            }

            producer.Flush(TimeSpan.FromSeconds(2));
            Console.WriteLine($"{numProduced} messages were produced to topic {topic}");
        }
    }
}
