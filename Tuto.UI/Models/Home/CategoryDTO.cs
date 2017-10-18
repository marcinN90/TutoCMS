using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tuto.UI.Models.Home
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int EntriesCounter { get; set; }
        public List<EntryDTO> Entires { get; set; }
    }
}
