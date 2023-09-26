using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Hospital.Database
{
    /// <summary>
    /// Utility class for checking and initializing the database schema.
    /// </summary>
    internal static class DatabaseExist
    {
        /// <summary>
        /// Checks if the database file exists and creates or updates the schema accordingly.
        /// </summary>
        /// <param name="configuration">The NHibernate configuration.</param>
        public static void Check(Configuration configuration)
        {
            if (!File.Exists("mydatabase.db"))
            {
                new SchemaExport(configuration).Create(true, true);
            }
            else
            {
                new SchemaUpdate(configuration).Execute(true, true);
            }
        }
    }
}