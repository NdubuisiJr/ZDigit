using NdubuisiJr.Z_Digit.Data.IO.Reader;
using NdubuisiJr.Z_Digit.Domain;
using System.Collections.Generic;

namespace NdubuisiJr.Z_Digit.Data.IO
{
    public interface IConfiguration
    {
        void Read();

        List<ZFactorChart> Charts { get; set; }
    }
}
