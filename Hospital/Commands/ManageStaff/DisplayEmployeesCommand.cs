using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Commands.ManagePatients;
using Hospital.Utilities;

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
            if (Storage.employees.Count == 0)
            {
                UserInterface.ShowMessage(UIMessages.DisplayEmployeesMessages.NoEmployeesPrompt);
            }
            else
            {
                ListMaker.DisplayList(Storage.employees);
            }
        }
    }
}
