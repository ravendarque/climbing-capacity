using System.Text.Json;

namespace Ravendarque.ClimbingCapacity.Web.Services;

public class ParseHtmlCapacityDataException : Exception
{
    public ParseHtmlCapacityDataException(string message) : base(message) { }

    public ParseHtmlCapacityDataException(string message, Exception exception) : base(message, exception) { }
}