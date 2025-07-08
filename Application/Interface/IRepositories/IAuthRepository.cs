using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace Application.Interface.IRepositories
{
    public interface IAuthRepository
    {
        Task<IdentityResult> CreateUserAsync(User user, string password);
        Task<IdentityResult> CreateAsync(User user);
        Task<IdentityResult> AddRolesAsync(User user, string[] roles);
        Task<User?> FindByEmailAsync(string email);
        Task<User?> FindByIdAsync(string userId);
        Task<User?> FindByUserNameAsync(string userName);
        Task<bool> CheckPasswordAsync(User user, string password);
        Task<IList<string>> GetRolesAsync(User user);
    }
}
