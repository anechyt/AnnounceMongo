using System;
using System.Collections.Generic;

namespace Announcement.Application.DTO
{
    public class AnnounceDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Description { get; set; }
        public List<string> Photos { get; set; }
    }
}
