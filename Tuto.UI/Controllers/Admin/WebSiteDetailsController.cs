using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuto.Data.Models;
using TutoDataRepo;

namespace Tuto.UI.Controllers.Admin
{
    [Authorize]
    public class WebSiteDetailsController : Controller
    {
        private readonly ITudoDataRepository _repo;
        public WebSiteDetailsController(ITudoDataRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task <IActionResult> Index()
        {
            WebsiteDetails webDetails = await _repo.GetWebsiteDetails();
            return View(webDetails);
        }

        [HttpPost]
        public async Task <IActionResult> Index(WebsiteDetails webDetails)
        {
            if(ModelState.IsValid)
            {
                await _repo.SaveWebsiteDetails(webDetails);
                TempData["message"] = "Configuration was correctly saved";
            }
            else
            {
                TempData["messge"] = "Error! Configuration not changed";
            }
            return RedirectToAction("Index");

        }
    }
}
