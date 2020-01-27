﻿using PCConfiguration.Data.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCConfiguration.Data.Models
{
    public class PCItemType : IPCSubItem
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public virtual Memory Memory { get; set; }
        public virtual Motherboard Motherboard { get; set; }
        public virtual Storage Storage { get; set; }
        public virtual Case Case { get; set; }
    }
}
