// Home.razor.cs
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HelloApp.Pages   // <- IMPORTANT: must match your project/namespace
{
    public partial class Home : ComponentBase
    {
        [Inject]
        private HttpClient Http { get; set; } = default!; // ensures non-null

        protected string message = "";

        protected async Task GetNameFromApi()
        {
            var response = await Http.GetFromJsonAsync<NameResponse>("http://localhost:5174/Greetings");
            message = "Hello " + response?.Name;
        }

        public class NameResponse
        {
            public string Name { get; set; } = string.Empty;
        }
    }
}
