using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IUserServices
    {
        Task RegisterAsync(string userName,string email,string password);
        Task<string> LoginAsync(string userName,string password);
    }
}
