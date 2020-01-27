using PCConfiguration.Data.Interfaces.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace PCConfiguration.Data.Models
{
    public class Case : ICase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string PowerSupply { get; set; }
        public bool Window { get; set; }
        public short ExternalBays { get; set; }
        public short InternalBays { get; set; }

        [NotMapped]
        public int Quantity { get; set; } = 1;

        public int TypeId { get; set; }
        public PCItemType Type { get; set; }        
    }
}
