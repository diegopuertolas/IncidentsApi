namespace ItIncidents.Api.DTO;

public class CreateIncidentDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string AssignedTechnician { get; set; }
    public int Priority { get; set; }

}