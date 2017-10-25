using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TutoDataRepo;
using Tuto.UI.Models.Library;
using Tuto.UI.Models;

namespace Tuto.UI.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ITudoDataRepository _dataRepository;
        public LibraryController(ITudoDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        public async Task<IActionResult> ShowEntry(int? id)
        {
            if (id == null)
                return NotFound();

            var entry = await _dataRepository.GetEntryById(id);
            if (entry == null)
                return NotFound();

            ShowEntryModel entryModel = new ShowEntryModel();
            entryModel.Title = entry.Title;
            entryModel.Content = entry.Content;
            entryModel.LastRevisionAt = entry.LastRevisionAt;
            entryModel.CategoryId = entry.CategoryId;
            entryModel.CategoryTitle = entry.Category.Title;
            entryModel.SeoDescription = entry.SeoDescription;

            var links = await _dataRepository.GetAllLinks();
            var linksDTO = new List<LinkDTO>();
            foreach (var link in links)
            {
                linksDTO.Add(new Models.LinkDTO
                {
                    LinkTitle = link.LinkTitle,
                    UrlAddress = link.UrlAddress                
                });
            }

            entryModel.Links = linksDTO;
            return View(entryModel);
        }
    }
}