using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tuto.UI.Models.DTOModels
{
    public class EntryInfoDTO
    {
        public int EntryNumberInCategory { get; set; }
        public int NumberOfEntriesInCategory { get; set; }
        public int PreviousEntryId { get; set; }
        public int NextEntryId { get; set; }
        public string NextEntryTitle { get; set; }
        public string PrevEntryTitle { get; set; }
    }
}
