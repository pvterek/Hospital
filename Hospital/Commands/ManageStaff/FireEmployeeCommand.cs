using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Commands.ManagePatients;
using Hospital.Commands.Navigation;
using Hospital.Objects.Employee;
using Hospital.Objects.PersonObject;
using Hospital.Utilities.UI;
using Hospital.Utilities.UI.UserInterface;
using NHibernate;
using NHibernate.Transform;

namespace Hospital.Commands.ManageStaff
{
    /// <summary>
    /// Represents a command to fire (remove) an employee.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class FireEmployeeCommand : CompositeCommand
    {
        /// <summary>
        /// Holds a singleton instance of the <see cref="FireEmployeeCommand"/> class.
        /// </summary>
        private static FireEmployeeCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="FireEmployeeCommand"/> class.
        /// </summary>
        internal static FireEmployeeCommand Instance => _instance ??= new FireEmployeeCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="FireEmployeeCommand"/> class with a specific introduction message.
        /// </summary>
        private FireEmployeeCommand() : base(UIMessages.FireEmployeeMessages.Introduce) { }

        /// <summary>
        /// Executes the procedure to fire an employee. The employee is selected by the user and removed from the database.
        /// If the operation is successful, a confirmation message is displayed to the user.
        /// </summary>
        public override void Execute()
        {
            using var session = Program.sessionFactory.OpenSession();

            try
            {
                UI.ShowMessage(UIMessages.FireEmployeeMessages.SelectEmployeePrompt);

                List<IEmployee> employees = EmployeeDatabaseOperations.GetAllEmployees(session);

                if (!employees.Any())
                {
                    UI.ShowMessage(UIMessages.DisplayEmployeesMessages.NoEmployeesPrompt);
                }
                else
                {
                    Person employee = FireEmployee(employees, session);

                    UI.ShowMessage(string.Format(UIMessages.FireEmployeeMessages.EmployeeFiredSuccessPrompt, employee.Name, employee.Surname));
                }
            }
            catch (Exception ex)
            {
                UIHelper.HandleError(UIMessages.FireEmployeeMessages.EmployeeFiredErrorPrompt, ex);
            }

            NavigationCommand.Instance.Execute();
        }

        /// <summary>
        /// Fires an employee from the list of employees, deletes their record from the database, and returns the fired employee.
        /// </summary>
        /// <param name="employees">The list of employees to choose from.</param>
        /// <param name="session">The database session to use for the operation.</param>
        /// <returns>The employee who has been fired.</returns>
        private Person FireEmployee(List<IEmployee> employees, ISession session)
        { 
            Person employee = UI.ShowInteractiveMenu(employees.OfType<Person>().ToList());

            EmployeeDatabaseOperations.DeleteEmployee(employee, session);

            return employee;
        }
    }
}