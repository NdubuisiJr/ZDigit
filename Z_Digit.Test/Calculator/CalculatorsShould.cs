using NdubuisiJr.Z_Digit.Data.IO;
using NdubuisiJr.Z_Digit.Module.Utils;
using NUnit.Framework;

namespace Z_Digit.Test.Calculator
{
    [TestFixture]
    public class CalculatorsShould : MainAppDirctory
    {
        Calculators _calculator;
        [SetUp]
        public void SetUp() {
            var data = new DataIO();
            data.Configure(new TextFileConfiguration(Z_DigitDirectory));
            _calculator = new Calculators();
        }

        [Test]
        // underscore (_) = dot (.)
        public void Return1_03ForPressureOf3_5AndTemperatureOf3() {
            var result = _calculator.ZfactorReduced(3, 3.5);
            Assert.AreEqual(1.03, result);

        }
    }
}
