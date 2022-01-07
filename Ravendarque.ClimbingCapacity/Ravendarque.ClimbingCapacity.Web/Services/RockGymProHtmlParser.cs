using System.Collections;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

using Ravendarque.ClimbingCapacity.Web.Models;

namespace Ravendarque.ClimbingCapacity.Web.Services
{
    public class RockGymProHtmlParser : ICapacityDataParser
    {
        private const string NotAvailable = "-1";

        public IEnumerable<Capacity> Parse(string content)
        {
            var capacityData = ParseCapacityData(content);

            foreach (var (key, value) in capacityData.AsObject())
            {
                yield return new Capacity(
                    "DummyOrg", 
                    key, 
                    int.Parse(value?["capacity"]?.ToString() ?? NotAvailable), 
                    int.Parse(value?["count"]?.ToString() ?? NotAvailable)
                    );
            }
        }

        private static JsonNode ParseCapacityData(string content)
        {
            var rawCapacityDataMatch = Regex.Match(content, "var data = ({.+?});", RegexOptions.Singleline);
            if (!rawCapacityDataMatch.Success || rawCapacityDataMatch.Groups.Count != 2)
            {
                throw new ParseHtmlCapacityDataException("Could not find match for capacity data in html content");
            }

            var rawCapacityData = rawCapacityDataMatch.Groups[1].Value.Replace('\'', '"');

            JsonNode? capacityData;
            try
            {
                capacityData = JsonNode.Parse(rawCapacityData);
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
