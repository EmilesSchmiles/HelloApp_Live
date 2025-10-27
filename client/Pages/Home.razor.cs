using Microsoft.AspNetCore.Components;
using Supabase;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HelloApp.Pages
{
    public partial class Home : ComponentBase
    {
        [Inject]
        private HttpClient Http { get; set; } = default!;

        // Inject the Supabase client as a Task to ensure it's initialized
        [Inject]
        private Task<Client> SupabaseClientTask { get; set; } = default!;

        protected string message = "";

        // This method is only called when the user clicks the button
        protected async Task GetNameFromApi()
        {
            try
            {
                var response = await Http.GetFromJsonAsync<NameResponse>(
                    "https://helloapp-liveapi.onrender.com/Greetings");

                message = response?.Name != null ? $"Hello {response.Name}" : "No name returned";
            }
            catch
            {
                message = "Error calling API";
            }
        }
        
        public class NameResponse
        {
            public string Name { get; set; } = string.Empty;
        }

        // Example Supabase table class
        public class User
        {
            public string Id { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
        }
    }
}
