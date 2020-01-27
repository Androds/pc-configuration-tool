namespace PCConfiguration.Data.Interfaces.Models
{
    public interface ICPU : IPCItem
    {
        /// <summary>
        /// Gets or sets the cores count.
        /// </summary>
        /// <value>
        /// The cores count.
        /// </value>
        public int CoresCount { get; set; }

        /// <summary>
        /// Gets or sets the core clock.
        /// </summary>
        /// <value>
        /// The core clock.
        /// </value>
        public string CoreClock { get; set; }

        /// <summary>
        /// Gets or sets the boost clock.
        /// </summary>
        /// <value>
        /// The boost clock.
        /// </value>
        public string BoostClock { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether has [integrated gpu].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [integrated gpu]; otherwise, <c>false</c>.
        /// </value>
        public bool IntegratedGPU { get; set; }
    }
}
