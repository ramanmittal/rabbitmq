using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publish
{
    class Program
    {

        static void Main(string[] args)
        {
            Publisher.Publish("task_queue1", "task_queue1");
            Publisher.Publish("task_queue1", "task_queue1");
            Publisher.Publish("task_queue2", "task_queue2");
            Publisher.Publish("task_queue2", "task_queue2");
            Publisher.Publish("task_queue2", "task_queue2");
            Publisher.Publish("task_queue2", "task_queue2");
            Publisher.Publish("task_queue2", "task_queue2");
            Publisher.Publish("task_queue2", "task_queue2");
            
            
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
        
       
    }
}
