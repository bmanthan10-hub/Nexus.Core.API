using Microsoft.AspNetCore.Mvc;

namespace YourProjectName.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // URL: /api/user/5 -> Works
        // URL: /api/user/abc -> Returns 404 (Constraint fails)
        [HttpGet("{id:int}")]
        public IActionResult GetUserWithId(int id)
        {
            return Ok($"User Id is {id}");
        }

        // URL: /api/user -> Returns "User Id is 1"
        [HttpGet]
        public IActionResult GetDefaultUser(int id = 1)
        {
            return Ok($"User Id is {id} (default value)");
        }
    }
}