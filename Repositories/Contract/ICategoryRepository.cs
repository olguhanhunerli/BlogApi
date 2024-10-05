using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        
        Task<Category> GetCategoryWithBlogPostsAsync(int categoryId);
    }
}
