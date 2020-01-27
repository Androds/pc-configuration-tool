namespace PCConfiguration.Data.Interfaces.Models
{
    public interface ICPUCooler : IPCItem
    {
        public int FanRPM { get; set; }
        public int NoiseLevel { get; set; }
        public double Size { get; set; }
    }
}
