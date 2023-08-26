using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Objects;
using Hospital.Objects.DoctorObject;
using Hospital.Objects.NurseObject;
using Hospital.Objects.PatientObject;
using Hospital.Objects.UserObject;
using Hospital.Objects.WardObject;

namespace Hospital.Utilities
{
    /// <summary>
    /// Represents a temporary in-memory storage for various entities within the Hospital system.
    /// Note: This class is intended to be replaced by an SQL database in the future.
    /// </summary>
    internal class Storage
    {
        /// <summary>
        /// List of wards within the hospital.
        /// </summary>
        internal static List<IHasIntroduceString> wards = new();

        /// <summary>
        /// List of patients within the hospital.
        /// </summary>
        internal static List<IHasIntroduceString> patients = new();

        /// <summary>
        /// List of employees (doctors, nurses, etc.) within the hospital.
        /// </summary>
        internal static List<IHasIntroduceString> employees = new();

        /// <summary>
        /// List of users that can manage hospital.
        /// </summary>
        internal static List<User> users = new();

        /// <summary>
        /// Mapping of employee positions to their respective factories for creation.
        /// </summary>
        internal static Dictionary<string, IEmployeeFactory> employeeFactories = new()
        {
            { UIMessages.DoctorObjectMessages.Position, new DoctorFactory() },
            { UIMessages.NurseObjectMessages.Position, new NurseFactory() }
        };
    }
}