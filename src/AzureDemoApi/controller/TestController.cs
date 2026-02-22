
using Microsoft.AspNetCore.Mvc;
using Data;
public interface IGuidService { Guid Id { get; } }
public class GuidService : IGuidService { public Guid Id { get; } = Guid.NewGuid(); }

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly IGuidService _service;
    private readonly ILogger<TestController> _logger;
    private readonly IStudentDbContext _dbContext;

    public TestController(IGuidService service, ILogger<TestController> logger, IStudentDbContext dbContext)
    {
        _service = service;
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet("guids")]
    public async Task<IActionResult> GetGuids()
    {
        _logger.LogInformation("GetGuids called");
        await Task.Delay(500); // simulate async
        return Ok(new { SingletonGuid = _service.Id });
    }

    [HttpGet("students")]
    public List<Student> GetStudents()
    {
        return _dbContext.Students.ToList();
    }
    
}
