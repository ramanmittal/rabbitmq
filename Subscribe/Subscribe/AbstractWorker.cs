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
        protected readonly string _key;
        private static readonly IConnection connection;
        private static IModel _channel;

        static AbstractWorker()
        {
            connection = ChannelFactory.GetInstance();
            _channel = connection.CreateModel();
        }
        public AbstractWorker(string que)
        {

            _que = que;
            _key = que;
        }
        public AbstractWorker(string que, string key)
        {

            _que = que;
            _key = key;
        }

        public void Subcribe()
        {
            // _channel = connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "logs", type: "topic");
            _channel.QueueDeclare(queue: _que, durable: true, exclusive: false, autoDelete: false, arguments: null);

            _channel.QueueBind(queue: _que,
                              exchange: "logs",
                              routingKey: _key
                              );
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
