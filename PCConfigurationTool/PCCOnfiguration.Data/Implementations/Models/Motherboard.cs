using PCConfiguration.Data.Interfaces.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace PCConfiguration.Data.Models
{
    public class Motherboard : IMotherboard
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public decimal Price { get; set; }

        /// <inheritdoc/>
        public short RamSlots { get; set; }

        /// <inheritdoc/>
        public short MaxRam { get; set; }


        /// <inheritdoc/>
        [NotMapped]
        public int Quantity { get; set; } = 1;

        /// <inheritdoc/>
        public int SocketTypeId { get; set; }

        /// <inheritdoc/>
        public PCItemType SocketType { get; set; }

        /// <inheritdoc/>
        public int FormFactorId { get; set; }

        /// <inheritdoc/>
        public FormFactor FormFactor { get; set; }

        /// <inheritdoc/>
        public string ImageSrc { get; set; }
    }
}
