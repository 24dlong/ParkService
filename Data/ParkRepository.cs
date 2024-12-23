namespace ParkService.Data;

using ParkService.Models;

public class ParkRepository : IParkRepository
{
    private static readonly Park Acadia = new () { Id = 1, Name = "Acadia National Park" };
    private static readonly Park BigBend = new () { Id = 2, Name = "Big Bend National Park" };
    private static readonly SortedDictionary<int, Park> Parks = new()
    {
        { Acadia.Id, Acadia },
        { BigBend.Id, BigBend }
    };
    
    private static readonly SortedDictionary<int, Trail> Trails = new()
    {
        { 1, new Trail() { Id = 1, Name = "The Beehive Loop Trail", Park = Acadia, Length = 1.5d } },
        { 2, new Trail() { Id = 2, Name = "Jordan Pond Path", Park = Acadia, Length = 3.3d } },
        { 3, new Trail() { Id = 3, Name = "Gorham Mountain Loop", Park = Acadia, Length = 3.0d } },
        { 4, new Trail() { Id = 4, Name = "Lost Mine Trail", Park = BigBend, Length = 4.8d } },
        { 5, new Trail() { Id = 5, Name = "The Window Trail", Park = BigBend, Length = 5.5d } },
    };

    public IEnumerable<Park> ListParks()
    {
        return Parks.Values;
    }

    public Park GetPark(int id)
    {
        return Parks[id];
    }

    public Trail GetTrail(int id)
    {
        return Trails[id];
    }
    
    public IEnumerable<Trail> ListTrails(int? id = null, int? parkId = null)
    {
        var trails = Trails.Values.ToList();
        if (parkId != null)
        {
            trails.RemoveAll((trail) => trail.Park.Id != parkId);
        }
        
        if (id != null)
        {
            trails.Clear();
            trails.Add(Trails[id.Value]);
        }
        
        return trails;
    }

}