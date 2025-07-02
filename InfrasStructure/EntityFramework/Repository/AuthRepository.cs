using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Entities.Base;
using Application.Interface.IRepositories;
using Microsoft.AspNetCore.Identity;

namespace InfrasStructure.EntityFramework.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<User> _userManager;

        public AuthRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(User user, string password)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrEmpty(password)) throw new ArgumentException("Password cannot be null or empty", nameof(password));
            
            var result = await _userManager.CreateAsync(user, password);
            
            return result;
        }

        

        public async Task<User?> FindByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new ArgumentException("Email cannot be null or empty", nameof(email));
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<User?> FindByIdAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId)) throw new ArgumentException("UserId cannot be null or empty", nameof(userId));

            var user = await _userManager.FindByIdAsync(userId);

            return user;
        }

        public async Task<User?> FindByUserNameAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName)) throw new ArgumentException("UserName cannot be null or empty", nameof(userName));
            
            var user = await _userManager.FindByNameAsync(userName);
            
            return user;
        }

        public async Task<IdentityResult> AddRolesAsync(User user, string[] roles)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            if (roles == null || !roles.Any()) throw new ArgumentException("Roles cannot be null or empty", nameof(roles));

            var result = await _userManager.AddToRolesAsync(user, roles);

            return result;
        }

        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            
            if (string.IsNullOrEmpty(password)) throw new ArgumentException("Password cannot be null or empty", nameof(password));
            
            var result = await _userManager.CheckPasswordAsync(user, password);

            return result;
        }

        public async Task<IList<string>> GetRolesAsync(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            var roles = await _userManager.GetRolesAsync(user);
            return roles;
        }
    }
}
