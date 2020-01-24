using PCCOnfiguration.Data.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCCOnfiguration.Data.Models
{
    public class PowerSupplyFormFactor : IPCSubItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int PowerSupplyId { get; set; }
        public PowerSupply PowerSupply { get; set; }
    }
}
