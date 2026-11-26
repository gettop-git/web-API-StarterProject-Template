using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ProductsService : IProductsService
    {
        IProductsRepository repo;
        public ProductsService(IProductsRepository repository)
        {
            this.repo = repository;
        }
        public async Task<IEnumerable<Product>> GetAllProducts(string? name, int? minPrice, int? maxPrice, string? desc,  int[]? categoriesId, int position = 1, int skip = 8)
        {
            return await repo.GetAllProducts(name, minPrice, maxPrice, desc, categoriesId, position, skip);
        }
    }
}
