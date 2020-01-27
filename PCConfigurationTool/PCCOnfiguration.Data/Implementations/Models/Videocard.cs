using PCConfiguration.Data.Interfaces.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace PCConfiguration.Data.Models
{
    public class VideoCard : IVideoCard
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public decimal Price { get; set; }

        /// <inheritdoc/>
        public string Chipset { get; set; }

        /// <inheritdoc/>
        public int MemorySize { get; set; }

        /// <inheritdoc/>
        public short CoreSpeed { get; set; }

        /// <inheritdoc/>
        public short BoostSpeed { get; set; }

        /// <inheritdoc/>
        [NotMapped]
        public int Quantity { get; set; } = 1;

        /// <inheritdoc/>
        public int InterfaceId { get; set; }

        /// <inheritdoc/>
        public virtual ConnectionInterface Interface { get; set; }

        /// <inheritdoc/>
        public string ImageSrc { get; set; }
    }
}
