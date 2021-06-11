using NdubuisiJr.Z_Digit.Domain;
using System.Collections.Generic;

namespace NdubuisiJr.Z_Digit.Infrastructure {
    public interface IDataService {
        IEnumerable<ZFactorChart> GetData();
    }
}
