using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class CategoriesService : ICategoriesService
    {
        ICategoriesRepository repo;
        public CategoriesService(ICategoriesRepository repository)
        {
            this.repo = repository;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await repo.GetAllCategories();
        }
    }
}
