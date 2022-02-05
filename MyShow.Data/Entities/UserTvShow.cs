namespace MyShow.Data.Entities;

public class UserTvShow
{
    public string UserId { get; set; }
    public int TvShowId { get; set; }
    public TvShow TvShow { get; set; }
}
