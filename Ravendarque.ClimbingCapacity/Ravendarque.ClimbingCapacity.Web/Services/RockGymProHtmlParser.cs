using System.Collections;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

using Ravendarque.ClimbingCapacity.Web.Models;

namespace Ravendarque.ClimbingCapacity.Web.Services
{
    public class RockGymProHtmlParser<T> : ICapacityDataParser<T>
        where T : ICapacity, new()
    {
        private static readonly JsonSerializerOptions JsonSerializerOptions = new()
            { AllowTrailingCommas = true };

        private const string NotAvailable = "-1";

        public IEnumerable<T> Parse(string content)
        {
            return ParseCapacityData(content).Select(BuildCapacity);
        }

        private static T BuildCapacity(KeyValuePair<string, JsonNode?> capacity)
        {
            var (location, data) = capacity;
            return new T
            {
                Location = location,
                Max = int.Parse(data?["capacity"]?.ToString() ?? NotAvailable),
                Current = int.Parse(data?["count"]?.ToString() ?? NotAvailable)
            };
        }

        private static JsonObject ParseCapacityData(string content)
        {
            var rawCapacityDataMatch = Regex.Match(content, "var data = ({.+?});", RegexOptions.Singleline);
            if (!rawCapacityDataMatch.Success || rawCapacityDataMatch.Groups.Count != 2)
            {
                throw new ParseHtmlCapacityDataException("Could not find match for capacity data in html content");
            }

            var rawCapacityData = rawCapacityDataMatch.Groups[1].Value.Replace('\'', '"');

            JsonObject? capacityData;
            try
            {
                capacityData = JsonSerializer.Deserialize<JsonObject>(rawCapacityData, JsonSerializerOptions);
            }
            catch (JsonException ex)
            {
                throw new ParseHtmlCapacityDataException("Could not parse capacity data in html content", ex);
            }

            if (capacityData == null)
            {
                throw new ParseHtmlCapacityDataException("Parsed capacity data is null");
            }

            return capacityData;
        }
    }
}