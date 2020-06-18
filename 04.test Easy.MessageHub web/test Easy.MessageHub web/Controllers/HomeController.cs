using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test_Easy.MessageHub_web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var hub = Easy.MessageHub.MessageHub.Instance;

            Action<string> onNewOrder = o => 
            {
                /* do whatever you want with the Order */
                Console.WriteLine("New Message Came it is: " + o);
                Debug.WriteLine("New Message Came it is: " + o);
                new StreamWriter(Server.MapPath("/subscriptions/release_notification_emails.txt"), true);

            };
            var token = hub.Subscribe(onNewOrder);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}