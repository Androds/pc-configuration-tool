using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCConfigurationClient.ViewModels
{
    public class PCItemInputModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CurrencySymbol { get; set; }
    }
}
