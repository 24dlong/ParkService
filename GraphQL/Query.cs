namespace ParkService.GraphQL;

using ParkService.Models;
using ParkService.Data;

public class Query
{
    private readonly IParkRepository _parkRepository;

    public Query(IParkRepository parkRepository)
    {
        _parkRepository = parkRepository;
    }

    public Park GetPark(int id) =>
        _parkRepository.GetPark(id);

    public IEnumerable<Park> GetParks() =>
        _parkRepository.ListParks();
    
    public Trail GetTrail(int id) =>
        _parkRepository.GetTrail(id);

    public IEnumerable<Trail> GetTrails(int? parkId, int? id) =>
        _parkRepository.ListTrails(id: id, parkId: parkId);
}
