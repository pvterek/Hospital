using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Objects.DoctorObject;
using Hospital.Objects.NurseObject;
using Hospital.Objects.PersonObject;
using Hospital.Utilities;

namespace Hospital.Objects.Employee
{
    /// <summary>
    /// Utility class containing a dictionary of employee specialization factories.
    /// </summary>
    public class Specializations
    {
        /// <summary>
        /// Dictionary of employee specialization factories.
        /// </summary>
        internal static Dictionary<string, IEmployeeFactory> employeeFactories = new()
        {
            { Doctor.Position, new DoctorFactory() },
            { Nurse.Position, new NurseFactory() }
        };
    }
}
