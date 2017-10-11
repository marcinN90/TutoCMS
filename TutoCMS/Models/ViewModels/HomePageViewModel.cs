using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoCMS.Models.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}
