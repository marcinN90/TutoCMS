using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TutoDataRepo;
using Tuto.UI.Models;

namespace Tuto.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly ITudoDataRepository _repo;
        public AdminController (ITudoDataRepository repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            AdminViewModel adminModel = new AdminViewModel();

            var categories = await _repo.GetAllCategories();
            adminModel.NumberOfAllCategories = categories.Count();

            var entries = await _repo.GetAllEntries();
            adminModel.NumberofAllEntries = entries.Count();

            var links = await _repo.GetAllLinks();
            adminModel.NumberOfAllLinks = links.Count();

            return View(adminModel);
        }
    }
}