using ItIncidents.Api.DTO;
using ItIncidents.Api.Models;
using ItIncidents.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ItIncidents.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncidentController : ControllerBase
{
    private readonly IIncidentsRepository _repository;

    public IncidentController(IIncidentsRepository repository)
    {
        _repository = repository;
    }
   
    [HttpGet]
    public ActionResult<IEnumerable<Incident>> GetAllIncidents()
    {
        return Ok(_repository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Incident> GetById(Guid id)
    {
        var result = _repository.GetById(id);
        
        if (result is null) return NotFound();

        return Ok(result);
    }

    [HttpGet("prioritarias")]
    public ActionResult<IEnumerable<Incident>> GetPriorityIncidenta([FromQuery] int cantidad = 3)
    {
        if (cantidad <= 0) return BadRequest();

        return Ok(_repository.GetPriorityIncidents(cantidad));
    }

    [HttpGet("buscar")]
    public ActionResult<IEnumerable<Incident>> GetByTitle([FromQuery] string title)
    {
        return Ok(_repository.GetByTitle(title));
    }

    [HttpPost]
    public ActionResult<Incident> Post([FromBody] CreateIncidentDto incident)
    {    
        var result = new Incident
        {
            Title = incident.Title,
            Description = incident.Description,
            AssignedTechnician = incident.AssignedTechnician,
            Priority = incident.Priority
        };
        
        _repository.Post(result);

        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] UpdateIncidentDto incident)
    {
        var result = _repository.GetById(id);

        if (result is null) return NotFound();

        result.Title = incident.Title;
        result.Description = incident.Description;
        result.AssignedTechnician = incident.AssignedTechnician;
        result.Priority = incident.Priority;

        _repository.Put(result);

        return NoContent();
    }

    [HttpPut("{id}/resolver")]
    public IActionResult Resolve(Guid id)
    {
        var result = _repository.GetById(id);

        if (result is null) return NotFound();

        if (result.Status == Enums.IncidentStatus.Resuelta) return Conflict();
        
        result.Status = Enums.IncidentStatus.Resuelta;
        
        _repository.Put(result);

        return NoContent();    
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var deleted = _repository.Delete(id);

        if (!deleted) return NotFound();

        return NoContent();
    }
}