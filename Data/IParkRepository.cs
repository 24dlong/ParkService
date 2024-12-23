namespace ParkService.Data;

using ParkService.Models;

public interface IParkRepository 
{
    public Park GetPark(int id);
    public IEnumerable<Park> ListParks();
    
    public Trail GetTrail(int id);
    public IEnumerable<Trail> ListTrails(int? id = null, int? parkId = null);
}