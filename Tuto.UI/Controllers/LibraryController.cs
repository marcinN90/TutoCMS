using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TutoDataRepo;
using Tuto.UI.Models.DTOModels;
using Tuto.UI.Models;
using AutoMapper;

namespace Tuto.UI.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ITudoDataRepository _dataRepository;
        private readonly IMapper _mapper;
        public LibraryController(ITudoDataRepository dataRepository, IMapper mapper)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> ShowEntry(int? id)
        {
            if (id == null)
                return NotFound();

            var entry = await _dataRepository.GetEntryById((int)id);
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
            var mappedLinks = _mapper.Map<List<LinkDTO>>(links);
            entryModel.Links = mappedLinks;

            var categories = await _dataRepository.GetAllCategories();
            entryModel.Categories = new List<CategoryDTO>();
            
            foreach (var category in categories)
            {
                var _mappedEntries = _mapper.Map <List<EntryDTO>>(category.Entries);
                var entries = new List<EntryDTO>();

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