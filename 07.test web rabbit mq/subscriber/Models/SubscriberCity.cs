using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace subscriber.Models
{
    public class SubscriberCity : ICityAdded
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}