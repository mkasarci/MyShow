using Polly;
using Polly.Extensions.Http;
using System.Net;

namespace MyShow.MVC.Policies;

public static class PolicyHandler
{
    public static IAsyncPolicy<HttpResponseMessage> WaitAndRetry()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
            .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    }

    public static IAsyncPolicy<HttpResponseMessage> Timeout(int seconds = 2)
    {
        return Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(seconds));
    }
}
