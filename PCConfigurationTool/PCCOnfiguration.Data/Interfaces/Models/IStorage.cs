namespace PCConfiguration.Data.Interfaces.Models
{
    public interface IStorage : IPCItem
    {
        /// <summary>
        /// Gets or sets the capacity.
        /// </summary>
        /// <value>
        /// The capacity.
        /// </value>
        public string Capacity { get; set; }

        /// <summary>
        /// Gets or sets the cache.
        /// </summary>
        /// <value>
        /// The cache.
        /// </value>
        public short Cache { get; set; }
    }
}
