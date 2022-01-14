namespace Ravendarque.ClimbingCapacity.Web.Models
{
    public interface ICapacity
    {
        string? Org { get; }

        string Location { get; init; }

        int Max { get; init; }

        int Current { get; init; }

        string LocationName { get; }
    }
}