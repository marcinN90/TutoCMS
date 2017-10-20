using System;
using System.Collections.Generic;
using System.Text;

namespace Tuto.Data.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SeoDescription { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public DateTime LastRevisionAt { get; set; }


        public Category Category { get; set; }
    }
}
