using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Objects.Employee
{
    /// <summary>
    /// Defines a contract for employee objects in the hospital.
    /// </summary>
    public interface IEmployee
    {
        /// <summary>
        /// Gets the position of the employee.
        /// </summary>
        static string Position { get; }
    }
}
