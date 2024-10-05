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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BlogApiContext _context;

        public CategoryRepository(BlogApiContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category entity)
        {
            await _context.Categories.AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Categories.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentException("Id Bulunamadı");
            }
            _context.Categories.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var entity = _context.Categories.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentException("Id bulunmamaktadır.");
            }
            return await entity;
        }

        public async Task<Category> GetCategoryWithBlogPostsAsync(int categoryId)
        {
            return await _context.Categories
                .Include(c => c.BlogPosts)
                .FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        }

        public async Task UpdateAsync(Category entity)
        {
           _context.Categories.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
