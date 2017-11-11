using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuto.UI.Models.DTOModels;

namespace Tuto.UI.Models
{
    public class HomePageViewModel
    {
        public string WebSiteTitle { get; set; }
        public string HomePageTitle { get; set; }
        public string Description { get; set; }
        public string SeoDescription  { get; set; }
        public string GoogleCode { get; set; }
        public List<CategoryDTO> Categories { get; set; }

        public List<LinkDTO> Links { get; set; }
    }
}
