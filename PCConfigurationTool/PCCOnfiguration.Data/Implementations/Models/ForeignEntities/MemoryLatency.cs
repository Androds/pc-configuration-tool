using PCConfiguration.Data.Interfaces.Models;

namespace PCConfiguration.Data.Models
{
    public class MemoryLatency : IPCSubItem
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public Memory Memory { get; set; }
    }
}
