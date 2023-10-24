using Microsoft.AspNetCore.Mvc;
using UserNotebook.Models;

namespace UserNotebook.Controllers;

[ApiController]
[Route("[controller]")]
public class AdultController : ControllerBase
{
    private readonly ICrudService<Adult, AdultDto> _service;

    public AdultController(ICrudService<Adult,AdultDto> service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<IEnumerable<AdultDto>> FindAll()
    {
        var adults = _service.FindAll();
        
        return CreatedAtAction(nameof(FindAll), adults);
    }
    
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<AdultDto> Create(string id)
    {
        var guid = Guid.Parse(id);
        var adult = _service.Find(guid);
        
        return CreatedAtAction(nameof(FindAll), adult);
    }
    
    [HttpPost]
    [Route("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult Create([FromBody] AdultDto dto)
    {
        _service.Save(dto);
        
        return Ok("success");
    }
    
    [HttpPut]
    [Route("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult Update([FromBody] AdultDto dto)
    {
        _service.Update(dto);
        
        return Ok();
    }
    
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult Delete(string id)
    {
        var guid = Guid.Parse(id);
        _service.Delete(guid);
        
        return Ok();
    }
}