using IdentityDemo.Application.Dtos;
using IdentityDemo.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace IdentityDemo.Infrastructure.Services;
internal class IdentityUserService(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager)
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

}
