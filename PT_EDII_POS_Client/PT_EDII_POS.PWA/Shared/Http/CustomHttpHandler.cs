using Blazored.LocalStorage;

namespace PT_EDII_POS.PWA.Shared.Http;

public class CustomHttpHandler(ILocalStorageService _storage) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (request.RequestUri.AbsolutePath.Contains("login", StringComparison.CurrentCultureIgnoreCase) ||
            request.RequestUri.AbsolutePath.Contains("register", StringComparison.CurrentCultureIgnoreCase))
        {
            return await base.SendAsync(request, cancellationToken);
        }

        var token = await _storage.GetItemAsync<string>("bearer");
        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Add("Authorization", $"Bearer {token}");
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
