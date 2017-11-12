using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuto.Data.Models;
using TutoDataRepo;

namespace Tuto.UI.Controllers.Admin
{
    public class WebSiteDetailsController : Controller
    {
        private readonly ITudoDataRepository _repo;
        public WebSiteDetailsController(ITudoDataRepository repo)
        {
            _repo = repo;
        }

        public async Task <IActionResult> Index()
        {
            WebsiteDetails webDetails = await _repo.GetWebsiteDetails();
            return View(webDetails);
        }
    }
}
