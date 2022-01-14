namespace Ravendarque.ClimbingCapacity.Web.Models
{
    public interface ICapacity
    {
        string? Org { get; }

        string? Location { get; set; }

        int Max { get; set; }

        int Current { get; set; }
    }
}