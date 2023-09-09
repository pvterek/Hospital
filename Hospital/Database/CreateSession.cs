using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate;
using FluentNHibernate.Automapping;
using NHibernate.Tool.hbm2ddl;

namespace Hospital.Database
{
    /// <summary>
    /// Utility class for creating a session factory for NHibernate.
    /// </summary>
    internal class CreateSession
    {
        /// <summary>
        /// Creates and configures an NHibernate session factory.
        /// </summary>
        /// <returns>An NHibernate session factory.</returns>
        internal static ISessionFactory CreateSessionFactory()
        {
            var configuration = new NHibernate.Cfg.Configuration();

            DirectoryExist.Create();

            configuration.DataBaseIntegration(x =>
            {
                x.ConnectionString = $"Data Source={DirectoryExist.directoryPath}\\HospitalDB.db;Version=3;";
                x.Driver<SQLite20Driver>();
                x.Dialect<SQLiteDialect>();
            });

            configuration.AddMappingsFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddAssembly(Assembly.GetExecutingAssembly());

            DatabaseExist.Check(configuration);

            return configuration.BuildSessionFactory();
        }
    }
}