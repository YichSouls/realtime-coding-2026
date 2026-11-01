namespace StationRegistry
{
    public record Station(
        string Code,
        string Name,
        string City
    );

    public record StationSummary(string Code, string Name);

    public record CityGroup(
        string City,
        int StationCount,
        List<string> StationNames
    );

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
        public List<Station> Stations = new List<Station>
        {
            new("PAR01", "Paris Nord", "Paris"),
            new("PAR02", "Paris Lyon", "Paris"),
            new("PAR03", "Paris Montparnasse", "Paris"),
            new("LYO01", "Lyon Part-Dieu", "Lyon"),
            new("LYO02", "Lyon Perrache", "Lyon"),
            new("LIL01", "Lille Flandres", "Lille"),
            new("LIL02", "Lille Europe", "Lille"),
            new("PAR04", "Paris Bercy", "PARIS")
        };

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
            return Stations.Find((s) => s.Code == code);
        }

        public List<Station> FindByCity(string city)
        {
            return Stations.Where(s => s.City == city).ToList();
        }

        public List<StationSummary> GetAllSummaries()
        {
            return Stations
                .Select(s => new StationSummary(s.Code, s.Name))
                .OrderBy(s => s.Name)
                .ToList();
        }

        public string[] GetAllCities()
        {
            return Stations
                .Select(s => s.City)
                .Distinct()
                .OrderBy(c => c)
                .ToArray();
        }

        public List<CityGroup> SearchGroupedByCity(string input)
        {
            return Stations
                .Where(s => s.City.StartsWith(input))
                .GroupBy(s => s.City)
                .Select(g => new CityGroup
                (
                    g.Key,
                    g.Count(),
                    g.Select(s => s.Name).OrderBy(n => n).ToList()
                ))
                .OrderBy(c => c.City)
                .ToList();
        }
    }
}
