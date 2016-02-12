using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscribe
{
    public class Worker1 : AbstractWorker
    {
        public Worker1()
            : base("asdf", "*.critical")
        {

        }
        protected override void Implement(RabbitMQ.Client.IModel channel, RabbitMQ.Client.Events.BasicDeliverEventArgs ea)
        {
            var body = ea.Body;
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine(" worker1 Received {0}", message);
            System.Threading.Thread.Sleep(10000);
            channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
        }
    }
}
