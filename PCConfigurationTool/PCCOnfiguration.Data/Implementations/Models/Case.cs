using PCConfiguration.Data.Interfaces.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace PCConfiguration.Data.Models
{
    public class Case : ICase
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public decimal Price { get; set; }

        /// <inheritdoc/>
        public string Color { get; set; }

        /// <inheritdoc/>
        public string PowerSupply { get; set; }

        /// <inheritdoc/>
        public bool Window { get; set; }

        /// <inheritdoc/>
        public short ExternalBays { get; set; }

        /// <inheritdoc/>
        public short InternalBays { get; set; }

        /// <inheritdoc/>
        [NotMapped]
        public int Quantity { get; set; } = 1;

        /// <inheritdoc/>
        public int TypeId { get; set; }

        /// <inheritdoc/>
        public PCItemType Type { get; set; }

        /// <inheritdoc/>
        public string ImageSrc { get; set; }
    }
}
