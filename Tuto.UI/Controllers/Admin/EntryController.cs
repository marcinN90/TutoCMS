using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TutoDataRepo;

namespace Tuto.UI.Controllers.Admin
{
    public class EntryController : Controller
    {
        private readonly ITudoDataRepository _repo;
        public EntryController(ITudoDataRepository repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            var entries = await _repo.GetAllEntries();
            return View(entries);
        }
    }
}