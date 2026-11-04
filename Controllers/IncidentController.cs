using ItIncidents.Api.DTO;
using ItIncidents.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace ItIncidents.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncidentController : ControllerBase
{
    private static readonly List<Incident> incidents = new List<Incident>
    {
        new Incident { Title = "Fallo en el frontend", Description = "Hay un fallo en el frontend", AssignedTechnician = "Diego", Priority = 3 } ,
        new Incident { Title = "Fallo en el backend", Description = "Hay un fallo en el backend", AssignedTechnician = "Hugo", Priority = 4  },
        new Incident { Title = "Fallo en la base de datos", Description = "Hay un fallo en la base de datos", AssignedTechnician = "Adrián", Priority = 5 },
    };
    
    [HttpGet]
    public ActionResult<IEnumerable<Incident>> GetAllIncidents()
    {
        return Ok(incidents);
    }

    [HttpGet("{id}")]
    public ActionResult<Incident> GetIncidentById(Guid id)
    {
        var result = incidents.FirstOrDefault(i => i.Id == id);
        
        if (result is null) return NotFound();

        return Ok(result);
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
        
        incidents.Add(result);

        return CreatedAtAction(nameof(GetIncidentById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] UpdateIncidentDto incident)
    {
        var result = incidents.FirstOrDefault(i => i.Id == id); 

        result.Title = incident.Title;
        result.Description = incident.Description;
        result.AssignedTechnician = incident.AssignedTechnician;
        result.Priority = incident.Priority;

        return NoContent();
    }

    [HttpPut("{id}/resolver")]
    public IActionResult Resolve(Guid id)
    {
        var result = incidents.FirstOrDefault(i => i.Id == id);

        if (result is null) return NotFound();

        if (result.Status == Enums.IncidentStatus.Resuelta) return Conflict();
        
        result.Status = Enums.IncidentStatus.Resuelta;

        return NoContent();    
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var result = incidents.FirstOrDefault(i => i.Id == id);

        incidents.Remove(result);

        return NoContent();
    }
}