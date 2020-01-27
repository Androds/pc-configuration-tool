using PCConfiguration.Data.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCConfiguration.Data.Models
{
    public class VideoCard : IVideoCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Chipset { get; set; }
        public int MemorySize { get; set; }
        public short CoreSpeed { get; set; }
        public short BoostSpeed { get; set; }


        public int InterfaceId { get; set; }
        public virtual ConnectionInterface Interface { get; set; }
    }
}
