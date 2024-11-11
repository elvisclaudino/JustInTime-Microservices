using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace JustInTime.Gateway;

public class RabbitMqReceiver
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMqReceiver(string hostname = "localhost")
    {
        var factory = new ConnectionFactory() { HostName = hostname };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.QueueDeclare(queue: "user_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
    }

    public void ReceiveMessage()
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($"[x] Received message: {message}");

        };

        _channel.BasicConsume(queue: "user_queue", autoAck: true, consumer: consumer);
        Console.WriteLine(" [*] Waiting for messages. To exit press CTRL+C");
    }

    public void Close() => _connection.Close();
}
