namespace PCConfiguration.Data.Interfaces.Models
{
    public interface IMemory : IPCItem
    {
        public  int Speed { get; set; }
        public short Modules { get; set; }
    }
}
