using PCCOnfiguration.Data.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCCOnfiguration.Data.Models
{
    public class VideoCardInterface : IPCSubItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int VideoCardId { get; set; }
        public VideoCard VideoCard { get; set; }
    }
}
