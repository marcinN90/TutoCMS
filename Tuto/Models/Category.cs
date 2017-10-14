using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tuto.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Entry> Entries { get; set; }
    }
}
