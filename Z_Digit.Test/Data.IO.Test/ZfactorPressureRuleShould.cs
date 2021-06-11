using NdubuisiJr.Z_Digit.Data.IO.Reader;
using NdubuisiJr.Z_Digit.Data.IO.TextInputRules;
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace Z_Digit.Test.Data.IO.Test
{

    [TestFixture]
    public class ZfactorPressureRuleShould {
        IReadLineRule _zfactorPressureRule;
        ITextFileReader _readFile;
        [SetUp]
        public void InitializeTest() {
            _readFile = new TextFileReader();
            _zfactorPressureRule = new ZFactorPressureRule(_readFile);
        }

        [Test]
        public void OnGetChartValue_UpdateZfactorValueOfChartFromLine() {
            var line = "2,3";

            _zfactorPressureRule.GetChartValue(line);
            var zfactor = _readFile.chart.ZFactors[0];

            AreEqual(3, zfactor);
        }

        [Test]
        public void OnGetChartValue_UpdatePressureValueOfChartFromLine() {
            var line = "5,6";

            _zfactorPressureRule.GetChartValue(line);
            var pressure = _readFile.chart.PseudoReducedPressures[0];

            AreEqual(5, pressure);
        }

        [Test]
        public void OnIsMatched_ReturnsTrueWhenLineContainsComma() {
            var line = "2,4";

            var result =_zfactorPressureRule.IsMatched(line);

            AreEqual(true, result);
        }
    }
}
