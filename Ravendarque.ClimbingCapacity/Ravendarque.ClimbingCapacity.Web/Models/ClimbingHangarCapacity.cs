namespace Ravendarque.ClimbingCapacity.Web.Models;

public class ClimbingHangarCapacity : ICapacity
{
    public string Org => "Climbing Hangar";

    public string? Location { get; set; }

    public int Max { get; set; }

    public int Current { get; set; }
}