using PCConfiguration.Data.Interfaces.Models;
namespace PCConfiguration.Data.Models
{
    public class PCItemType : IPCSubItem
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public Memory Memory { get; set; }
        public Motherboard Motherboard { get; set; }
        public Storage Storage { get; set; }
        public Case Case { get; set; }
    }
}
