﻿using PCConfiguration.Data.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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

        public int TypeId { get; set; }
        public CaseType Type { get; set; }
    }
}
