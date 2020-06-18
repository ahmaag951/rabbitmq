using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_web_rabbit_mq.Models;
using RabbitMQ.Client;
using System.Text;
using RabbitMQ.Client.Events;

namespace test_web_rabbit_mq.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string AddCity()
        {
            // add city in database
            // publish that you have added a city

            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            
                channel.QueueDeclare(queue: "task_queue",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var city = new PublisherCityAdded { CityId = 1, CityName = "Cairo"};
                var body = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(city));

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(exchange: "",
                                     routingKey: "task_queue",
                                     basicProperties: properties,
                                     body: body);

            return "City Added Successfully";
        }
    }
}