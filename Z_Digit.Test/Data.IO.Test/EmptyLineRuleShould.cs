using NdubuisiJr.Z_Digit.Data.IO.Reader;
using NdubuisiJr.Z_Digit.Data.IO.TextInputRules;
using NdubuisiJr.Z_Digit.Domain;
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace Z_Digit.Test.Data.IO.Test
{

    [TestFixture]
    public class EmptyLineRuleShould {
        IReadLineRule _emptyLineRule;
        ITextFileReader _readFile;
        [SetUp]
        public void InitializeTest() {
            _readFile = new TextFileReader();
            _emptyLineRule = new EmptyLineRule(_readFile);
        }

        [Test]
        public void OnGetChartValue_AddOldChartToCollectionOfReadFileCharts() {
            _emptyLineRule.GetChartValue("");
            AreEqual(1, _readFile.Charts.Count);
        }

        [Test]
        public void OnGetChartValue_CreatesNewInstanceOfReadFileChart() {
            var chart = new ZFactorChart();
            _readFile.chart = chart;

            _emptyLineRule.GetChartValue("");

            AreNotSame(_readFile.chart, chart);
        }

        [Test]
        public void OnIsMatched_ReturnsTrueWhenLineisEmpty() {
            var line = "";
            var result = _emptyLineRule.IsMatched(line);
            AreEqual(true, result);
        }
    }
}
