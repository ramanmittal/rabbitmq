using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscribe
{
    public abstract class AbstractWorker
    {
        
        protected readonly string _que;
        private readonly IModel _channel;
        public AbstractWorker(string que)
        {
            var factory = new ConnectionFactory() { HostName = "white-mynah-bird.rmq.cloudamqp.com", Password = "uDatVEsNZyk0scl-bflhGrtTsJPZKu6M", UserName = "uDatVEsNZyk0scl-bflhGrtTsJPZKu6M", Uri = "amqp://azasgnqx:uDatVEsNZyk0scl-bflhGrtTsJPZKu6M@white-mynah-bird.rmq.cloudamqp.com/azasgnqx" };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _que = que;
        }

        public void Subcribe()
        {
            _channel.QueueDeclare(queue: _que, durable: true, exclusive: false, autoDelete: false, arguments: null);
           // channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                Implement(_channel, ea);

            };
            _channel.BasicConsume(queue: _que, noAck: false, consumer: consumer);


        }
        protected abstract void Implement(IModel channel, BasicDeliverEventArgs ea);
    }
}
