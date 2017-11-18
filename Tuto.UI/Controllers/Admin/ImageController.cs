using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tuto.Data.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Tuto.UI.Controllers.Admin
{
    public class ImageController : Controller
    {
        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public Image Upload([Bind("Name")] Image image, IFormFile file)
        {
            using (var binaryReader = file.OpenReadStream())
            using (var memoryStream = new MemoryStream())
            {
                binaryReader.CopyTo(memoryStream);
                image.Content = memoryStream.ToArray();
            }
            return image;
        }

        public ActionResult GetImage(int id)
        {
            return File()
        }
    }
}