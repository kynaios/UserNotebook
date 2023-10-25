using Microsoft.AspNetCore.Mvc;
using UserNotebook.Models;

namespace UserNotebook.Controllers;

[ApiController]
[Route("[controller]")]
public class KidController : ControllerBase
{
    private readonly ICrudService<Kid, KidDto> _service;

    public KidController(ICrudService<Kid, KidDto> service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<IEnumerable<KidDto>> FindAll()
    {
        var kids = _service.FindAll();

        return CreatedAtAction(nameof(FindAll), kids);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<KidDto> Create(string id)
    {
        var guid = Guid.Parse(id);
        var kid = _service.Find(guid);

        return CreatedAtAction(nameof(FindAll), kid);
    }

    [HttpPost]
    [Route("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult Create([FromBody] KidDto dto)
    {
        if (ModelState.IsValid)
        {
            _service.Save(dto);

            return Ok();
        }

        return BadRequest(ModelState);
    }

    [HttpPut]
    [Route("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult Update([FromBody] KidDto dto)
    {
        if (ModelState.IsValid)
        {
            _service.Update(dto);

            return Ok();
        }

        return BadRequest(ModelState);
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