using Microsoft.AspNetCore.Mvc;

namespace OnBoarding.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OnBoardingController : ControllerBase
    {
        private readonly ILogger<OnBoardingController> _logger;

        public OnBoardingController(ILogger<OnBoardingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "hello from on boarding";
        }
    }
}