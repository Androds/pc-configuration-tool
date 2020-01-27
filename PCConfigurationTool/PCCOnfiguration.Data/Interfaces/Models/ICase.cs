namespace PCConfiguration.Data.Interfaces.Models
{
    public interface ICase : IPCItem
    {
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the power supply.
        /// </summary>
        /// <value>
        /// The power supply.
        /// </value>
        public string PowerSupply { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ICase"/> has window.
        /// </summary>
        /// <value>
        ///   <c>true</c> if window; otherwise, <c>false</c>.
        /// </value>
        public bool Window { get; set; }

        /// <summary>
        /// Gets or sets the external bays.
        /// </summary>
        /// <value>
        /// The external bays.
        /// </value>
        public short ExternalBays { get; set; }

        /// <summary>
        /// Gets or sets the internal bays.
        /// </summary>
        /// <value>
        /// The internal bays.
        /// </value>
        public short InternalBays { get; set; }
    }
}
