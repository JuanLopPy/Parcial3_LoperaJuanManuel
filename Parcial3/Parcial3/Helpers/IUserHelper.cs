using Microsoft.AspNetCore.Identity;
using Parcial3.DAL.Entities;
using Parcial3.Models;
using Microsoft.AspNetCore.Identity;
using ECommerce_Sat.Models;

namespace Parcial3.Helpers
{
    public interface IUserHelper
    {

        Task<User> GetUserAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

       // Task<User> AddUserAsync(AddUserViewModel addUserViewModel);

        Task AddRoleAsync(string roleName); 

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel loginViewModel);

        Task LogoutAsync();

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<User> GetUserAsync(Guid userId);
        Task<User> AddUserAsync(AddUserViewModel addUserViewModel);
    }
}
