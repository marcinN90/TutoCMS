using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TutoDataRepo;
using Tuto.UI.Models.DTOModels;
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

            ShowEntryViewModel entryModel = new ShowEntryViewModel();
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
                linksDTO.Add(new LinkDTO
                {
                    LinkTitle = link.LinkTitle,
                    UrlAddress = link.UrlAddress                
                });
            }
            entryModel.Links = linksDTO;

            var categories = await _dataRepository.GetAllCategories();
            entryModel.Categories = new List<CategoryDTO>();
            foreach (var category in categories)
            {
                var entries = new List<EntryDTO>();
                foreach (var entryDetails in category.Entries)
                {
                    entries.Add(new EntryDTO
                    {
                        Id = entryDetails.Id,
                        Title = entryDetails.Title
                    });
                }

                entryModel.Categories.Add(new CategoryDTO
                {
                    Id = category.Id,
                    Title = category.Title,
                    Entires = entries
                });
            }
            return View(entryModel);
        }
    }
}