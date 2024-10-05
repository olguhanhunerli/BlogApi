using Entities.Models;
using Repositories.BlogApiDbContext;
using Repositories.Contract;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryServices : ICategoryService
    {
        private readonly ICategoryRepository _context;

        public CategoryServices(ICategoryRepository context)
        {
            _context = context;
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _context.AddAsync(category);
           
            
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _context.DeleteAsync(id);
            
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _context.GetAllAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
           _context.UpdateAsync(category);
        }
    }
}
