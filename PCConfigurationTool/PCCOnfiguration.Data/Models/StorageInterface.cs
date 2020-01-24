using PCCOnfiguration.Data.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCCOnfiguration.Data.Models
{
    public class StorageInterface : IPCSubItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
