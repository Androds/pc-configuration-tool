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
        public virtual  Memory Memory { get; set; }

        /// <inheritdoc/>
        public virtual Motherboard Motherboard { get; set; }

        /// <inheritdoc/>
        public virtual Storage Storage { get; set; }

        /// <inheritdoc/>
        public virtual Case Case { get; set; }
    }
}
