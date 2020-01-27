namespace PCConfiguration.Data.Interfaces.Models
{
    public interface IPowerSupply : IPCItem
    {
        /// <summary>
        /// Gets or sets the efficiency.
        /// </summary>
        /// <value>
        /// The efficiency.
        /// </value>
        public sbyte Efficiency { get; set; }

        /// <summary>
        /// Gets or sets the wattage.
        /// </summary>
        /// <value>
        /// The wattage.
        /// </value>
        public short Wattage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IPowerSupply"/> is modular.
        /// </summary>
        /// <value>
        ///   <c>true</c> if modular; otherwise, <c>false</c>.
        /// </value>
        public bool Modular { get; set; }
    }
}
