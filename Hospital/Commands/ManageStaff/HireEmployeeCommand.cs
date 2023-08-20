using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Commands.ManagePatients;
using Hospital.Objects;
using Hospital.Objects.DoctorObject;
using Hospital.Objects.NurseObject;
using Hospital.Utilities;

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
        /// and then an employee of that type is created and added to the storage.
        /// </summary>
        public override void Execute()
        {
            string employeeType = UserInterface.ShowInteractiveMenu(Storage.employeeFactories.Keys.ToList());

            if (Storage.employeeFactories.TryGetValue(employeeType, out var factory))
            {
                var employee = factory.CreateEmployee();
                Storage.employees.Add((IHasIntroduceString)employee);

                UserInterface.ShowMessage(string.Format(UIMessages.HireEmployeeMessages.HiredSuccessPrompt, employeeType));
            }
        }
    }
}
