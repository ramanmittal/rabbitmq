using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Subscribe
{
    class Program
    {
        static void Main(string[] args)
        {
            new Worker1().Subcribe();

            new Worker2().Subcribe();
            

           

        }
    }
}

