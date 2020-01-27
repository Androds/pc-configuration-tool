namespace PCConfiguration.Data.Interfaces.Models
{
    public interface IVideoCard : IPCItem
    {
        /// <summary>
        /// Gets or sets the chipset.
        /// </summary>
        /// <value>
        /// The chipset.
        /// </value>
        public string Chipset { get; set; }

        /// <summary>
        /// Gets or sets the size of the memory.
        /// </summary>
        /// <value>
        /// The size of the memory.
        /// </value>
        public int MemorySize { get; set; }

        /// <summary>
        /// Gets or sets the core speed.
        /// </summary>
        /// <value>
        /// The core speed.
        /// </value>
        public short CoreSpeed { get; set; }

        /// <summary>
        /// Gets or sets the boost speed.
        /// </summary>
        /// <value>
        /// The boost speed.
        /// </value>
        public short BoostSpeed { get; set; }
    }
}
