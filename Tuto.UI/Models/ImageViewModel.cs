using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tuto.UI.Models
{
    public class ImageViewModel
    {
        public IFormFile Image { get; set; }
    }
}
