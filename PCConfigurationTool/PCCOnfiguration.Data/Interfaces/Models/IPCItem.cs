using System;
using System.Collections.Generic;
using System.Text;

namespace PCConfiguration.Data.Interfaces.Models
{
    public interface IPCItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
