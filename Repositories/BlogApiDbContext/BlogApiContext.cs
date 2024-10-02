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
       
    }
}
