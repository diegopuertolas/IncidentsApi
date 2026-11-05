using ItIncidents.Api.Models;

namespace ItIncidents.Repositories;

public class IncidentRepository : IIncidentsRepository
{
    private static readonly List<Incident> incidents = new List<Incident>
    {
        new Incident { Title = "Fallo en el frontend", Description = "Hay un fallo en el frontend", AssignedTechnician = "Diego", Priority = 3 } ,
        new Incident { Title = "Fallo en el backend", Description = "Hay un fallo en el backend", AssignedTechnician = "Hugo", Priority = 4  },
        new Incident { Title = "Fallo en la base de datos", Description = "Hay un fallo en la base de datos", AssignedTechnician = "Adrián", Priority = 5 },
    };

    public IEnumerable<Incident> GetAll()
    {
        return incidents;
    }

    public Incident? GetById(Guid id)
    {
        return incidents.FirstOrDefault(i => i.Id == id);
    }

    public IEnumerable<Incident> GetPriorityIncidents(int cantidad)
    {
        return incidents
                .OrderByDescending(i => i.Priority)
                .Take(cantidad)
                .ToList();           
    }

    public IEnumerable<Incident> GetByTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title)) return new List<Incident>();

        return incidents
                .Where(i => i.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                .ToList();
    }

    public void Post(Incident incident)
    {
        incidents.Add(incident);
    }

    public void Put(Incident incident)
    {
        
    }

    public bool Delete(Guid id)
    {
        var result = GetById(id);

        if (result is null) return false;

        incidents.Remove(result);
        return true; 
    }

}