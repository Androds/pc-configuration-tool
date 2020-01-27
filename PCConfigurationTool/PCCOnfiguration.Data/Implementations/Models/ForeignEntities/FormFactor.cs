using PCConfiguration.Data.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCConfiguration.Data.Models
{
    public class FormFactor : IPCSubItem
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public virtual Storage Storage { get; set; }
        public virtual Motherboard Motherboard { get; set; }
        public virtual PowerSupply PowerSupply { get; set; }
    }
}
