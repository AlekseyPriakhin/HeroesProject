using Heroes.Models;

namespace Heroes.Data;

public interface IMapStorage
{
    public ICollection<Map> ListMaps();
    public ICollection<Map> ListMapsByGameMode(string gameMode);
    public Map GetMap(string name);
    
}