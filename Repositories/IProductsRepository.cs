using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetAllProducts(string? name, int? minPrice, int? maxPrice, string? desc, int[]? categoriesId, int position = 1, int skip = 8);
    }
}
