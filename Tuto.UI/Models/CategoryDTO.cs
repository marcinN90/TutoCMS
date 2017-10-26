using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuto.UI.Models.Home;

namespace Tuto.UI.Models
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int EntriesCounter { get; set; }
        public List<EntryDTO> Entires { get; set; }
    }
}
