using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class ProductsRepository : IProductsRepository
    {

      MyStorDBContext _context;
        public ProductsRepository(MyStorDBContext _context)
        {
            this._context = _context;

        }  
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
