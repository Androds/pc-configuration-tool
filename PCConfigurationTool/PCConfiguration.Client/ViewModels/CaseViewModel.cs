using PCConfiguration.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCConfiguration.Client.ViewModels
{
    public class CaseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Color { get; set; }

        public string PowerSupply { get; set; }

        public bool Window { get; set; }

        public short ExternalBays { get; set; }

        public short InternalBays { get; set; }

        public int Quantity { get; set; } = 1;

        public string Type { get; set; }

        public string ImageSrc { get; set; }
    }
}
