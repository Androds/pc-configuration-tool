using PCConfiguration.Data.Interfaces.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace PCConfiguration.Data.Models
{
    public class CPUCooler : ICPUCooler
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public decimal Price { get; set; }

        /// <inheritdoc/>
        public int FanRPM { get; set; }

        /// <inheritdoc/>
        public int NoiseLevel { get; set; }

        /// <inheritdoc/>
        public double Size { get; set; }

        /// <inheritdoc/>
        [NotMapped]
        public int Quantity { get; set; } = 1;
    }
}
