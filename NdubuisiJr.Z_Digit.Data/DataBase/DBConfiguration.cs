using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.IO;

namespace NdubuisiJr.Z_Digit.Data.DataBase
{
    public abstract class DBConfiguration : IDBConfiguration
    {
        public static ISession GetSession() {
            return _sessionFactory.OpenSession();
        }

        protected void BuildSchemaAction(Configuration config) {
            new SchemaExport(config).Create(false, !File.Exists(_dataBasePath));
        }

        public abstract void SynchDataBase();

        public static SQLiteConfiguration SqliteConfiguration { get { return new SQLiteConfiguration(); } }

        protected static ISessionFactory _sessionFactory;
        protected Configuration config = new Configuration();
        protected string _dataBasePath = $@"{ System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData)}\Z_Digit.db";
    }
}
