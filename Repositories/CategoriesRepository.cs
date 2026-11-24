using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        MyStorDBContext _context;
        public CategoriesRepository(MyStorDBContext _context)
        {
            this._context = _context;

        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
