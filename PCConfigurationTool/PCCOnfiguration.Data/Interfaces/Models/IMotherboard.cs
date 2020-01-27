namespace PCConfiguration.Data.Interfaces.Models
{
    public interface IMotherboard : IPCItem
    {
        /// <summary>
        /// Gets or sets the ram slots.
        /// </summary>
        /// <value>
        /// The ram slots.
        /// </value>
        public short RamSlots { get; set; }

        /// <summary>
        /// Gets or sets the maximum ram.
        /// </summary>
        /// <value>
        /// The maximum ram.
        /// </value>
        public short MaxRam { get; set; }
    }
}
