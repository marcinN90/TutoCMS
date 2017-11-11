using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tuto.Data.Models
{
    public class WebsiteDetails
    {
        [Key]
        public string Title { get; set; }
        public string OwnerEmail { get; set; }
        public string GoogleAnalyticsCode { get; set; }
    }
}
