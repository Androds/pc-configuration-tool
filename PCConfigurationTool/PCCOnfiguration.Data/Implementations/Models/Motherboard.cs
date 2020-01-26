using PCConfiguration.Data.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCConfiguration.Data.Models
{
    public class Motherboard : IMotherboard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public short RamSlots { get; set; }
        public short MaxRam { get; set; }

        [NotMapped]
        public int Quantity { get; set; } = 1;

        public int SocketTypeId { get; set; }
        public PCItemType SocketType { get; set; }
        public int FormFactorId { get; set; }
        public FormFactor FormFactor { get; set; }
    }
}
