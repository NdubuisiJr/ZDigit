using NdubuisiJr.Z_Digit.Data.Repository;
using NdubuisiJr.Z_Digit.Domain;
using System.Collections.Generic;

namespace NdubuisiJr.Z_Digit.Infrastructure.Service
{
   public class ReducedZFactorService
    {
        public ReducedZFactorService()
        {
            _reposity = new Repository<ReducedZfactorEntry>();
        }

        public IEnumerable<ReducedZfactorEntry> GetEntries()
        {
            return _reposity.GetAllItems();
        }

        public void Delete(ReducedZfactorEntry entry)
        {
            _reposity.Delete(entry);
            _reposity.Save();
        }

        public void Save(ReducedZfactorEntry entry)
        {
            _reposity.Add(entry);
            _reposity.Save();
        }

        Repository<ReducedZfactorEntry> _reposity;
    }
}
