using Microsoft.AspNetCore.Identity;

namespace MyShow.Data.Entities;

public class User : IdentityUser
{
    public ICollection<UserTvShow> UserTvShows { get; set; }
}
