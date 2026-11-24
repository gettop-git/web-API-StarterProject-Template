using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
    }
}
