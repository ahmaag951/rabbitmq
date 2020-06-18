using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Events
{
    public interface IAllowanceChanged
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
