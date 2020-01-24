using PCCOnfiguration.Data.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCCOnfiguration.Data.Models
{
    public class MemoryLatency : IPCSubItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int MemoryId { get; set; }
        public Memory Memory { get; set; }
    }
}
