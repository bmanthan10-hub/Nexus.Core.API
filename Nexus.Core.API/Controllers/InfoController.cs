using Microsoft.AspNetCore.Mvc;
using YourProjectName.Services;

[ApiController]
[Route("api")]
public class InfoController : ControllerBase
{
    private readonly IMessageService _messageService;
    private readonly ITimeService _timeService;
    private readonly IRequestCounterService _counterService;

    // Constructor Injection
    public InfoController(IMessageService messageService, ITimeService timeService, IRequestCounterService counterService)
    {
        _messageService = messageService;
        _timeService = timeService;
        _counterService = counterService;
    }

    // Call: /api/info
    [HttpGet("info")]
    public IActionResult GetInfo()
    {
        return Ok(new
        {
            Message = _messageService.GetMessage(),
            Time = _timeService.GetTime()
        });
    }

    // Method Injection using [FromServices]
    [HttpGet("info/from-service")]
    public IActionResult GetInfoFromService([FromServices] IMessageService msgService, [FromServices] ITimeService timeSvc)
    {
        return Ok(new
        {
            Message = msgService.GetMessage(),
            Time = timeSvc.GetTime(),
            InjectedVia = "Method Injection"
        });
    }

    //  Scoped Service Test
    [HttpGet("counter")]
    public IActionResult GetCounter()
    {
        _counterService.Increment(); // first call
        var currentCount = _counterService.Increment(); // second call (Same request)

        return Ok(new
        {
            Counter = currentCount,
            Note = "Shows scoped service works within one request"
        });
    }
}