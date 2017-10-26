using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tuto.Data.Models
{
    public class HomePageSettings
    {
        [Key]
        public string Title { get; set; }
        public string Descritpion { get; set; }
        public string SeoDescription { get; set; }
    }
}
