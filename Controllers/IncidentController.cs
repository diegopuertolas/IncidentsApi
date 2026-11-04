using ItIncidents.Api.Models;
using Microsoft.AspNetCore.Mvc;
using ItIncidents.Api.Enums;

namespace ItIncidents.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncidentController : ControllerBase
{
    private static readonly List<Incident> incidents = new List<Incident>
    {
        new Incident { Id = 1, Title = "Fallo en el frontend", Description = "Hay un fallo en el frontend", AssignedTechnician = "Diego", DateCreated = DateTime.Now, Priority = 3, Status = IncidentStatus.Abierta },
        new Incident { Id = 2, Title = "Fallo en el backend", Description = "Hay un fallo en el backend", AssignedTechnician = "Hugo", DateCreated = DateTime.Now, Priority = 4, Status = IncidentStatus.EnProceso },
        new Incident { Id = 3, Title = "Fallo en la base de datos", Description = "Hay un fallo en la base de datos", AssignedTechnician = "Adrián", DateCreated = DateTime.Now, Priority = 5, Status =IncidentStatus.EnProceso },
    };
    
}