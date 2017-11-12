using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuto.Data;
using Tuto.Data.Models;
using TutoDataRepo;

namespace Tuto.Repo
{
    public class SqlTutoRepo : ITudoDataRepository
    {
        private readonly TutoContext _tutoContext;
        public SqlTutoRepo(TutoContext tutoContext)
        {
            _tutoContext = tutoContext;
        }
        public Task<List<Category>> GetAllCategories()
        {
            var categories =  _tutoContext.Category
                .Include(e => e.Entries)
                .ToList();
            return Task.FromResult(categories);
        }

        public Task<List<Link>> GetAllLinks()
        {
            var links = _tutoContext.Link.ToList();
            return Task.FromResult(links);
        }

        public Category GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Entry> GetEntryById(int? id)
        {
            var entryPart = _tutoContext.Entry
                .Include(c => c.Category)
                .FirstOrDefault(e => e.Id.Equals(id));
            return Task.FromResult(entryPart);
        }

        public Task<List<Entry>> GetAllEntries()
        {
            var entries = _tutoContext.Entry.ToList();
            return Task.FromResult(entries);
        }

        public Task<string> GetGoogleAnalyticsKey()
        {
            string googleKey = _tutoContext.WebsiteDetails.Select(x => x.GoogleAnalyticsCode).FirstOrDefault();
            return Task.FromResult(googleKey);
           
        }

        public Task<HomePageSettings> GetHomePageSettings()
        {
            var homePageSettings = _tutoContext.HomePageSettings.SingleOrDefault();
            return Task.FromResult(homePageSettings);
        }

        public Task<WebsiteDetails> GetWebsiteDetails()
        {
            var websiteDetails = _tutoContext.WebsiteDetails.SingleOrDefault();
            return Task.FromResult(websiteDetails);
        }
    }
}
