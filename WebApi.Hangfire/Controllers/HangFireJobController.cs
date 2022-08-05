using Hangfire;
using Microsoft.AspNetCore.Mvc;
using WebApi.Hangfire.Jobs;

namespace WebApi.Hangfire.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HangFireJobController : ControllerBase
    {
        private readonly ILogger<HangFireJobController> _logger;

        public HangFireJobController(ILogger<HangFireJobController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("FireAndForget")]
        public string FireAndForgetJob()
        {
            var jobId = BackgroundJob.Enqueue(() => JobFireAndForget.Run());
            return jobId;
        }




        [HttpGet]
        [Route("Delayed")]
        public string DelayedJob()
        {
            var id = BackgroundJob.Schedule(() => JobDelayed.Run(), TimeSpan.FromSeconds(85));
            return id;
        }



    }
}
