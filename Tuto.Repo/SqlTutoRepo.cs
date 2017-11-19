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

        public async Task <List<Image>> GetAllImages()
        {
            return await _tutoContext.Image.ToListAsync();
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

        public Task<Entry> GetEntryById(int id)
        {
            var entryPart = _tutoContext.EntryPost
                .Include(c => c.Category)
                .FirstOrDefault(e => e.Id.Equals(id));
            return Task.FromResult(entryPart);
        }

        public Task<List<Entry>> GetAllEntries()
        {
            var entries = _tutoContext.EntryPost
                .Include(x => x.Category)
                .ToList();
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

        public Task SaveWebsiteDetails (WebsiteDetails websiteDetails)
        {
            WebsiteDetails dbEntry = _tutoContext.WebsiteDetails.FirstOrDefault(x => x.Id.Equals(1));
            dbEntry.Name = websiteDetails.Name;
            dbEntry.OwnerEmail = websiteDetails.OwnerEmail;
            dbEntry.GoogleAnalyticsCode = websiteDetails.GoogleAnalyticsCode;
            _tutoContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task CreateLink (Link linkToCreate)
        {
            _tutoContext.Link.Add(linkToCreate);
            _tutoContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task SaveLink (Link editedLink)
        {
            Link dbEntry = _tutoContext.Link.FirstOrDefault(x => x.Id.Equals(editedLink.Id));
            dbEntry.LinkTitle = editedLink.LinkTitle;
            dbEntry.UrlAddress = editedLink.UrlAddress;

            _tutoContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task SaveEntry (Entry editedEntry)
        {
            Entry dbEntry = _tutoContext.EntryPost.FirstOrDefault(x => x.Id.Equals(editedEntry.Id));
            dbEntry.Title = editedEntry.Title;
            dbEntry.SeoDescription = editedEntry.SeoDescription;
            dbEntry.CategoryId = editedEntry.CategoryId;
            dbEntry.Content = editedEntry.Content;
            dbEntry.LastRevisionAt = editedEntry.LastRevisionAt;

            _tutoContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<Link> GetLinkById (int id)
        {
            var link = _tutoContext.Link.FirstOrDefault(x => x.Id.Equals(id));
            return Task.FromResult(link);
        }

        public Task DeleteLink (int id)
        {
            var link = _tutoContext.Link.FirstOrDefault(x => x.Id.Equals(id));
            _tutoContext.Link.Remove(link);
            _tutoContext.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task CreateEntry(Entry entry)
        {
            _tutoContext.EntryPost.Add(entry);
            await _tutoContext.SaveChangesAsync();
        }

        public async Task DeleteEntry(int id)
        {
            var entry = _tutoContext.EntryPost.FirstOrDefault(x => x.Id.Equals(id));
            _tutoContext.EntryPost.Remove(entry);
            await _tutoContext.SaveChangesAsync();
        }

        public async Task SaveUploadedImage(Image imageToSave)
        {
            _tutoContext.Image.Add(imageToSave);
            await _tutoContext.SaveChangesAsync();
        }

        public async Task<Image> GetImageById(int id)
        {
            var image = await _tutoContext.Image.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return image;
        }
    }
}
