using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tuto.Models;
using Tuto.Repo;

namespace Tuto.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataRepository _dataRepo;
        public HomeController(IDataRepository dataRepository)
        {
            _dataRepo = dataRepository;
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
