using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IBlogPostService
    {
        Task<IEnumerable<BlogPost>> GetAllPostsAsync();
        Task AddBlogPostAsync(BlogPost blogPost);
        Task DeleteBlogPostAsync(int id);
        Task UpdateBlogPostASync(BlogPost blogPost);
    }
}
