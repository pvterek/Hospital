using Hospital.Commands.Navigation;
using Hospital.Database;
using Hospital.PeopleCategories.Employee;
using Hospital.Utilities.UserInterface;

namespace Hospital.Commands.ManageEmployees
{
    /// <summary>
    /// Represents a command to display the list of employees.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class DisplayEmployeesCommand : CompositeCommand
    {
        /// <summary>
        /// Holds a singleton instance of the <see cref="DisplayEmployeesCommand"/> class.
        /// </summary>
        private static DisplayEmployeesCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="DisplayEmployeesCommand"/> class.
        /// </summary>
        internal static DisplayEmployeesCommand Instance => _instance ??= new DisplayEmployeesCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayEmployeesCommand"/> class with a specific introduction message.
        /// </summary>
        private DisplayEmployeesCommand() : base(UiMessages.DisplayEmployeesMessages.Introduce) { }

        /// <summary>
        /// Executes the display procedure for the list of employees. If there are no employees, a prompt will notify the user.
        /// </summary>
        public override void Execute()
        {
            using var session = CreateSession.SessionFactory.OpenSession();

            var employees = (List<IEmployee>)DatabaseOperations<IEmployee>.GetAll(session);
            if (!employees.Any())
            {
                Ui.ShowMessage(UiMessages.DisplayEmployeesMessages.NoEmployeesPrompt);
            }
            else
            {
                ListMaker.DisplayList(employees.ToList());
            }

            NavigationCommand.Instance.Execute();
        }
    }
}