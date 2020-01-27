using PCConfiguration.Data.Interfaces.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfiguration.Data.Models
{
    public class CPU : ICPU
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CoresCount { get; set; }
        public string CoreClock { get; set; }
        public string BoostClock { get; set; }
        public bool IntegratedGPU { get; set; }

        [NotMapped]
        public int Quantity { get; set; } = 1;
    }
}
