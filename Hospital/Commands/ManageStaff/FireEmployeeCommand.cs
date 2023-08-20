using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Commands.ManagePatients;
using Hospital.Objects;
using Hospital.Utilities;

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
        /// Executes the procedure to fire an employee. The employee is selected by the user and removed from the storage.
        /// If the operation is successful, a confirmation message is displayed to the user.
        /// </summary>
        public override void Execute()
        {
            UserInterface.ShowMessage(UIMessages.FireEmployeeMessages.SelectEmployeePrompt);

            IEmployee employee = (IEmployee)UserInterface.ShowInteractiveMenu(Storage.employees);
            if (Storage.employees.Remove((IHasIntroduceString)employee))
            {
                UserInterface.ShowMessage(string.Format(UIMessages.FireEmployeeMessages.EmployeeFiredSuccessPrompt, employee.Position));
            }
            else
            {
                UserInterface.ShowMessage(UIMessages.FireEmployeeMessages.EmployeeFiredErrorPrompt);
            }
        }
    }
}
