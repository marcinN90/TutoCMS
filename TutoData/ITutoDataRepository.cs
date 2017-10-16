using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TutoData.Models;

namespace TutoDataRepo
{
    public interface ITudoDataRepository
    {
        Task<List<Category>> GetAllCategories();
        Category GetCategoryById(int id);
    }
}
