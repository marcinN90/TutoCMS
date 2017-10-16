using System;
using System.Collections.Generic;
using System.Text;

namespace TutoData.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShorSeoDescription { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public DateTime? UpdatedOn { get; set; }


        public Category Category { get; set; }
    }
}
