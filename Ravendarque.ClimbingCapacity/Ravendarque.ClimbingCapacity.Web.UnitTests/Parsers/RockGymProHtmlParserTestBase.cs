using NUnit.Framework;
using System.IO;

namespace Ravendarque.ClimbingCapacity.Web.UnitTests.Parsers
{
    internal abstract class RockGymProHtmlParserTestBase
    {
        private const string TestDataRelativePath = "../../../TestData";

        protected abstract string TestDataFileName { get; }

        public abstract void ParseCapacityDataFromHtml();

        protected static string GetTestData(string testDataFileName)
        {
            var testRunPath = TestContext.CurrentContext.TestDirectory;
            var testDataFile = Path.Combine(testRunPath, TestDataRelativePath, testDataFileName);

            return File.ReadAllText(testDataFile);
        }
    }
}