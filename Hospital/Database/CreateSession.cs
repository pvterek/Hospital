using System.Reflection;
using FluentNHibernate;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate;

namespace Hospital.Database
{
    /// <summary>
    /// Utility class for creating a session factory for NHibernate.
    /// </summary>
    internal static class CreateSession
    {
        /// <summary>
        /// Creates and configures an NHibernate session factory.
        /// </summary>
        /// <returns>An NHibernate session factory.</returns>
        private static ISessionFactory CreateSessionFactory()
        {
            var configuration = new NHibernate.Cfg.Configuration();

            DirectoryExist.Create();

            configuration.DataBaseIntegration(x =>
            {
                x.ConnectionString = $"Data Source={DirectoryExist.DirectoryPath}\\HospitalDB.db;Version=3;";
                x.Driver<SQLite20Driver>();
                x.Dialect<SQLiteDialect>();
            });

            configuration.AddMappingsFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddAssembly(Assembly.GetExecutingAssembly());

            DatabaseExist.Check(configuration);

            return configuration.BuildSessionFactory();
        }
        
        /// <summary>
        /// The NHibernate session factory used for database operations.
        /// </summary>
        public static readonly ISessionFactory SessionFactory = CreateSessionFactory();
    }
}