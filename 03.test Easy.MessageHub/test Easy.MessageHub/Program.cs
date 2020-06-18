using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.MessageHub;

namespace test_Easy.MessageHub
{
    class Program
    {
        static void Main(string[] args)
        {
            // the Easy.MessageHub is an implementation of the event aggregator pattern
            Subscribe();
            Publish();

            Console.Read();
        }

        public static void Publish()
        {
            var hub = Easy.MessageHub.MessageHub.Instance;
            // OrderPlaced and OrderDeleted both inherit from Order
            //hub.Publish(new OrderPlaced());
            //hub.Publish(new OrderDeleted());

            // let us send a string message on the same hub
            hub.Publish("A Very Important Message!");
        }
        public static void Subscribe()
        {
            var hub = Easy.MessageHub.MessageHub.Instance;

            Action<string> onNewOrder = o => {
                /* do whatever you want with the Order */
                Console.WriteLine("New Message Came it is: " + o);
            };
            var token = hub.Subscribe(onNewOrder);
        }
    }
}
