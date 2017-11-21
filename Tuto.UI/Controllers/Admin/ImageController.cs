using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tuto.Data.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Tuto.UI.Models;
using TutoDataRepo;
using Microsoft.AspNetCore.Authorization;

namespace Tuto.UI.Controllers.Admin
{
    public class ImageController : Controller
    {
        ITudoDataRepository _repo;
        public ImageController(ITudoDataRepository repo)
        {
            _repo = repo;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Upload(ImageViewModel imageUploaded)
        {
            Image imageToSave = new Image();
            using (var memoryStream = new MemoryStream())
            {
                imageToSave.Title = imageUploaded.Image.FileName;
                imageUploaded.Image.CopyTo(memoryStream);
                imageToSave.Content = memoryStream.ToArray();
            }
            await _repo.SaveUploadedImage(imageToSave);

            return RedirectToAction(nameof(Index));
        }


        [Authorize]
        public async Task<IActionResult> Index()
        {
            var images = await _repo.GetAllImages();
            return View(images);
        }

        public async Task<IActionResult> Show(int id)
        {
            var image = await _repo.GetImageById(id);
            return File(image.Content, "image/jpg");
        }

        //public ActionResult GetImage(int id)
        //{
        //    return File()
        //}
    }
}