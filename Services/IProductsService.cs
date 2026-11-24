using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllProducts();
    }
}
