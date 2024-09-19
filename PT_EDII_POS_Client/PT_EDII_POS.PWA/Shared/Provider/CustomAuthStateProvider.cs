using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;

namespace PT_EDII_POS.PWA.Shared.Provider;

public class CustomAuthStateProvider(ILocalStorageService _storage) : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        string? jwtToken = await _storage.GetItemAsync<string>("bearer");
        if (string.IsNullOrEmpty(jwtToken))
            return new AuthenticationState(
                new ClaimsPrincipal());

        return new AuthenticationState(
            new ClaimsPrincipal(new ClaimsIdentity(ParseClaimFromJwt(jwtToken), "JwtAuth")));

    }
    private static IEnumerable<Claim> ParseClaimFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonByte = ParseBase64WithoutPadding(payload);
        var keyValuePair = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonByte);
        return keyValuePair.Select(x => new Claim(x.Key, x.Value.ToString()));

    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        var result = base64.Length % 4;
        var character = result switch
        {
            2 => "==",
            3 => "=",
            _ => ""
        };
        return Convert.FromBase64String(base64 + character);
    }

    public void NotifyAuthState()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
