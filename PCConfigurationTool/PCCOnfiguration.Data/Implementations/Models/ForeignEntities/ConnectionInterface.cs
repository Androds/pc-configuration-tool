using PCConfiguration.Data.Interfaces.Models;


namespace PCConfiguration.Data.Models
{
    public class ConnectionInterface : IPCSubItem
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }


        /// <inheritdoc/>
        public virtual Storage Storage { get; set; }

        /// <inheritdoc/>
        public virtual VideoCard VideoCard { get; set; }
    }
}
