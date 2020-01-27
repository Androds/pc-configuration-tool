namespace PCConfiguration.Data.Interfaces.Models
{
    public interface IMemory : IPCItem
    {
        /// <summary>
        /// Gets or sets the speed.
        /// </summary>
        /// <value>
        /// The speed.
        /// </value>
        public int Speed { get; set; }

        /// <summary>
        /// Gets or sets the modules.
        /// </summary>
        /// <value>
        /// The modules.
        /// </value>
        public short Modules { get; set; }
    }
}
