using Microsoft.AspNetCore.Mvc;
using HelloApp.Api.Services;

namespace HelloApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingsController : ControllerBase
    {
        private readonly SupabaseService _supabase;

        public GreetingsController(SupabaseService supabase)
        {
            _supabase = supabase;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var name = await _supabase.GetGreetingAsync();
            if (name == null) return NotFound();

            return Ok(new { Name = name });
        }
    }
}
