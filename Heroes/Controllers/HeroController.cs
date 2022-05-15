using Heroes.Data;
using Microsoft.AspNetCore.Mvc;

namespace Heroes.Controllers;
[Route("/heroes")]
public class HeroController : ControllerBase
{
    private readonly IHeroesStorage _storage;

    
    public HeroController(IHeroesStorage storage)
    {
        _storage = storage;
    }

    [HttpGet]
    public IActionResult GetHeroes(string role = "none")
    {
        if (role.Equals("none")) return Ok(_storage.ListHeroes());
        else return Ok(_storage.ListHeroesByRole(role.ToLower()));
    }
    [HttpGet("{name}")]
    public IActionResult Get(string name)
    {
        var result = _storage.GetHero(name.ToLower());
        if (result == default) return NotFound();
        else return Ok(result);
    }

}