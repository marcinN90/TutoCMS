using System;
using System.Collections.Generic;
using System.Text;

namespace Tuto.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortSeoDescription { get; set; }
        public List<Entry> Entries { get; set; }
    }
}
