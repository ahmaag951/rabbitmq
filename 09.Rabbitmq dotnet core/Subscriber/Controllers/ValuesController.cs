using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Events;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Subscriber.Events;

namespace Subscriber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            TamsEvent<LeaveChanged>.Subscribe(QueuesNames.Leaves, OnLeaveChanged);
            TamsEvent<AllowanceChanged>.Subscribe(QueuesNames.Allowances, OnAllowanceChanged);
            return new string[] { "subscriber" };
        }

        public void OnLeaveChanged(LeaveChanged input)
        {
            //... do something
        }

        public void OnAllowanceChanged(AllowanceChanged input)
        {
            //... do something
        }

    }
}
