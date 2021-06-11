using FluentNHibernate.Cfg;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace NdubuisiJr.Z_Digit.Data.DataBase
{
    public class SQLiteConfiguration : DBConfiguration
    {
        public override void SynchDataBase()
        {
            config.DataBaseIntegration(x =>
            {
                x.ConnectionString = $"Data Source={_dataBasePath};version=3";
                x.Driver<SQLite20Driver>();
                x.Dialect<SQLiteDialect>();
            });

            _sessionFactory = Fluently.Configure(config)
                                      .Mappings(x => x.FluentMappings.AddFromAssemblyOf<DBConfiguration>())
                                      .ExposeConfiguration(BuildSchemaAction)
                                      .BuildSessionFactory();
        }
    }
}
