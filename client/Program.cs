using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using client;
using System.Net.Http;
using Supabase;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Root components
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// ----------------------
// Configuration (hardcoded)
// ----------------------

// Your API URL
var apiBaseUrl = "https://helloapp-liveapi.onrender.com";

// Your Supabase info
var supabaseUrl = "https://tghkupnleutlklclixtp.supabase.co";
var supabaseAnonKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InRnaGt1cG5sZXV0bGtsY2xpeHRwIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NjEyMjk4NTcsImV4cCI6MjA3NjgwNTg1N30.HzhHzhDLetjn1ULjhfQDDHj7BVNp5Yv-03tTwYgPEW4";

// ----------------------
// Services
// ----------------------

// HttpClient for API requests
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });

// If you’re using Supabase client library, register it as a singleton
builder.Services.AddSingleton(new Supabase.Client(supabaseUrl, supabaseAnonKey));

// ----------------------
// Run
// ----------------------
await builder.Build().RunAsync();
