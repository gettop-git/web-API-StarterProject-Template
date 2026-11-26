using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Repositories
{
    public class ProductsRepository : IProductsRepository
    {

      MyStorDBContext _context;
        public ProductsRepository(MyStorDBContext _context)
        {
            this._context = _context;

        }  
        public async Task<IEnumerable<Product>> GetAllProducts(string? name, int? minPrice, int? maxPrice, string? desc, int[]? categoriesId, int position = 1, int skip = 8)
        {

          

             //var query = _context.Products.Where(product =>
             //           (desc == null ? (true) : (product.Description.Contains(desc)))
             //           && (name == null ? (true) : (product.ProductName.Contains(name)))
             //     && ((minPrice == null) ? (true) : (product.Price >= minPrice))
             //    && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
             //    && ((categoriesId.Length == 0) ? (true) : (categoriesId.Contains(product.CategoryId))))
             //   .OrderBy(product => product.Price).ToListAsync();

            //Console.WriteLine(query.ToQueryString());
            //List<Product> products = await query.Skip((position - 1) * skip)
            //  Take(skip).Include(product => product.Category).ToListAsync();
            //var total = await query.CountAsync();
            //return (products, total);
            return await _context.Products.Where(product =>
                        (desc == null ? (true) : (product.Description.Contains(desc)))
                        && (name == null ? (true) : (product.ProductName.Contains(name)))
                  && ((minPrice == null) ? (true) : (product.Price >= minPrice))
                 && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
                 && ((categoriesId.Length == 0) ? (true) : (categoriesId.Contains(product.CategoryId))))
                .OrderBy(product => product.Price).ToListAsync();
        }
    }
}
