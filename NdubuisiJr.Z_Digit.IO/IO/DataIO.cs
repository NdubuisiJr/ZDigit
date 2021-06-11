using NdubuisiJr.Z_Digit.Data.IO.Reader;
using NdubuisiJr.Z_Digit.Domain;
using System.Collections.Generic;

namespace NdubuisiJr.Z_Digit.Data.IO
{
    public class DataIO
    {
        public void Configure(IConfiguration config) {
            _config = config;
            _config.Read();
            Charts = _config.Charts;
        }

        public IEnumerable<ZFactorChart> GetCharts()
        {
            return Charts;
        }

        public IEnumerable<ZFactorChart> Charts;

        IConfiguration _config;
    }
}
