using Contracts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lookups.UI.Events
{
    public class CityAdded : ICityAdded
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
    }
}