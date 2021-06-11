using NdubuisiJr.Z_Digit.Resources;
using NUnit.Framework;

namespace Z_Digit.Test
{
    [TestFixture]
    public class KeyCheckerShould
    {
        KeyChecker _keyChecker;

        [SetUp]
        public void InitializeTest() {
            _keyChecker = new KeyChecker();
        }

        [Test]
        public void ReturnTrueWhenKeysBetween34And43arePressedForDouble() {
            for (int i =34; i < 44; i++) {
                var resultDouble = _keyChecker.CheckDouble(i);
                Assert.AreEqual(true, resultDouble);
            }
        }

        [Test]
        public void ReturnTrueWhenKeysBetween74And83arePressedForDouble() {
            for (int i = 74; i < 84; i++) {
                var resultDouble = _keyChecker.CheckDouble(i);
                Assert.AreEqual(true, resultDouble);
            }
        }

        [Test]
        public void ReturnTrueWhenKeysBetween74And83arePressedForInteger() {
            for (int i = 74; i < 84; i++) {
                var resultInteger = _keyChecker.CheckInteger(i);
                Assert.AreEqual(true, resultInteger);
            }
        }

        [Test]
        public void ReturnTrueWhenKeysBetween34And43arePressedForInteger() {
            for (int i = 34; i < 44; i++) {
                var resultInteger = _keyChecker.CheckInteger(i);
                Assert.AreEqual(true, resultInteger);
            }
        }

        [Test]
        public void ReturnsTrueWhen88isCalledOnCheckDouble() {
            var result = _keyChecker.CheckDouble(88);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void ReturnsTrueWhen43isCalledOnCheckDouble() {
            var result = _keyChecker.CheckDouble(43);
            Assert.AreEqual(true, result);
        }
    }
}
