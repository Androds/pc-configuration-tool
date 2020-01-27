using PCConfiguration.Data.Interfaces.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace PCConfiguration.Data.Models
{
    public class Storage : IStorage
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public decimal Price { get; set; }

        /// <inheritdoc/>
        public string Capacity { get; set; }

        /// <inheritdoc/>
        public short Cache { get; set; }

        /// <inheritdoc/>
        [NotMapped]
        public int Quantity { get; set; } = 1;

        /// <inheritdoc/>
        public virtual FormFactor FormFactor { get; set; }

        /// <inheritdoc/>
        public int FormFactorId { get; set; }

        /// <inheritdoc/>
        public int InterfaceId { get; set; }

        /// <inheritdoc/>
        public virtual ConnectionInterface Interface { get; set; }

        /// <inheritdoc/>
        public int TypeId { get; set; }

        /// <inheritdoc/>
        public virtual PCItemType Type { get; set; }

        /// <inheritdoc/>
        public string ImageSrc { get; set; }
    }
}
