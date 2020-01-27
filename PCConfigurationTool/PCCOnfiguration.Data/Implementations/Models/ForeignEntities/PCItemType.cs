using PCConfiguration.Data.Interfaces.Models;
namespace PCConfiguration.Data.Models
{
    public class PCItemType : IPCSubItem
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public Memory Memory { get; set; }

        /// <inheritdoc/>
        public Motherboard Motherboard { get; set; }

        /// <inheritdoc/>
        public Storage Storage { get; set; }

        /// <inheritdoc/>
        public Case Case { get; set; }
    }
}
