using Microsoft.AspNetCore.Mvc;
using UserNotebook.Dtos;

namespace UserNotebook.Controllers;

[ApiController]
[Route("[controller]")]
public class ReportController : ControllerBase
{
    private readonly IReportService _service;

    public ReportController(IReportService service)
    {
        _service = service;
    }
    
    [HttpGet]
    [Route("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<IEnumerable<ReportDto>> FindAll()
    {
        var reports = _service.FindAll();
        
        return CreatedAtAction(nameof(FindAll), reports);
    }
}