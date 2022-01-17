namespace Ravendarque.ClimbingCapacity.Web.Models;

public class LccCapacity : ICapacity
{
    private static readonly Dictionary<string, string> LocationMap = new()
    {
        { "VWS", "VauxWall West" },
        { "VES", "VauxWall East" },
        { "HAR", "HarroWall" },
        { "CRO", "CroyWall" },
        { "RAV", "RavensWall" },
        { "CNW", "CanaryWall" },
        { "BWG", "BethWall Green" }
    };

    public string Org => "LCC";

    private readonly string _location = "Unknown";

    public string Location
    {
        get => _location;
        init
        {
            if (!string.IsNullOrEmpty(value))
                _location = value;
        }
    }

    public string LocationName =>
        LocationMap.TryGetValue(Location, out var locationName)
            ? locationName
            : Location;

    public int Max { get; init; }

    public int Current { get; init; }
}