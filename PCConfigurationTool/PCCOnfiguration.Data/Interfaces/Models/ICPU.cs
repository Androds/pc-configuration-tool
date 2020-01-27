namespace PCConfiguration.Data.Interfaces.Models
{
    public interface ICPU : IPCItem
    {
        public int CoresCount { get; set; }

        public string CoreClock { get; set; }

        public string BoostClock { get; set; }

        public bool IntegratedGPU { get; set; }
    }
}
