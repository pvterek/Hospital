using Hospital.Commands.Navigation;
using Hospital.Database;
using Hospital.PeopleCategories.Employee;
using Hospital.PeopleCategories.PersonClass;
using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.UserInterface;
using NHibernate;

namespace Hospital.Commands.ManageEmployees
{
    /// <summary>
    /// Represents a command to hire (add) an employee.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class HireEmployeeCommand : CompositeCommand
    {
        /// <summary>
        /// Holds a singleton instance of the <see cref="HireEmployeeCommand"/> class.
        /// </summary>
        private static HireEmployeeCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="HireEmployeeCommand"/> class.
        /// </summary>
        internal static HireEmployeeCommand Instance => _instance ??= new HireEmployeeCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="HireEmployeeCommand"/> class with a specific introduction message.
        /// </summary>
        private HireEmployeeCommand() : base(UiMessages.HireEmployeeMessages.Introduce) { }

        /// <summary>
        /// Executes the procedure to hire an employee. The type of employee is selected by the user, 
        /// and then an employee of that type is created and added to the database.
        /// </summary>
        public override void Execute()
        {
            using var session = CreateSession.SessionFactory.OpenSession();

            var employeeType = Ui.ShowInteractiveMenu(Specializations.EmployeeFactories.Keys.ToList());

            var wards = (List<Ward>)DatabaseOperations<Ward>.GetAll(session);
            if (!wards.Any())
            {
                Ui.ShowMessage(UiMessages.FactoryMessages.NoWardErrorPrompt);
            }
            else if (Specializations.EmployeeFactories.TryGetValue(employeeType, out var factory))
            {
                var employee = HireEmployee(factory, session, wards);

                Ui.ShowMessage(string.Format(UiMessages.HireEmployeeMessages.SuccessHireEmployeePrompt, employee.Name, employee.Surname));
            }
            else
            {
                Ui.ShowMessage(UiMessages.HireEmployeeMessages.ErrorHireEmployeePrompt);
            }

            NavigationCommand.Instance.Execute();
        }

        /// <summary>
        /// Hire employee, add their record to the database, and returns the hired employee.
        /// </summary>
        /// <param name="factory">Factory used to create selected employee.</param>
        /// <param name="session">The database session to use for the operation.</param>
        /// <returns>The employee who has been hired.</returns>
        private Person HireEmployee(IEmployeeFactory factory, ISession session, List<Ward> wards)
        {
            var employee = (Person)factory.CreateEmployee(wards);
            DatabaseOperations<Person>.Add(employee, session);

            return employee;
        }
    }
}