using PCConfiguration.Data.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCConfiguration.Data.Models
{
    public class Storage : IStorage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Capacity { get; set; }
        public short Cache { get; set; }

        
        public virtual  FormFactor FormFactor { get; set; }
        public int FormFactorId { get; set; }
        public int InterfaceId { get; set; }
        public virtual ConnectionInterface Interface { get; set; }
        public int TypeId { get; set; }
        public virtual PCItemType Type { get; set; }
    }
}
