namespace Ravendarque.ClimbingCapacity.Web.Models
{
    public class Capacity
    {
        public Capacity(string org, string location, int max, int current)
        {
            Org = org;
            Location = location;
            Max = max;
            Current = current;
        }

        public string Org { get; }

        public string Location { get; }

        public int Max { get; }

        public int Current { get; }
    }
}