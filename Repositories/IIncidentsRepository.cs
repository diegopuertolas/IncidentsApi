using ItIncidents.Api.Models;

namespace ItIncidents.Repositories;

public interface IIncidentsRepository
{
    IEnumerable<Incident> GetAll();
    Incident? GetById(Guid id);
    IEnumerable<Incident> GetPriorityIncidents(int cantidad);
    IEnumerable<Incident> GetByTitle(string title);
    void Post(Incident incident);
    void Put(Incident incident);
    bool Delete(Guid id);
}