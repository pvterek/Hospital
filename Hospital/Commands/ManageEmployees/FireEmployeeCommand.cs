using Hospital.Commands.Navigation;
using Hospital.Database;
using Hospital.PeopleCategories.Employee;
using Hospital.PeopleCategories.PersonClass;
using Hospital.Utilities.UserInterface;
using NHibernate;

namespace Hospital.Commands.ManageEmployees
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
        private FireEmployeeCommand() : base(UiMessages.FireEmployeeMessages.Introduce) { }

        /// <summary>
        /// Executes the procedure to fire an employee. The employee is selected by the user and removed from the database.
        /// If the operation is successful, a confirmation message is displayed to the user.
        /// </summary>
        public override void Execute()
        {
            using var session = CreateSession.SessionFactory.OpenSession();

            var employees = (List<IEmployee>)DatabaseOperations<IEmployee>.GetAll(session);
            if (!employees.Any())
            {
                Ui.ShowMessage(UiMessages.FireEmployeeMessages.NoEmployeesPrompt);
            }
            else
            {
                Ui.ShowMessage(UiMessages.FireEmployeeMessages.SelectEmployeePrompt);
                
                var employee = FireEmployee(employees, session);

                Ui.ShowMessage(string.Format(UiMessages.FireEmployeeMessages.EmployeeFiredSuccessPrompt, employee.Name, employee.Surname));
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
            var employee = Ui.ShowInteractiveMenu(employees.OfType<Person>().ToList());
            DatabaseOperations<Person>.Delete(employee, session);

            return employee;
        }
    }
}