using MyShow.Data.Services.Interfaces;

namespace MyShow.Data.Services;

public class MazeTvShowService : ITvShowService
{
    private readonly HttpClient _httpClient;

    public MazeTvShowService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    //https://api.tvmaze.com/singlesearch/shows?q=DC%27s Legends of Tomorrow&embed=nextepisode
    public async Task<string> GetTvShowByName(string name)
    {
        var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
        {
            Scheme = "https",
            Path = "/singlesearch/shows",
            Query = $"q={name}&embed=nextepisode"
        };

        var response = await _httpClient.GetAsync(uriBuilder.Uri);

        if (response is null) 
            return null;

        var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        return responseBody;
    }
}
