using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Controllers.Master
{
    [Route("api/Master/[controller]")]
    [ApiController]
    public class CompanyMasterController : ControllerBase
    {
        [HttpGet("test")]
        public Task<int> Index()
        {
            return null;
        }
    }
}
