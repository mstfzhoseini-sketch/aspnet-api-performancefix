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

        [HttpGet("fast-data")]
        public async Task<IActionResult> GetFastData()
        {
            // ✅ async non-blocking
            await Task.Delay(300);

            var data = Enumerable.Range(0, 10000)
                                 .Select(i => $"Item {i}")
                                 .ToList();

            return Ok(data);
        }

    }
}
