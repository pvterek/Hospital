using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Hospital.Database
{
    internal static class DatabaseExist
    {
        internal const string DatabaseName = "HospitalDB.db";
        
        public static void Check(Configuration configuration)
        {
            if (!File.Exists($"{DirectoryExist.DirectoryPath}\\{DatabaseName}"))
            {
                new SchemaExport(configuration).Create(false, true);
            }
            else
            {
                new SchemaUpdate(configuration).Execute(false, true);
            }
        }
    }
}