using System.Reflection;
using FluentNHibernate;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate;

namespace Hospital.Database
{
    internal static class CreateSession
    {
        private static ISessionFactory CreateSessionFactory()
        {
            var configuration = new NHibernate.Cfg.Configuration();

            DirectoryExist.Create();

            configuration.DataBaseIntegration(x =>
            {
                x.ConnectionString = $"Data Source={DirectoryExist.DirectoryPath}\\{DatabaseExist.DatabaseName};Version=3;";
                x.Driver<SQLite20Driver>();
                x.Dialect<SQLiteDialect>();
            });

            configuration.AddMappingsFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddAssembly(Assembly.GetExecutingAssembly());

            DatabaseExist.Check(configuration);

            return configuration.BuildSessionFactory();
        }
        
        private static ISessionFactory? _sessionFactory;

        internal static ISessionFactory SessionFactory
        {
            get { return _sessionFactory ??= CreateSessionFactory(); }
        }
    }
}