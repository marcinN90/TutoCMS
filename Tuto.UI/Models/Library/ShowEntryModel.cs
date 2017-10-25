using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tuto.UI.Models.Library
{
    public class ShowEntryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        
        [Display(Name ="Ostatnia rewizja:")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastRevisionAt { get; set; }
        public string SeoDescription { get; set; }
        public int CategoryId { get; set; }
        [Display(Name = "Kategoria:")]
        public string CategoryTitle { get; set; }   
        
        public List<LinkDTO> Links { get; set; }
    }
}
