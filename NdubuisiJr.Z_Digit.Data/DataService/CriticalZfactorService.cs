using NdubuisiJr.Z_Digit.Data.Repository;
using NdubuisiJr.Z_Digit.Domain;
using System.Collections.Generic;

namespace NdubuisiJr.Z_Digit.Infrastructure.Service
{
   public class CriticalZfactorService 
    {
        public CriticalZfactorService()
        {
            _repository = new Repository<CriticalZfactorEntry>();
        }

        public IEnumerable<CriticalZfactorEntry> GetEntries()
        {
            return _repository.GetAllItems();
        }

        public void Delete(CriticalZfactorEntry entry)
        {
            _repository.Delete(entry);
            _repository.Save();
        }

        public void Save(CriticalZfactorEntry entry)
        {
            _repository.Add(entry);
            _repository.Save();
        }
        Repository<CriticalZfactorEntry> _repository;
    }
}
