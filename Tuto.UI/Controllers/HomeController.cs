using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Tuto.UI.Models.Home;
using TutoDataRepo;
using System.Threading.Tasks;
using Tuto.UI.Models;

namespace Tuto.UI.Controllers
{
    public class HomeController : Controller
    {
        ITudoDataRepository _dataRepo;
        public HomeController(ITudoDataRepository dataRepo)
        {
            _dataRepo = dataRepo;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _dataRepo.GetAllCategories();
         
            HomePageModel homeModel = new HomePageModel();
            homeModel.Categories = new List<Category>();
            foreach (var category in categories)
            {
                var entries = new List<Entry>();
                foreach (var entry in category.Entries)
                {
                    entries.Add(new Entry
                    {
                        Id = entry.Id,
                        Title = entry.Title,
                        Content = entry.Content
                    });
                }

                homeModel.Categories.Add(new Category
                {
                    Id = category.Id,
                    Title = category.Title,
                    EntriesCounter = entries.Count(),
                    Entires = entries
                });
            }

            return View(homeModel); ;
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
