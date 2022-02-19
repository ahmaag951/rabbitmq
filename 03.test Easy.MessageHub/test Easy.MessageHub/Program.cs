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

            // let us send a string message on the same hub
            hub.Publish("This is the new Message!");
        }
        public static void Subscribe()
        {
            var hub = Easy.MessageHub.MessageHub.Instance;

            Action<string> onNewMessage = messaage => {
                /* do whatever you want with the message */
                Console.WriteLine("New Message Came it is: " + messaage);
            };
            var token = hub.Subscribe(onNewMessage);
        }
    }
}
