using NdubuisiJr.Z_Digit.Data.IO.Reader;
using NdubuisiJr.Z_Digit.Data.IO.TextInputRules;
using NUnit.Framework;
using static NUnit.Framework.Assert;


namespace Z_Digit.Test.Data.IO.Test
{

    [TestFixture]
    public class TemperatureReadLineRuleShould {
        ITextFileReader _readFile;
        IReadLineRule _temperatureReadLineRule;
        [SetUp]
        public void InitializeTest() {
            _readFile = new TextFileReader();
            _temperatureReadLineRule = new TemperatureReadLineRule(_readFile);
        }
        
        [Test]
        public void OnGetChartValue_UpdateTemperatureValueOfChartWithStringValue() {
            var line = "5";
            _temperatureReadLineRule.GetChartValue(line);

            AreEqual(5, _readFile.chart.PseudoReducedTemperature);
        }
        
        [Test]
        public void OnIsMatched_ReturnWhenLineIsNotCommaSeparated() {
            var line = "5";
            var result = _temperatureReadLineRule.IsMatched(line);
            AreEqual(true, result);
        }
    }
}
