using Heroes.Models;
using Microsoft.AspNetCore.Mvc;

namespace Heroes.Data;

public class HeroStorage : IHeroesStorage
{
    private readonly Dictionary<string, Hero> _heroes = new Dictionary<string, Hero>();

    public HeroStorage()
    {
        ReadHeroesFile();
    }


    public ICollection<Hero> ListHeroes()
    {
        return _heroes.Values;
    } 
    public ICollection<Hero> ListHeroesByRole(string role)
    {
        return _heroes.Values.Where(h=>h.Role.ToLower().Equals(role.ToLower())).ToList();
    }
    
    public Hero GetHero(string name)
    {
        if (_heroes.ContainsKey(name)) return _heroes[name];
        return null;
    }

    private void ReadHeroesFile()
    {
        var file = "Data/heroes.csv";
        foreach (var line in File.ReadAllLines(file))
        {
            var tokens = line.Split(",");
            var hero = new Hero
            {
                Name = tokens[0],
                Role = tokens[1],
                HitPoints = Convert.ToInt32(tokens[2])
            };
            _heroes[tokens[0].ToLower()] = hero;
        }
    }
}