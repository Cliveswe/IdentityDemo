using IdentityDemo.Application.Dtos;
using IdentityDemo.Application.Users;
using IdentityDemo.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace IdentityDemo.Infrastructure.Services;
public class IdentityUserService(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager) : IIdentityUserService
{

    public async Task<UserResultDto> CreateUserAsync(UserProfileDto user, string password) {
        var result = await userManager.CreateAsync(new ApplicationUser {
            UserName = user.Email,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName
        }, password);
        return new UserResultDto(result.Errors.FirstOrDefault()?.Description);
    }

    public async Task<UserResultDto> SignInAsync(string email, string password, bool isPersistent, bool lockoutOnFailure) {
        var result = await signInManager.PasswordSignInAsync(email, password, isPersistent, lockoutOnFailure);
        return new UserResultDto(result.Succeeded ? null : "Invalid user credentials");
    }

}
