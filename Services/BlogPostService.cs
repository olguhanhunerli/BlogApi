using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Repositories.Contract;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _context;

        public BlogPostService(IBlogPostRepository context)
        {
            _context = context;
        }

        public async Task AddBlogPostAsync(BlogPost blogPost)
        {
            await _context.AddAsync(blogPost);
        }

        public async Task DeleteBlogPostAsync(int id)
        {
            var entity = _context.DeleteAsync(id);
            if (entity == null)
            {
                throw new Exception("Id Bulunamadı");
            }
            await _context.DeleteAsync(id);
        }

        public async Task<IEnumerable<BlogPost>> GetAllPostsAsync()
        {
            return await _context.GetAllAsync();
        }

        public async Task UpdateBlogPostASync(BlogPost blogPost)
        {
            await _context.UpdateAsync(blogPost);
        }
    }
}
