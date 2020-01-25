using PCConfiguration.Data.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
