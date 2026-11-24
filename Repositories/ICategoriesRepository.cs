using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
    }
}
