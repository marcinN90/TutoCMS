using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tuto.UI.Models.Home
{
    public class HomePageModel
    {
        public string WebSiteTitle { get; set; }
        public string HomePageTitle { get; set; }
        public string Description { get; set; }
        public string SeoDescription  { get; set; }
        public List<CategoryDTO> Categories { get; set; }

        public List<LinkDTO> Links { get; set; }
    }
}
