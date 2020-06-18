using Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Subscriber.Events
{
    public class AllowanceChanged : IAllowanceChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
