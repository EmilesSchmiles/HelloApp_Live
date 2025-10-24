using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HelloApp.Pages
{
    public partial class Weather : ComponentBase
    {
        [Inject]
        private HttpClient Http { get; set; } = default!;

        protected WeatherForecast[]? forecasts;

        protected override async Task OnInitializedAsync()
        {
            forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("https://localhost:7243/WeatherForecast");
        }

        public class WeatherForecast
        {
            public DateTime Date { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; } = string.Empty;
            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        }
    }
}
