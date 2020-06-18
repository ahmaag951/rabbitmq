using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test_web_rabbit_mq.Models
{
    public class PublisherCityAdded : ICityAdded
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}