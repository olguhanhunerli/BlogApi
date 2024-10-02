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
    public class UserRepository : IUserRepository
    {
        private readonly BlogApiContext _context;

        public UserRepository(BlogApiContext context)
        {
            _context = context;
        }

        public async Task AddUser(Users user)
        {

            await _context.Users.AddAsync(user);
            _context.SaveChanges();
        }

        public async Task<Users> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
