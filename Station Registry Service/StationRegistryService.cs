public class Station
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required string City { get; set; }
}

public record StationSummary(string Code, string Name);

public interface IStationRegistry
{
    bool AddStation(Station station);

    bool RemoveStation(string code);

    Station? FindByCode(string code);

    List<Station> FindByCity(string city);

    List<StationSummary> GetAllSummaries();

    string[] GetAllCities();
}

public class StationRegistry : IStationRegistry
{
    public List<Station> Stations = [
        new Station{Code= "PAR01", Name="Gare du Nord", City="Paris"},
        new Station{Code= "PAR02", Name="Gare de Lyon", City="Paris"},
        new Station{Code= "LYO01", Name="Part-Dieu", City="Lyon"},
    ];

    public bool AddStation(Station station)
    {
        foreach (Station _station in Stations)
        {
            if (_station.Code == station.Code)
            {
                return false;
            }
        }

        Stations.Add(station);
        return true;
    }

    public bool RemoveStation(string code)
    {
        foreach (Station _station in Stations)
        {
            if (_station.Code == code)
            {
                Stations.Remove(_station);
                return true;
            }
        }
        return false;
    }

    public Station? FindByCode(string code)
    {
        return null;
    }

    public List<Station> FindByCity(string city)
    {
        return new List<Station>();
    }

    public List<StationSummary> GetAllSummaries()
    {
        return new List<StationSummary>();
    }

    public string[] GetAllCities()
    {
        return [];
    }
}