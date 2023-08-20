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
    /// Represents a command to manage various operations related to staff members.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class ManageStaffCommand : CompositeCommand
    {
        /// <summary>
        /// Holds a singleton instance of the <see cref="ManageStaffCommand"/> class.
        /// </summary>
        private static ManageStaffCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="ManageStaffCommand"/> class.
        /// </summary>
        internal static ManageStaffCommand Instance => _instance ??= new ManageStaffCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageStaffCommand"/> class, providing options to manage staff.
        /// </summary>
        private ManageStaffCommand() : base(UIMessages.ManageStaffMessages.Introduce, new List<CompositeCommand>())
        {
            Commands.Add(HireEmployeeCommand.Instance);
            Commands.Add(FireEmployeeCommand.Instance);
            Commands.Add(DisplayEmployeesCommand.Instance);
            Commands.Add(BackCommand.Instance);
        }

        /// <summary>
        /// Executes the main staff management menu, allowing the user to select from various management options.
        /// </summary>
        public override void Execute()
        {
            CompositeCommand option = UserInterface.ShowInteractiveMenu(Commands);
            option.Execute();
        }
    }
}
