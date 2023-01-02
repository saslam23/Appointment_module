using appointment_module_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace appointment_module_api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ServicesController : Controller
    {
        [HttpGet("businessServices")]
        public async Task<ActionResult<List<BusinessServices>>> Get() {
            return Ok("route to get services for a business");
        }
    }
}
