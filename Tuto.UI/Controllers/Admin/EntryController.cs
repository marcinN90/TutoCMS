using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TutoDataRepo;
using Tuto.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Tuto.UI.Controllers.Admin
{
    [Authorize]
    public class EntryController : Controller
    {
        private readonly ITudoDataRepository _repo;
        public EntryController(ITudoDataRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index() => View(await _repo.GetAllEntries());

        public async Task<IActionResult> Details (int? id)
        {
            if (id == null)
            {
                TempData["message"] = "Select entryId to show details";
                RedirectToAction(nameof(Index));
            }
            return View(await _repo.GetEntryById((int)id));
        }

        public async Task<IActionResult> Create()
        {
            await PopulateCategoriesDropDownList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title", "CategoryId", "SeoDescription", "Content")] Entry  entry)
        {
            if(ModelState.IsValid)
            {
                entry.LastRevisionAt = DateTime.Now;
                await _repo.CreateEntry(entry);
                TempData["message"] = "Entry successfully added to database";
                return RedirectToAction(nameof(Index));
            }
            await PopulateCategoriesDropDownList();
            return View(entry);
        }

        [HttpGet]
        public async Task<IActionResult> Edit (int? id)
        {
            if (id == null)
            {
                TempData["message"] = "Select EntryId to edit";
                RedirectToAction(nameof(Index));
            }
            var entry = await _repo.GetEntryById((int)id);
            await PopulateCategoriesDropDownList(entry.CategoryId);
            return View(entry);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id", "Title", "CategoryId", "SeoDescription", "Content")] Entry entry)
        {
            if (!ModelState.IsValid)
            {
                return View(entry);
            }
            entry.LastRevisionAt = DateTime.Now;
            await _repo.SaveEntry(entry);
            return RedirectToAction(nameof(Details), new { id = entry.Id});
        }



        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null)
            {
                TempData["message"] = "Select EntryId to delete";
                RedirectToAction(nameof(Index));
            }
            await _repo.DeleteEntry((int)id);
            TempData["message"] = "Entry succesfully deleted";
            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateCategoriesDropDownList(object selectedCategory = null)
        {
            var categories = await _repo.GetAllCategories();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Title", selectedCategory);
        }
    }
}