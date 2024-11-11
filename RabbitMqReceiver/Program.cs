using JustInTime.Gateway;

public class Program
{
    public static void Main(string[] args)
    {
        // Inicia o receiver para escutar as mensagens do RabbitMQ
        var receiver = new RabbitMqReceiver();
        receiver.ReceiveMessage();

        // Mantém o gateway rodando
        Console.ReadLine();
    }
}