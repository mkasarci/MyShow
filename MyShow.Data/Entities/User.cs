using Microsoft.AspNetCore.Identity;

namespace MyShow.Data.Entities;

public class User : IdentityUser
{
    public List<UserTvShow> UserTvShows { get; set; }
}
