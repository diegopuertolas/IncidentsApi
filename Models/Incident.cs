using ItIncidents.Api.Enums;

namespace ItIncidents.Api.Models;

public class Incident
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Description { get; set; }
    public string AssignedTechnician { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public int Priority { get; set; }
    public IncidentStatus Status { get; set; } = IncidentStatus.Abierta;
}