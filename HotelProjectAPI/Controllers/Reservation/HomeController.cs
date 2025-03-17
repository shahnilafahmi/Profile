using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Controllers.Reservation
{
    [Route("api/Reservation/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("Home")]
        public Task<int> Index()
        
        {
            return null;
        }
    }
}
