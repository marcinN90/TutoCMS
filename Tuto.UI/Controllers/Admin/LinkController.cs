using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TutoDataRepo;
using Tuto.Data.Models;

namespace Tuto.UI.Controllers.Admin
{
    public class LinkController : Controller
    {
        private readonly ITudoDataRepository _repo;
        public LinkController(ITudoDataRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var links = await _repo.GetAllLinks();
            return View(links);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task <IActionResult> Create(Link linkToCreate)
        {
            if (ModelState.IsValid)
            {
                await _repo.CreateLink(linkToCreate);
                TempData["message"] = "Link successfully added to database";
            }
            else
            {
                TempData["message"] = "Erroe while adding link to database";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                TempData["message"] = "No link selected to edit";
                RedirectToAction("Index");
            }

            var link = await _repo.GetLinkById((int)Id);
            return View(link);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Link link)
        {
            await _repo.SaveLink(link);
            TempData["message"] = "Link successfully Updated";
            return RedirectToAction("index");
        }

        public async Task <IActionResult> Delete (int? id)
        {
            if (id == null)
            {
                TempData["message"] = "Problem occurred! No LinkId selected to delete!";
                return RedirectToAction("index");
            }

            await _repo.DeleteLink((int)id);
            TempData["message"] = "Link successfully deleted";
            return RedirectToAction("index");
        }
        
    }
}