using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Events;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Publisher.Events;
using RabbitMQ.Client;

namespace Publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var newLeave = new LeaveChanged { Id = 55, Name = "first city", Lat = "test lat", Long = "test long" };
            TamsEvent<LeaveChanged>.Publish(newLeave, QueuesNames.Leaves);

            var newAllowance = new AllowanceChanged { Id = 55, Name = "first allowance"};
            TamsEvent<AllowanceChanged>.Publish(newAllowance, QueuesNames.Allowances);

            return new string[] { "publisher" };
        }
    }
}
