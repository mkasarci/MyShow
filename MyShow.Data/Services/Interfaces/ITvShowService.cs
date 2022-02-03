namespace MyShow.Data.Services.Interfaces;
public interface ITvShowService
{
    Task<string> GetTvShowByName(string name);
}
