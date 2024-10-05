using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contract
{
    public interface IBlogPostRepository : IRepository<BlogPost>
    {
        Task<IEnumerable<BlogPost>> GetBlogPostsByCategoryIdAsync(int categoryId);
    }
}
