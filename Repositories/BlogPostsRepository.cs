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
        public async Task AddAsync(BlogPost entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = _context.BlogPost.FindAsync(id);
            if (entity == null)
            {
                throw new Exception("Kayıt Bulunamadı");
            }
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await _context.BlogPost.ToListAsync();
        }

        public async Task<IEnumerable<BlogPost>> GetBlogPostsByCategoryIdAsync(int categoryId)
        {
            return await _context.BlogPost
                .Where(b => b.CategoryId == categoryId).ToListAsync();  
        }

        public async Task<BlogPost> GetByIdAsync(int id)
        {
            return await _context.BlogPost.FindAsync(id);
        }

        public async Task UpdateAsync(BlogPost entity)
        {
            _context.BlogPost.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
