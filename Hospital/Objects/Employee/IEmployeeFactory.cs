using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Objects.Employee
{
    /// <summary>
    /// Defines a contract for factory objects responsible for creating employees in the hospital.
    /// </summary>
    internal interface IEmployeeFactory
    {
        /// <summary>
        /// Creates and returns a new instance of an employee.
        /// </summary>
        /// <returns>An object implementing the <see cref="IEmployee"/> interface.</returns>
        IEmployee? CreateEmployee();
    }
}