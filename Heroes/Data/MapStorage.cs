using Heroes.Models;

namespace Heroes.Data;

public class MapStorage : IMapStorage
{
    private readonly Dictionary<string, Map> _maps = new Dictionary<string, Map>();

    public MapStorage()
    {
        ReadMapsFile();
    }

    private void ReadMapsFile()
    {
        _maps.Add("kings row",new Map{Name = "Kings Row",Country = "UK",GameMode = "Hybrid"}); 
        _maps.Add("route 66",new Map{Name = "Route 66",Country = "USA",GameMode = "Payload"}); 
        _maps.Add("ilios",new Map{Name = "Ilios",Country = "Greece",GameMode = "Control"});
        _maps.Add("junkertown",new Map{Name = "Junkertown",Country = "Australia",GameMode = "Payload"}); 
        _maps.Add("paris",new Map{Name = "Paris",Country = "France",GameMode = "Capture"});
        
        
        
        /*var file = "Data/maps.csv";
        foreach (var line in File.ReadAllLines(file))
        {
            var tokens = line.Split(",");
            var map = new Map
            {
                Name = tokens[0],
                GameMode = tokens[1],
                Country = tokens[2]
            };
            _maps[tokens[0].ToLower()] = map;
        }*/
    }
    
    public ICollection<Map> ListMaps()
    {
        return _maps.Values;
    }

    public ICollection<Map> ListMapsByGameMode(string gameMode)
    {
        return _maps.Values.Where(m => m.GameMode.ToLower().Equals(gameMode.ToLower())).ToList();
    }

    public Map GetMap(string name)
    {
        if (_maps.ContainsKey(name)) return _maps[name];
        else return null;
    }
}