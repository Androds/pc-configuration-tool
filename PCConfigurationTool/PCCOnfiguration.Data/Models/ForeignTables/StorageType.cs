using PCConfiguration.Data.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCConfiguration.Data.Models
{
    public class StorageType : IPCSubItem
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public Storage Storage { get; set; }
    }
}
