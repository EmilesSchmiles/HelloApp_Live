using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using client;
using Supabase;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Hardcoded API URL
var apiBaseUrl = "https://helloapp-liveapi.onrender.com";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });

// Hardcoded Supabase info
var supabaseUrl = "https://tghkupnleutlklclixtp.supabase.co";
var supabaseAnonKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InRnaGt1cG5sZXV0bGtsY2xpeHRwIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NjEyMjk4NTcsImV4cCI6MjA3NjgwNTg1N30.HzhHzhDLetjn1ULjhfQDDHj7BVNp5Yv-03tTwYgPEW4";

// Initialize Supabase client asynchronously
var supabaseClient = new Supabase.Client(supabaseUrl, supabaseAnonKey);
await supabaseClient.InitializeAsync(); // This MUST happen before injecting
builder.Services.AddSingleton(supabaseClient);

await builder.Build().RunAsync();
