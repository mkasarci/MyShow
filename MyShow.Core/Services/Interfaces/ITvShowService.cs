namespace MyShow.Core.Services.Interfaces;
public interface ITvShowService
{
    Task<string> GetTvShowByName(string name);
}
