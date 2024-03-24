using Blazored.SessionStorage;
using Blazored.Toast;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PoryectoSistemaTransporte.Client;
using PoryectoSistemaTransporte.Client.Auth;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddBlazoredSessionStorage();

//habilitamos el contexto de seguridad de blazor
builder.Services.AddScoped<AuthenticationStateProvider, AutenticacionService>();
builder.Services.AddAuthorizationCore();

builder.Services.AddBlazoredToast();
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
