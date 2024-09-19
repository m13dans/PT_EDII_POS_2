using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using PT_EDII_POS.PWA;
using PT_EDII_POS.PWA.Shared.Http;
using PT_EDII_POS.PWA.Shared.Provider;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CustomHttpHandler>();
builder.Services.AddHttpClient("PosAPI", option =>
{
	option.BaseAddress = new Uri("https://localhost:7260/");
}).AddHttpMessageHandler<CustomHttpHandler>();


//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7260/") });

await builder.Build().RunAsync();
