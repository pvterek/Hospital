using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Database;
using Hospital.Objects.DoctorObject;
using Hospital.Objects.NurseObject;
using Hospital.Objects.PatientObject;
using Hospital.Objects.PersonObject;
using NHibernate;

namespace Hospital.Objects.Employee
{
    /// <summary>
    /// Utility class for common database operations related to employees.
    /// </summary>
    internal class EmployeeDatabaseOperations
    {
        /// <summary>
        /// Retrieves all doctors from the database.
        /// </summary>
        /// <param name="session">The database session to use for the operation.</param>
        /// <returns>A list of all doctors.</returns>
        public static List<Doctor> GetAllDoctors(ISession session)
        {
            return (List<Doctor>)DatabaseOperations<Doctor>.GetAll(session);
        }

        /// <summary>
        /// Retrieves all employees from the database.
        /// </summary>
        /// <param name="session">The database session to use for the operation.</param>
        /// <returns>A list of all employees.</returns>
        public static List<IEmployee> GetAllEmployees(ISession session)
        {
            return (List<IEmployee>)DatabaseOperations<IEmployee>.GetAll(session);
        }

        /// <summary>
        /// Deletes an employee from the database.
        /// </summary>
        /// <param name="employee">The employee to delete.</param>
        /// <param name="session">The database session to use for the operation.</param>
        public static void DeleteEmployee(Person employee, ISession session)
        {
            DatabaseOperations<Person>.Delete(employee, session);
        }

        /// <summary>
        /// Adds an employee to the database.
        /// </summary>
        /// <param name="employee">The employee to add.</param>
        /// <param name="session">The database session to use for the operation.</param>
        public static void AddEmployee(Person employee, ISession session)
        {
            DatabaseOperations<Person>.Add(employee, session);
        }
    }
}