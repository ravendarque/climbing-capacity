namespace Ravendarque.ClimbingCapacity.Web.Models;

public class YonderCapacity : ICapacity
{
    public string Org => "Yonder";

    public string? Location { get; set; }

    public int Max { get; set; }

    public int Current { get; set; }
}