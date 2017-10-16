using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tuto.UI.Models.Home
{
    public class HomePageModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortSeoDescription  { get; set; }
        public List<Category> Categories { get; set; }
    }
}
