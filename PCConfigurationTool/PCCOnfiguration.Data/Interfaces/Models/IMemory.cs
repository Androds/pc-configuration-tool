using System;
using System.Collections.Generic;
using System.Text;

namespace PCCOnfiguration.Data.Interfaces.Models
{
    public interface IMemory : IPCItem
    {
        public  int Speed { get; set; }
        public short Modules { get; set; }
    }
}
