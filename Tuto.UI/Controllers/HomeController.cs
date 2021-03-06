﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Tuto.UI.Models;
using TutoDataRepo;
using System.Threading.Tasks;
using Tuto.UI.Models.DTOModels;

namespace Tuto.UI.Controllers
{
    public class HomeController : Controller
    {
        ITudoDataRepository repository;
        public HomeController(ITudoDataRepository repo)
        {
            repository = repo;
        }
        public async Task<IActionResult> Index()
        {
            var webDetails = await repository.GetWebsiteDetails();
            var homePageSettings = await repository.GetHomePageSettings(); 
            var categories = await repository.GetAllCategories();
         
            HomePageViewModel homeModel = new HomePageViewModel();

            homeModel.WebSiteName = webDetails.Name;
            homeModel.HomePageTitle = homePageSettings.Title;
            homeModel.SeoDescription = homePageSettings.SeoDescription;
            homeModel.Description = homePageSettings.Descritpion;
            homeModel.GoogleCode = await repository.GetGoogleAnalyticsKey();

            homeModel.Categories = new List<CategoryDTO>();
            foreach (var category in categories)
            {
                var entries = new List<EntryDTO>();
                foreach (var entry in category.Entries)
                {
                    entries.Add(new EntryDTO
                    {
                        Id = entry.Id,
                        Title = entry.Title
                    });
                }

                homeModel.Categories.Add(new CategoryDTO
                {
                    Id = category.Id,
                    Title = category.Title,
                    Entires = entries
                });
            }
            var links = await repository.GetAllLinks();
            var linksDTO = new List<LinkDTO>();
            foreach (var link in links)
            {
                linksDTO.Add(new LinkDTO
                {
                    LinkTitle = link.LinkTitle,
                    UrlAddress = link.UrlAddress
                });
            }
            homeModel.Links = linksDTO;


            return View(homeModel); ;
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
