using PCConfiguration.Data.Interfaces.Models;

namespace PCConfiguration.Data.Models
{
    public class FormFactor : IPCSubItem
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public Storage Storage { get; set; }

        /// <inheritdoc/>
        public Motherboard Motherboard { get; set; }

        /// <inheritdoc/>
        public PowerSupply PowerSupply { get; set; }
    }
}
