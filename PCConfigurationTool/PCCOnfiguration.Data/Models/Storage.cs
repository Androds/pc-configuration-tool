using PCCOnfiguration.Data.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCCOnfiguration.Data.Models
{
    public class Storage : IStorage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Capacity { get; set; }
        public short Cache { get; set; }

        public StorageFormFactor FormFactor { get; set; }
        public StorageInterface Interface { get; set; }
        public StorageType Type { get; set; }
    }
}
