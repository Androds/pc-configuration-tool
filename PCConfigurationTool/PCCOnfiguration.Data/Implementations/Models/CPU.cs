using PCConfiguration.Data.Interfaces.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfiguration.Data.Models
{
    public class CPU : ICPU
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public decimal Price { get; set; }

        /// <inheritdoc/>
        public int CoresCount { get; set; }

        /// <inheritdoc/>
        public string CoreClock { get; set; }

        /// <inheritdoc/>
        public string BoostClock { get; set; }

        /// <inheritdoc/>
        public bool IntegratedGPU { get; set; }

        /// <inheritdoc/>
        [NotMapped]
        public int Quantity { get; set; } = 1;

        /// <inheritdoc/>
        public string ImageSrc { get; set; }
    }
}
