using PCConfiguration.Data.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCConfiguration.Data.Models
{
    public class CaseType : IPCSubItem
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public Case Case { get; set; }
    }
}
