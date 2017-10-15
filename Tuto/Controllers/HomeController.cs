using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tuto.Models;
using Tuto.Repo;
using TutoData;

namespace Tuto.Controllers
{
    public class HomeController : Controller
    {
        public ITudoDataServce _dataService;
        public HomeController(ITudoDataServce dataService)
        {
            _dataService = dataService;
        }

        public async Task<IActionResult> Index()
        {

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
