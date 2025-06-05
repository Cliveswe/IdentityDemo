using IdentityDemo.Application.Users;

namespace IdentityDemo.Infrastructure.Persistence;
public class ApplicationUser : IIdentityUser

{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

}
