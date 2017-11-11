using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tuto.UI.Models.DTOModels;

namespace Tuto.UI.Models
{
    public class ShowEntryViewModel
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

        public List<CategoryDTO> Categories { get; set; }
    }
}
