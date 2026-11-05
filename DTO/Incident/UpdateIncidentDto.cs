using System.ComponentModel.DataAnnotations;

namespace ItIncidents.Api.DTO;

public class UpdateIncidentDto
{
    [Required(ErrorMessage = "El título es obligatorio")]
    public string Title { get; set; }

    [Required(ErrorMessage = "La descripción es obligatorio")]
    public string Description { get; set; }

    [Required(ErrorMessage = "El técnico asignado es obligatorio")]
    public string AssignedTechnician { get; set; }

    [Required(ErrorMessage = "La prioridad es obligatorio")]
    [Range(1, 5, ErrorMessage = "La prioridad debe estar entre 1 y 5")]
    public int Priority { get; set; }

}