using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.BlogApiDbContext
{
    public class BlogApiContext : DbContext
    {
        public BlogApiContext(DbContextOptions<BlogApiContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Assets> Assets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BlogPost> BlogPost { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BlogPost>()
                .HasMany(b => b.Assets)
                .WithOne(a => a.BlogPost)
                .HasForeignKey(a => a.BlogPostId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Category>()
                .HasMany(b=> b.BlogPosts)
                .WithOne(a => a.Category)
                .HasForeignKey(b=> b.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
 
        }
        
    }
}
