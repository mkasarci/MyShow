using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MyShow.Data;

public class AppDbContext : IdentityDbContext<User>
{
    public DbSet<TvShow> TvShows { get; set; }
    public DbSet<UserTvShow> UserTvShows { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<UserTvShow>()
            .HasKey(x => new { x.UserId, x.TvShowId });

        builder.Entity<Episode>()
            .ToTable("Episodes");
    }
}
