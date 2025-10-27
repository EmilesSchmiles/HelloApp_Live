using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using client;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// API URL - hardcoded because your API is stable
var apiBaseUrl = "https://helloapp-liveapi.onrender.com";

// Read Supabase info from configuration (set as environment variables in Netlify)
var supabaseUrl = builder.Configuration["SUPABASE_URL"] ?? throw new InvalidOperationException(
    "SUPABASE_URL environment variable is not set.");
var supabaseAnonKey = builder.Configuration["SUPABASE_ANON_KEY"] ?? throw new InvalidOperationException(
    "SUPABASE_ANON_KEY environment variable is not set.");

// Configure HttpClient for API requests
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });

// Make Supabase info available throughout the app
builder.Configuration["SUPABASE_URL"] = "https://tghkupnleutlklclixtp.supabase.co";
builder.Configuration["SUPABASE_ANON_KEY"] = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InRnaGt1cG5sZXV0bGtsY2xpeHRwIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NjEyMjk4NTcsImV4cCI6MjA3NjgwNTg1N30.HzhHzhDLetjn1ULjhfQDDHj7BVNp5Yv-03tTwYgPEW4";

await builder.Build().RunAsync();
