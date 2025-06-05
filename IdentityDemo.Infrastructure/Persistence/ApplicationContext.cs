using Microsoft.EntityFrameworkCore;

namespace IdentityDemo.Infrastructure.Persistence;

public class ApplicationContext(DbContextOptions<ApplicationContext> options)
    : DbContext(options)
{


}

