using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Publisher.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var hub = Easy.MessageHub.MessageHub.Instance;
            // OrderPlaced and OrderDeleted both inherit from Order
            //hub.Publish(new OrderPlaced());
            //hub.Publish(new OrderDeleted());

            // let us send a string message on the same hub
            hub.Publish("A Very Important Message!");

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