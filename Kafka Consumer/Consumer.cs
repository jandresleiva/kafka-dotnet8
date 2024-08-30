

using Confluent.Kafka;
using System.Security.Cryptography.X509Certificates;

namespace Kafka_Consumer;

internal class Consumer
{
    const string topic = "test-topic";

    private readonly ConsumerConfig _config;

    public Consumer()
    {
        _config = new ConsumerConfig
        {
            // User-specific properties that you must set
            BootstrapServers = "localhost:9091,localhost:9092,localhost:9093",

            // Fixed properties
            // SecurityProtocol = SecurityProtocol.SaslPlaintext,
            SecurityProtocol = SecurityProtocol.Plaintext,
            // SaslMechanism = SaslMechanism.Plain,
            GroupId = "test-consumer-group",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

    }

    public void Consume()
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        Console.CancelKeyPress += (_, e) => {
            e.Cancel = true; // prevent the process from terminating.
            cts.Cancel();
        };

        using (var consumer = new ConsumerBuilder<string, string>(_config).Build())
        {
            consumer.Subscribe(topic);
            try
            {
                while (true)
                {
                    var cr = consumer.Consume(cts.Token);
                    Console.WriteLine($"Consumed event from topic {topic}: key = {cr.Message.Key,-10} value = {cr.Message.Value}");
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("--Finishing--");
                // Ctrl-C was pressed.
            }
            finally
            {
                consumer.Close();
            }
        }
    }
}
