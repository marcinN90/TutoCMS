﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tuto.Data.Models;

namespace TutoDataRepo
{
    public interface ITudoDataRepository
    {
        Task<List<Category>> GetAllCategories();
        Category GetCategoryById(int id);
        Task<WebsiteDetails> GetWebsiteDetails();
        Task<HomePageSettings> GetHomePageSettings();
        Task<Entry> GetEntryById(int? id);
        Task<List<Entry>> GetAllEntries();
        Task<List<Link>> GetAllLinks();
        Task<Link> GetLinkById(int id);
        Task<string> GetGoogleAnalyticsKey();

        Task SaveWebsiteDetails(WebsiteDetails websiteDetails);
        Task SaveLink(Link editedLink);
        Task CreateLink(Link linkToCreate);

        Task DeleteLink(int id);
    }
}
