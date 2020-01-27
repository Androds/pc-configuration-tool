using PCConfiguration.Data.Interfaces.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace PCConfiguration.Data.Models
{
    public class PowerSupply : IPowerSupply
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public decimal Price { get; set; }

        /// <inheritdoc/>
        public sbyte Efficiency { get; set; }

        /// <inheritdoc/>
        public short Wattage { get; set; }

        /// <inheritdoc/>
        public bool Modular { get; set; }

        /// <inheritdoc/>
        [NotMapped]
        public int Quantity { get; set; } = 1;

        /// <inheritdoc/>
        public int FormFactorId { get; set; }

        /// <inheritdoc/>
        public FormFactor FormFactor { get; set; }
    }
}
