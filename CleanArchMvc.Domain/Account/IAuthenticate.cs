using System;
using System.Threading.Tasks;
using System.Linq;

namespace CleanArchMvc.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string email, string password);

        Task<bool> RegisterUser(string email, string password);

        Task Logout();

    }
}