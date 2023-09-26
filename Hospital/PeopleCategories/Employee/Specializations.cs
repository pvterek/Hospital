using Hospital.PeopleCategories.DoctorClass;
using Hospital.PeopleCategories.NurseClass;

namespace Hospital.PeopleCategories.Employee
{
    /// <summary>
    /// Utility class containing a dictionary of employee specialization factories.
    /// </summary>
    public class Specializations
    {
        /// <summary>
        /// Dictionary of employee specialization factories.
        /// </summary>
        internal static readonly Dictionary<string, IEmployeeFactory> EmployeeFactories = new()
        {
            { Doctor.Position, new DoctorFactory() },
            { Nurse.Position, new NurseFactory() }
        };
    }
}
