using Heroes.Models;

namespace Heroes.Data;

public interface IHeroesStorage
{
    public ICollection<Hero> ListHeroes();
    public ICollection<Hero> ListHeroesByRole(string role);
    public Hero GetHero(string name);
}