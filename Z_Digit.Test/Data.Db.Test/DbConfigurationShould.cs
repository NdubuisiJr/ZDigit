using NdubuisiJr.Z_Digit.Data.DataBase;
using NUnit.Framework;

namespace Z_Digit.Test.Data.Db.Test
{
    [TestFixture]
    public class DbConfigurationShould
    {
        DBConfiguration _config;
        [Test]
        public void BuildDbSchemaIfItDoesNotExits() {

            _config = new FakeDBConfiguration();

            _config.SynchDataBase();

            Assert.AreEqual(true, ((FakeDBConfiguration)_config).FileExits);
        }
    }
}
