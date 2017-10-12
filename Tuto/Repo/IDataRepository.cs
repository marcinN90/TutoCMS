using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuto.Models;

namespace Tuto.Repo
{
    public interface IDataRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
    }
}
