using NdubuisiJr.Z_Digit.Data.DataBase;
using NHibernate;
using NHibernate.Linq;
using System.Linq;
using System.Collections.Generic;

namespace NdubuisiJr.Z_Digit.Data.Repository
{
    public class Repository<T> where T : class
    {
        public Repository()
        {
            _session = DBConfiguration.GetSession();
            FetchAll();
        }

        public IEnumerable<T> GetAllItems()
        {
            FetchAll();
            return _items;
        }

        public void Delete(T item)
        {
            using(var transaction = _session.BeginTransaction())
            {
                _session.Delete(item);
            }
        }

        public void Add(T item)
        {
            using(var transaction = _session.BeginTransaction())
            {
                _session.Save(item);
            }
        }

        public void Save()
        {
            using(var transaction = _session.BeginTransaction())
            {
                transaction.Commit();
            }   
        }

        private void FetchAll()
        {
            using (var transaction = _session.BeginTransaction())
            {
                _items = from item in _session.Query<T>()
                         select item;
            }
        }

        private ISession _session;
        private IEnumerable<T> _items;
    }
}
