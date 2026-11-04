using ItIncidents.Api.Enums;

namespace ItIncidents.Api.Models;

public class Incident
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? AssignedTechnician { get; set; }
    public DateTime DateCreated { get; set; }
    public int Priority { get; set; }
    public IncidentStatus Status { get; set; }
}