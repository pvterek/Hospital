using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Data;
using Hospital.Commands.ManagePatients;
using Hospital.Commands.Navigation;
using Hospital.Objects.DoctorObject;
using Hospital.Objects.Employee;
using Hospital.Objects.NurseObject;
using Hospital.Objects.PersonObject;
using Hospital.Utilities.UI;
using Hospital.Utilities.UI.UserInterface;

namespace Hospital.Commands.ManageStaff
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
        private HireEmployeeCommand() : base(UIMessages.HireEmployeeMessages.Introduce) { }

        /// <summary>
        /// Executes the procedure to hire an employee. The type of employee is selected by the user, 
        /// and then an employee of that type is created and added to the database.
        /// </summary>
        public override void Execute()
        {
            using var session = Program.sessionFactory.OpenSession();

            string employeeType = UI.ShowInteractiveMenu(Specializations.employeeFactories.Keys.ToList());
            
            try
            {
                if (Specializations.employeeFactories.TryGetValue(employeeType, out var factory))
                {
                    Person? employee = (Person)factory.CreateEmployee();

                    if (employee == null)
                    {
                        return;
                    }

                    EmployeeDatabaseOperations.AddEmployee(employee, session);

                    UI.ShowMessage(string.Format(UIMessages.HireEmployeeMessages.SuccessHireEmployeePrompt, employee.Name, employee.Surname));
                }
                else
                {
                    UI.ShowMessage(UIMessages.HireEmployeeMessages.ErrorHireEmployeePrompt);
                }
            }
            catch (Exception ex)
            {
                UIHelper.HandleError(UIMessages.HireEmployeeMessages.ErrorHireEmployeePrompt, ex);
            }

            NavigationCommand.Instance.Execute();
        }
    }
}