using PCConfiguration.Data.Interfaces.Models;


namespace PCConfiguration.Data.Models
{
    public class ConnectionInterface : IPCSubItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        
        public Storage Storage { get; set; }
        public VideoCard VideoCard { get; set; }
    }
}
