using Microsoft.AspNetCore.Mvc;

namespace MeisterLuisLB_295_TODO.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TODOController : ControllerBase
    {
        [HttpGet(Name = "GetInteger")]
        public int Get()
        {
            return 100;
        }
    }
}
