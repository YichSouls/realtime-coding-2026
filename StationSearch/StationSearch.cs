namespace StationSearch
{
    public class Station
    {
        public required string StationCode { get; set; }
        public required string StationName { get; set; }
    }

    public record StationSearchOutput(List<Station> StationsOutput, List<char> NextCharsOutput);

    public class StationSearchService
    {
        public List<Station> Stations = [
            new Station{StationCode = "DRF", StationName= "Dartford"},
            new Station{StationCode = "DRT", StationName= "Darton"},
            new Station{StationCode = "LVC", StationName= "Liverpool Central"},
            new Station{StationCode = "LVJ", StationName= "Liverpool James Street"},
            new Station{StationCode = "LIV", StationName= "Liverpool Lime Street"},
            new Station{StationCode = "LPY", StationName= "Liverpool South Parkway"},
        ];

        public StationSearchOutput Search(string searchString)
        {
            ArgumentNullException.ThrowIfNull(searchString);

            var matches = Stations
                .Where(s => s.StationName.StartsWith(searchString, StringComparison.OrdinalIgnoreCase))
                .ToList();

            var nextChars = matches
                .Where(s => s.StationName.Length > searchString.Length)
                .Select(s => s.StationName[searchString.Length])
                .Distinct()
                .Order()
                .ToList();

            return new StationSearchOutput(matches, nextChars);
        }
    }
}

