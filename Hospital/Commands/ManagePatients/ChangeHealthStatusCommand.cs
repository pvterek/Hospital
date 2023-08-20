using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Objects.PatientObject;
using Hospital.Utilities;

namespace Hospital.Commands.ManagePatients
{
    /// <summary>
    /// Represents a command to change the health status of a patient.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class ChangeHealthStatusCommand : CompositeCommand
    {
        /// <summary>
        /// Holds a singleton instance of the <see cref="ChangeHealthStatusCommand"/> class.
        /// </summary>
        private static ChangeHealthStatusCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="ChangeHealthStatusCommand"/> class.
        /// </summary>
        internal static ChangeHealthStatusCommand Instance => _instance ??= new ChangeHealthStatusCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeHealthStatusCommand"/> class with the specified introduction message.
        /// </summary>
        private ChangeHealthStatusCommand() : base(UIMessages.ChangeHealthStatusMessages.Introduce) { }

        /// <summary>
        /// Executes the command to change the health status of a selected patient. 
        /// It prompts the user to select a patient and then choose the health status from the provided options.
        /// </summary>
        public override void Execute()
        {
            UserInterface.ShowMessage(UIMessages.ChangeHealthStatusMessages.SelectPatientPrompt);
            Patient patient = (Patient)UserInterface.ShowInteractiveMenu(Storage.patients);
            patient.HealthStatus = UserInterface.ShowInteractiveMenu();
        }
    }
}
