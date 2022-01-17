namespace Ravendarque.ClimbingCapacity.Web.Models;

public class YonderCapacity : ICapacity
{
    private static readonly Dictionary<string, string> LocationMap = new()
        { { "AAA", "Yonder" } };

    public string Org => "Yonder";

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