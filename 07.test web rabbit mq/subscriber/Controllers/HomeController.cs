using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using subscriber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace subscriber.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // listen to the new message

            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "task_queue",
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            var consumer = new EventingBasicConsumer(channel);
            var myMessage = "...";
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                try
                {
                    var city = JsonConvert.DeserializeObject<SubscriberCity>(message);

                }
                catch (Exception e)
                {

                }
                myMessage = message;

                int dots = message.Split('.').Length - 1;
                Thread.Sleep(dots * 1000);

                channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            };
            channel.BasicConsume(queue: "task_queue",
                                 autoAck: false,
                                 consumer: consumer);

            // send the message to the view.
            ViewBag.Message = myMessage;
            return View();
        }
    }
}
