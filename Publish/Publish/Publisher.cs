using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publish
{
    public static class Publisher
    {
        
        private static readonly IModel _channel;
        static Publisher()
        {
            var factory = new ConnectionFactory() { HostName = "white-mynah-bird.rmq.cloudamqp.com", Password = "uDatVEsNZyk0scl-bflhGrtTsJPZKu6M", UserName = "uDatVEsNZyk0scl-bflhGrtTsJPZKu6M", Uri = "amqp://azasgnqx:uDatVEsNZyk0scl-bflhGrtTsJPZKu6M@white-mynah-bird.rmq.cloudamqp.com/azasgnqx" };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
        }
        public static void Publish(string que, string message)
        {         
             
            _channel.QueueDeclare(queue: que, durable: true, exclusive: false, autoDelete: false, arguments: null);
            var body = Encoding.UTF8.GetBytes(message);

            var properties = _channel.CreateBasicProperties();
            properties.SetPersistent(true);

            _channel.BasicPublish(exchange: "logs", routingKey: "asd.critical", basicProperties: properties, body: body);
        }
    }
}
