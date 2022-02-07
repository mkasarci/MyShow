using AutoMapper;
using MyShow.Data.Services.Interfaces;

namespace MyShow.Data.Services.Maze;

public class MazeTvShowService : ITvShowService
{
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;

    public MazeTvShowService(HttpClient httpClient, IMapper mapper)
    {
        _httpClient = httpClient;
        _mapper = mapper;
    }

    //https://api.tvmaze.com/singlesearch/shows?q=DC%27s Legends of Tomorrow&embed=nextepisode
    public async Task<TvShow> GetTvShowByName(string name)
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
        return _mapper.Map<TvShow>(responseBody);
    }
}