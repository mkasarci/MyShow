using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MyShow.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}
