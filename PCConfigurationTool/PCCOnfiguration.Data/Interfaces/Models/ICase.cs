using System;
using System.Collections.Generic;
using System.Text;

namespace PCCOnfiguration.Data.Interfaces.Models
{
    public interface ICase : IPCItem
    {
        public short Type { get; set; }
        public string Color { get; set; }
        public string PowerSupply { get; set; }
        public bool Window { get; set; }
        public short ExternalBays { get; set; }
        public short InternalBays { get; set; }
    }
}
