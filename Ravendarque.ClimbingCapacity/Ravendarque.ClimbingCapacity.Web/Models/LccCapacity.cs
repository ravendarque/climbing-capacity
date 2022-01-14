namespace Ravendarque.ClimbingCapacity.Web.Models;

public class LccCapacity : ICapacity
{
    public string Org => "LCC";

    public string? Location { get; set; }

    public int Max { get; set; }

    public int Current { get; set; }
}