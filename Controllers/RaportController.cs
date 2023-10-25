using Microsoft.AspNetCore.Mvc;
using UserNotebook.Dtos;

namespace UserNotebook.Controllers;

[ApiController]
[Route("[controller]")]
public class RaportController : ControllerBase
{
    private readonly IRaportService _service;

    public RaportController(IRaportService service)
    {
        _service = service;
    }
    
    [HttpGet]
    [Route("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<IEnumerable<RaportDto>> FindAll()
    {
        var raports = _service.FindAll();
        
        return CreatedAtAction(nameof(FindAll), raports);
    }
}