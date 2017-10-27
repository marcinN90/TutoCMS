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
            var categories =  _tutoContext.Category.ToList();
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
            throw new NotImplementedException();
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
