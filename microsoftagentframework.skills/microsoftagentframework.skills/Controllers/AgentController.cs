using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/agent")]
public class AgentController : ControllerBase
{
    private readonly AgentService _agent;

    public AgentController(AgentService agent)
    {
        _agent = agent;
    }

    [HttpPost]
    public async Task<IActionResult> Ask([FromBody] AgentRequest request)
    {
        var result = await _agent.Ask(request.Query);
        return Ok(new { response = result });
    }
}