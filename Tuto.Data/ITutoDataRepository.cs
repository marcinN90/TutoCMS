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
    }
}
