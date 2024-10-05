using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.BlogApiDbContext;
using Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BlogPostsRepository : IBlogPostRepository
    {
        public readonly BlogApiContext _context;

        public BlogPostsRepository(BlogApiContext context)
        {
            _context = context;
        }

        public async Task AddAsync(BlogPost entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.BlogPosts.FindAsync(id);
            if (entity == null)
            {
                throw new Exception("Kayıt Bulunamadı");
            }
            _context.BlogPosts.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            
            return await _context.BlogPosts.ToListAsync();
        }

        public async Task<IEnumerable<BlogPost>> GetBlogPostsByCategoryIdAsync(int categoryId)
        {
            return await _context.BlogPosts
                .Where(b => b.CategoryId == categoryId).ToListAsync();  
        }

        public async Task<BlogPost> GetByIdAsync(int id)
        {
            return await _context.BlogPosts.FindAsync(id);
        }

        public async Task UpdateAsync(BlogPost entity)
        {
            _context.BlogPosts.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
