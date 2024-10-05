using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoryAsync();
        Task AddCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
        Task UpdateCategoryAsync(Category category);
    }
}
