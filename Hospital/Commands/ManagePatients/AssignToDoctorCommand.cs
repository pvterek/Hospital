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
    /// Represents a command to assign a patient to a doctor.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class AssignToDoctorCommand : CompositeCommand
    {
        /// <summary>
        /// Holds a singleton instance of the <see cref="AssignToDoctorCommand"/> class.
        /// </summary>
        private static AssignToDoctorCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="AssignToDoctorCommand"/> class.
        /// </summary>
        internal static AssignToDoctorCommand Instance => _instance ??= new AssignToDoctorCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="AssignToDoctorCommand"/> class with the specified introduction message.
        /// </summary>
        private AssignToDoctorCommand() : base(UIMessages.AssignToDoctorMessages.Introduce) { }

        /// <summary>
        /// Executes the command to assign a patient to a doctor. It prompts the user to select a patient and then a doctor from the provided lists.
        /// </summary>
        public override void Execute()
        {
            UserInterface.ShowMessage(UIMessages.AssignToDoctorMessages.SelectPatientPrompt);
            Patient patient = (Patient)UserInterface.ShowInteractiveMenu(Storage.patients);
            UserInterface.ShowMessage(UIMessages.AssignToDoctorMessages.SelectDoctorPrompt);
            patient.AssignedDoctor = (Objects.DoctorObject.Doctor)UserInterface.ShowInteractiveMenu(Storage.employees);
        }
    }
}
