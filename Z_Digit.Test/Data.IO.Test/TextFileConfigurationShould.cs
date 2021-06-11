//using NdubuisiJr.Z_Digit.Data.IO;
//using NdubuisiJr.Z_Digit.Data.IO.Reader;
//using NUnit.Framework;
//using static NUnit.Framework.Assert;

//namespace Z_Digit.Test.Data.IO.Test
//{

//    [TestFixture]
//    public class TextFileConfigurationShould : MainAppDirctory
//    {
//        IConfiguration _textFileConfiguration;
//        TextFileReader _readFile;

//        [SetUp]
//        public void Initialize() {
//            _textFileConfiguration = new TextFileConfiguration(Z_DigitDirectory);
//            _readFile = new TextFileReader();
//        }
//        [Test]
//        public void OnRead_UpdateChartPropertyWith5Charts() {
//            _textFileConfiguration.Read(_readFile);

//            AreEqual(5, _textFileConfiguration.Charts.Count);
//        }

//        [Test]
//        public void HaveDistinctTemperatureValuesForAllChart() {
//            _textFileConfiguration.Read(_readFile);
//            for (int i = 0; i < _textFileConfiguration.Charts.Count - 1; i++) {
//                var firstTemp = _textFileConfiguration.Charts[i].PseudoReducedTemperature;
//                var secondTemp = _textFileConfiguration.Charts[i + 1].PseudoReducedTemperature;
//                AreNotEqual(firstTemp, secondTemp);
//            }
//        }

//        [Test]
//        public void HaveChartPropertyThatContainsCollectionOfPressureWithCountEquals17() {
//            _textFileConfiguration.Read(_readFile);

//            var pressureCount = _textFileConfiguration.Charts[0].PseudoReducedPressures.Count;

//            AreEqual(17, pressureCount);
//        }

//        [Test]
//        public void HaveChartPropertyThatContainsCollectionOfZfactorWithCountEquals17() {
//            _textFileConfiguration.Read(_readFile);

//            var zfactorCount = _textFileConfiguration.Charts[0].ZFactors.Count;

//            AreEqual(17, zfactorCount);
//        }
//    }
//}
