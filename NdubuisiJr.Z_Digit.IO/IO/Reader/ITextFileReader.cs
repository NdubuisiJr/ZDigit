using NdubuisiJr.Z_Digit.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NdubuisiJr.Z_Digit.Data.IO.Reader
{
    public interface ITextFileReader
    {

        void ReadLine(string line);

        List<ZFactorChart> Charts { get; set; }

        ZFactorChart chart { get; set; }
    }
}
