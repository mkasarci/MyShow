using MyShow.Data.Services.Interfaces;
using MyShow.Data.Entities;
using System.Net.Mime;
using System.Text;

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
        var uri = new UriBuilder(_httpClient.BaseAddress)
        {
            Scheme = "https",
            Path = "/singlesearch/shows",
            Query = $"q={name}&embed=nextepisode"
        };

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = uri.Uri,
            Content = new StringContent("some json", Encoding.UTF8, MediaTypeNames.Application.Json),
        };

        var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        return responseBody;
    }
}
