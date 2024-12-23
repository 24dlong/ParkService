using Microsoft.AspNetCore.Mvc;
using ParkService.Models;
using ParkService.Data;

namespace ParkService.Controllers;

[ApiController]
[Route("[controller]")]
public class TrailsController : ControllerBase
{
    
    private readonly IParkRepository _parkRepository;

    public TrailsController(IParkRepository parkRepository)
    {
        _parkRepository = parkRepository;
    }

    [HttpGet("")]
    public IEnumerable<Trail> ListTrails()
    {
        return _parkRepository.ListTrails();
    }
    
    [HttpGet("{id}")]
    public Trail GetTrail(int id)
    {
        return _parkRepository.GetTrail(id);
    }
}