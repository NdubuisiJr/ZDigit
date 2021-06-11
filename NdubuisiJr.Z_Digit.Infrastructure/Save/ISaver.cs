using NdubuisiJr.Z_Digit.Domain;
using System.Collections.Generic;

namespace NdubuisiJr.Z_Digit.Infrastructure.Save
{
    public interface ISaver
    {
        void Save();

        IEnumerable<Entity> LoadComboBox();
    }
}
