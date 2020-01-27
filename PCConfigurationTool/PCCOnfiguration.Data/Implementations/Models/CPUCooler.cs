using PCConfiguration.Data.Interfaces.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace PCConfiguration.Data.Models
{
    public class CPUCooler : ICPUCooler
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int FanRPM { get; set; }
        public int NoiseLevel { get; set; }
        public double Size { get; set; }

        [NotMapped]
        public int Quantity { get; set; } = 1;
    }
}
