using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TutoDataRepo;
using Tuto.UI.Models.Library;

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

            ShowEntryModel entryModel = new ShowEntryModel();
            entryModel.Title = entry.Title;
            entryModel.Content = entry.Content;
            return View(entryModel);
        }
    }
}