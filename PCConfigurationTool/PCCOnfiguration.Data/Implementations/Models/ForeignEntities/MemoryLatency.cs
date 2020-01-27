using PCConfiguration.Data.Interfaces.Models;

namespace PCConfiguration.Data.Models
{
    public class MemoryLatency : IPCSubItem
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public Memory Memory { get; set; }
    }
}
