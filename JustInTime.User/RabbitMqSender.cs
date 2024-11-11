using RabbitMQ.Client;
using System.Text;

namespace JustInTime.User;

public class RabbitMqSender
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMqSender(string hostname = "localhost")
    {
        var factory = new ConnectionFactory() { HostName = hostname };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.QueueDeclare(queue: "user_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
    }

    public void SendMessage(string message)
    {
        var body = Encoding.UTF8.GetBytes(message);
        _channel.BasicPublish(exchange: "", routingKey: "user_queue", basicProperties: null, body: body);
        Console.WriteLine($"[x] Sent {message}");
    }

    public void Close() => _connection.Close();
}
