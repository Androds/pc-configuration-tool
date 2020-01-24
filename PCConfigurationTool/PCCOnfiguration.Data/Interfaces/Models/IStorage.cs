using System;
using System.Collections.Generic;
using System.Text;

namespace PCConfiguration.Data.Interfaces.Models
{
    public interface IStorage : IPCItem
    {
        public string Capacity { get; set; }
        public short Cache { get; set; }
    }
}
