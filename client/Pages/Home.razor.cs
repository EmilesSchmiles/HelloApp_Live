using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HelloApp.Pages
{
    public partial class Home : ComponentBase
    {
        [Inject]
        private HttpClient Http { get; set; } = default!;

        protected string message = "";

        protected async Task GetNameFromApi()
        {
            // Point to your live API
            var response = await Http.GetFromJsonAsync<NameResponse>("https://helloapp-liveapi.onrender.com/Greetings");

            message = response?.Name != null ? $"Hello {response.Name}" : "No name returned";
        }

        public class NameResponse
        {
            public string Name { get; set; } = string.Empty;
        }
    }
}
