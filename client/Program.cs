using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Read environment variables set in Render
var apiBaseUrl = Environment.GetEnvironmentVariable("API_BASE_URL"); // fallback

var supabaseUrl = Environment.GetEnvironmentVariable("SUPABASE_URL");

var supabaseAnonKey = Environment.GetEnvironmentVariable("SUPABASE_ANON_KEY");

// Set up HttpClient for the live API
builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri(apiBaseUrl) });

// Make Supabase info available throughout the app
builder.Configuration["SUPABASE_URL"] = supabaseUrl;
builder.Configuration["SUPABASE_ANON_KEY"] = supabaseAnonKey;

// Test endpoints
app.MapGet("/", () => "API is running");
app.MapGet("/healthz", () => Results.Ok("Healthy"));

await builder.Build().RunAsync();
