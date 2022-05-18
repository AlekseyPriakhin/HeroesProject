using System.Reflection;
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
        _heroes.Add("mccree", new Hero{Name = "Mccree",HitPoints = 225,Role = "DD"});
        _heroes.Add("ashe", new Hero{Name = "Ashe",HitPoints = 200,Role = "DD"});
        _heroes.Add("tracer", new Hero{Name = "Tracer",HitPoints = 150,Role = "DD"});
        _heroes.Add("pharah", new Hero{Name = "Pharah",HitPoints = 200,Role = "DD"});
        _heroes.Add("sombra", new Hero{Name = "Sombra",HitPoints = 200,Role = "DD"});
        _heroes.Add("d.va", new Hero{Name = "D.va",HitPoints = 600,Role = "Tank"}); 
        _heroes.Add("winston", new Hero{Name = "Winston",HitPoints = 500,Role = "Tank"});
        _heroes.Add("roadhog", new Hero{Name = "Roadhog",HitPoints = 600,Role = "Tank"});
        _heroes.Add("ana", new Hero{Name = "Ana",HitPoints = 200,Role = "Support"});
        _heroes.Add("mercy", new Hero{Name = "Mercy",HitPoints = 200,Role = "Support"});
        _heroes.Add("zenyatta", new Hero{Name = "Zenyatta",HitPoints = 150,Role = "Support"});
        /*var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var p = Path.Combine(path, "heroes.csv");
        Console.WriteLine(p);
        var file = Path.Combine(p);
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
        }*/
    }
}