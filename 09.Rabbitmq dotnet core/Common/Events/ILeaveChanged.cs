using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Events
{
    public interface ILeaveChanged
    {
        int Id { get; set; }
        string Name { get; set; }
        string Lat { get; set; }
        string Long { get; set; }
    }
}
