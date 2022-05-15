using Heroes.Data;
using Microsoft.AspNetCore.Mvc;

namespace Heroes.Controllers;
[Route("/maps")]
public class MapController :ControllerBase
{
    private readonly IMapStorage _storage;

    public MapController(IMapStorage storage)
    {
        _storage = storage;
    }
    [HttpGet]
    public IActionResult GetMaps(string gameMode = "none")
    {
        if (gameMode.Equals("none")) return Ok(_storage.ListMaps());
        else return Ok(_storage.ListMapsByGameMode(gameMode));
    }

    [HttpGet("{name}")]
    public IActionResult GetMap(string name)
    {
        var result = _storage.GetMap(name.ToLower());
        if (result == null) return NotFound();
        return Ok(result);
    }
    
    
    
}