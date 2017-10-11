using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoCMS.Models;

namespace TutoCMS.Repo
{
    public interface IDataRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
    }
}
