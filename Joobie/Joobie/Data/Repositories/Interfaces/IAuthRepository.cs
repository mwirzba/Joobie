using Joobie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Joobie.Data.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string Password);

        Task<User> Login(User username, string Password);

        Task<bool> UserExists(User username);
    }
}
