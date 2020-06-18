using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Events
{
    public interface ICityAdded
    {
        int Id { get; set; }
        string Name { get; set; }
        string Lat { get; set; }
        string Long { get; set; }
    }
}
