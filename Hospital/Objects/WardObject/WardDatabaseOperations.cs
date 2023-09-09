using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Database;
using Hospital.Objects.DoctorObject;
using NHibernate;

namespace Hospital.Objects.WardObject
{
    /// <summary>
    /// Utility class for common database operations related to wards.
    /// </summary>
    internal class WardDatabaseOperations
    {
        /// <summary>
        /// Retrieves all wards from the database.
        /// </summary>
        /// <param name="session">The database session to use for the operation.</param>
        /// <returns>A list of all wards.</returns>
        public static List<Ward> GetAllWards(ISession session)
        {
            return (List<Ward>)DatabaseOperations<Ward>.GetAll(session);
        }

        /// <summary>
        /// Adds a ward to the database.
        /// </summary>
        /// <param name="ward">The ward to add.</param>
        /// <param name="session">The database session to use for the operation.</param>
        public static void AddWard(Ward ward, ISession session)
        {
            DatabaseOperations<Ward>.Add(ward, session);
        }

        /// <summary>
        /// Deletes a ward from the database.
        /// </summary>
        /// <param name="ward">The ward to delete.</param>
        /// <param name="session">The database session to use for the operation.</param>
        public static void DeleteWard(Ward ward, ISession session)
        {
            DatabaseOperations<Ward>.Delete(ward, session);
        }
    }
}
