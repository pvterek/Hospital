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

namespace Hospital.Commands.ManageStaff
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
        private DisplayEmployeesCommand() : base(UIMessages.DisplayEmployeesMessages.Introduce) { }

        /// <summary>
        /// Executes the display procedure for the list of employees. If there are no employees, a prompt will notify the user.
        /// </summary>
        public override void Execute()
        {
            using var session = Program.sessionFactory.OpenSession();

            try
            {
                List<IEmployee> employees = EmployeeDatabaseOperations.GetAllEmployees(session);
            
                if (!employees.Any())
                {
                    UI.ShowMessage(UIMessages.DisplayEmployeesMessages.NoEmployeesPrompt);
                }
                else
                {
                    DisplayEmployees(employees);
                }    
            }
            catch (Exception ex)
            {
                UIHelper.HandleError(UIMessages.DisplayEmployeesMessages.ErrorDisplayEmployeesPrompt, ex);
            }

            NavigationCommand.Instance.Execute();
        }

        /// <summary>
        /// Displays a list of employees with their introduction messages.
        /// </summary>
        /// <param name="employees">The list of employees to display.</param>
        private void DisplayEmployees(List<IEmployee> employees)
        {
            List<Person> personList = employees.OfType<Person>().ToList();
            var introduceMessages = personList.Select(person => person.IntroduceString).ToList();

            ListMaker.DisplayList(introduceMessages);
        }
    }
}