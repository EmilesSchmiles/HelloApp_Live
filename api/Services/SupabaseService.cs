using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HelloApp.Api.Services
{
    public class SupabaseService
    {
        private readonly HttpClient _httpClient;
        private const string SupabaseUrl = "https://tghkupnleutlklclixtp.supabase.co";
        private const string SupabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InRnaGt1cG5sZXV0bGtsY2xpeHRwIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NjEyMjk4NTcsImV4cCI6MjA3NjgwNTg1N30.HzhHzhDLetjn1ULjhfQDDHj7BVNp5Yv-03tTwYgPEW4";

        public SupabaseService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri(SupabaseUrl);
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", SupabaseKey);
            
            _httpClient.DefaultRequestHeaders.Add("apikey", SupabaseKey);

            _httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<string?> GetGreetingAsync()
        {
            var url = "/rest/v1/tblGreetings?select=Name";
            var response = await _httpClient.GetFromJsonAsync<GreetingResponse[]>(url);

            return response?.Length > 0 ? response[0].Name : null;
        }

        public class GreetingResponse
        {
            public string Name { get; set; } = string.Empty;
        }
    }
}
