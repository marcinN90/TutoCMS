using System;
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
        Task<Entry> GetEntryById(int id);
        Task<List<Entry>> GetAllEntries();
        Task<List<Link>> GetAllLinks();
        Task<Link> GetLinkById(int id);
        Task<string> GetGoogleAnalyticsKey();
        Task<List<Image>> GetAllImages();
        Task<Image> GetImageById(int id);

        Task SaveWebsiteDetails(WebsiteDetails websiteDetails);
        Task SaveLink(Link editedLink);
        Task SaveEntry(Entry editedEntry);
        Task SaveUploadedImage(Image imageToSave);
        Task CreateLink(Link linkToCreate);
        Task CreateEntry(Entry entry);

        Task DeleteLink(int id);
        Task DeleteEntry(int id);
    }
}
