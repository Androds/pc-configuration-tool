namespace PCConfiguration.Data.Interfaces.Models
{
    public interface ICPUCooler : IPCItem
    {
        /// <summary>
        /// Gets or sets the fan RPM.
        /// </summary>
        /// <value>
        /// The fan RPM.
        /// </value>
        public int FanRPM { get; set; }

        /// <summary>
        /// Gets or sets the noise level.
        /// </summary>
        /// <value>
        /// The noise level.
        /// </value>
        public int NoiseLevel { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public double Size { get; set; }
    }
}
