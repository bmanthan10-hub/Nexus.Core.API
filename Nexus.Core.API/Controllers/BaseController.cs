using Microsoft.AspNetCore.Mvc;

namespace CoreService.Base.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AssignmentController(IConfiguration config)
        {
            _config = config;
        }

        //  WELCOME ENDPOINT
        [HttpGet("welcome")]
        public IActionResult GetWelcomeMessage()
        {
            var message = _config.GetValue<string>("MySettings:WelcomeMessage") ?? "Welcome to the API!";
            return Ok(message);
        }

        // ECHO ENDPOINT
        [HttpGet("echo")]
        public IActionResult EchoValue([FromQuery] List<string> userInput)
        {
            if (userInput == null || userInput.Count == 0)
            {
                return BadRequest(new { error = "Please provide at least one value!" });
            }

            return Ok(new
            {
                Message = "You entered",
                Data = userInput
            });
        }
    }
}