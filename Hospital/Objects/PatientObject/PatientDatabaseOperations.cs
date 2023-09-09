using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Database;
using NHibernate;

namespace Hospital.Objects.PatientObject
{
    /// <summary>
    /// Utility class for common database operations related to patients.
    /// </summary>
    internal class PatientDatabaseOperations
    {
        /// <summary>
        /// Retrieves all patients from the database.
        /// </summary>
        /// <param name="session">The database session to use for the operation.</param>
        /// <returns>A list of all patients.</returns>
        public static List<Patient> GetAllPatients(ISession session)
        {
            return (List<Patient>)DatabaseOperations<Patient>.GetAll(session);
        }

        /// <summary>
        /// Adds a patient to the database.
        /// </summary>
        /// <param name="patient">The patient to add.</param>
        /// <param name="session">The database session to use for the operation.</param>
        public static void AddPatient(Patient patient, ISession session)
        {
            DatabaseOperations<Patient>.Add(patient, session);
        }

        /// <summary>
        /// Deletes a patient from the database.
        /// </summary>
        /// <param name="patient">The patient to delete.</param>
        /// <param name="session">The database session to use for the operation.</param>
        public static void DeletePatient(Patient patient, ISession session)
        {
            DatabaseOperations<Patient>.Delete(patient, session);
        }
    }
}