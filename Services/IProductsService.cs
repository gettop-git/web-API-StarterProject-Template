using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllProducts(string? name, int? minPrice, int? maxPrice, string? desc,  int[]? categoriesId, int position = 1, int skip = 8);
    }
}
