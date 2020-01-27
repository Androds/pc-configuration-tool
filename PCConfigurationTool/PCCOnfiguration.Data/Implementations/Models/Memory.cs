using PCConfiguration.Data.Interfaces.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace PCConfiguration.Data.Models
{
    public class Memory : IMemory
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public decimal Price { get; set; }

        /// <inheritdoc/>
        public int Speed { get; set; }

        /// <inheritdoc/>
        public short Modules { get; set; }

        /// <inheritdoc/>
        [NotMapped]
        public int Quantity { get; set; } = 1;

        /// <inheritdoc/>
        public int TypeId { get; set; }

        /// <inheritdoc/>
        public PCItemType Type { get; set; }

        /// <inheritdoc/>
        public int CASLatencyId { get; set; }

        /// <inheritdoc/>
        public MemoryLatency CASLatency { get; set; }

        /// <inheritdoc/>
        public string ImageSrc { get; set; }
    }
}
