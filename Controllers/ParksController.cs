using Microsoft.AspNetCore.Mvc;
using ParkService.Models;
using ParkService.Data;
using ParkService.Dtos;

namespace ParkService.Controllers;

[ApiController]
[Route("[controller]")]
public class ParksController : ControllerBase
{
    
    private readonly IParkRepository _parkRepository;

    public ParksController(IParkRepository parkRepository)
    {
        _parkRepository = parkRepository;
    }

    [HttpGet("")]
    public IEnumerable<Park> ListParks()
    {
        return _parkRepository.ListParks();
    }
    
    [HttpGet("{id}")]
    public Park GetPark(int id)
    {
        return _parkRepository.GetPark(id);
    }

    [HttpGet("{id}/trails")]
    public IEnumerable<TrailWithoutParkDto> GetTrails(int id)
    {
        var trails = _parkRepository.ListTrails(parkId: id);
        return trails.Select(trail => new TrailWithoutParkDto
        {
            Id = trail.Id,
            Name = trail.Name,
            Length = trail.Length,
        });
    }
}