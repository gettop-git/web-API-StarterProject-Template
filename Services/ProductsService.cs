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
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await repo.GetAllProducts();
        }
    }
}
