using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tuto.Data.Models
{
    public class WebsiteDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string OwnerEmail { get; set; }
        public string GoogleAnalyticsCode { get; set; }
    }
}
