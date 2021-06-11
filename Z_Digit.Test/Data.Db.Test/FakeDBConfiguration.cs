using NdubuisiJr.Z_Digit.Data.DataBase;
using System.IO;

namespace Z_Digit.Test.Data.Db.Test
{
    public class FakeDBConfiguration : DBConfiguration
    {
        public override void SynchDataBase() {

            FileExits = File.Exists(_dataBasePath);    
        }

        public bool FileExits { get; set; }
    }
}
