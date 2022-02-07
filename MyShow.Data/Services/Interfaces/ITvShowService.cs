namespace MyShow.Data.Services.Interfaces;
public interface ITvShowService
{
    Task<TvShow> GetTvShowByName(string name);
}
