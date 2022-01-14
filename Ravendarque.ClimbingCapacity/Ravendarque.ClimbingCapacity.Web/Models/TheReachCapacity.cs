namespace Ravendarque.ClimbingCapacity.Web.Models;

public class TheReachCapacity : ICapacity
{
    public string Org => "The Reach";

    public string? Location { get; set; }

    public int Max { get; set; }

    public int Current { get; set; }
}