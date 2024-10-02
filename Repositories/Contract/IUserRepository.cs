using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contract
{
    public interface IUserRepository
    {
        Task<Users> GetUserByEmail(string email);
        Task AddUser(Users user);
    }
}
