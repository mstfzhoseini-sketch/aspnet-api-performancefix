using Microsoft.AspNetCore.Mvc;

namespace ApiPerformanceDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SlowController : ControllerBase
    {
        [HttpGet("slow-data")]
        public IActionResult GetSlowData()
        {
         
            Thread.Sleep(3000); // 3 seconds blocking

            var data = new List<string>();

            for (int i = 0; i < 10000; i++)
            {
                data.Add("Item " + i);
            }

            return Ok(data);
        }
    }
}
