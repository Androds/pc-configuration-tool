using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCConfigurationClient.ViewModels
{
    public class SummaryViewModel
    {
        public string Name { get; set; }
        public string Total { get; set; }
        public decimal Price { get; set; }
        public string OverallTotal { get; set; }
    }
}
