using System;
using System.IO;
using System.Linq;

namespace Z_Digit.Test
{
    public class MainAppDirctory
    {

        public string Z_DigitDirectory {
            get {
                var baseDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent;
                var directory = baseDirectory.GetDirectories().FirstOrDefault(x => x.Name.Equals("Z_Digit"))
                                             .GetDirectories().FirstOrDefault(x => x.Name.Equals("bin"))
                                             .GetDirectories().FirstOrDefault(x => x.Name.Equals("Debug"))
                                             .FullName;
                return $"{directory}//zDigit.csv";
            }
        }
    }
}
