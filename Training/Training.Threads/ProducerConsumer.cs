using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Training.Threads
{
    public class ProducerConsumer
    {
        private readonly object mutex = new object();
        
        public int produce { get; set; }

        public ProducerConsumer()
        {
            this.produce = 0;
        }

        public void AddProduce(int amt)
        {
            lock (mutex)
            {
                Console.WriteLine($"Producer {Thread.CurrentThread.ManagedThreadId} is adding {amt} to produce");
                produce += amt;
                Console.WriteLine($"Producer {Thread.CurrentThread.ManagedThreadId} finished, pulsing other threads");

                Monitor.Pulse(mutex);
            }
        }

        public void ConsumeProduce(int amt)
        {
            lock (mutex)
            {
                Console.WriteLine($"Consumer {Thread.CurrentThread.ManagedThreadId} is trying to consume {amt}");
                while (produce < amt)
                {
                    Console.WriteLine($"Consumer {Thread.CurrentThread.ManagedThreadId} is waiting for produce");
                    Monitor.Wait(mutex);
                    Console.WriteLine($"Consumer {Thread.CurrentThread.ManagedThreadId} woke up");
                }
                Console.WriteLine($"Consumer {Thread.CurrentThread.ManagedThreadId} is consuming {amt} from produce");
                produce -= amt;
            }
        }
    }
}
