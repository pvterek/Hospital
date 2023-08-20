using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Objects.PatientObject;
using Hospital.Utilities;
using Hospital.Objects.WardObject;

namespace Hospital.Commands.ManagePatients
{
    /// <summary>
    /// Represents a command to sign out a patient from the hospital.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class SignOutPatientCommand : CompositeCommand
    {
        /// <summary>
        /// Holds a singleton instance of the <see cref="SignOutPatientCommand"/> class.
        /// </summary>
        private static SignOutPatientCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="SignOutPatientCommand"/> class.
        /// </summary>
        internal static SignOutPatientCommand Instance => _instance ??= new SignOutPatientCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="SignOutPatientCommand"/> class with a specific introduction message.
        /// </summary>
        private SignOutPatientCommand() : base(UIMessages.SignOutPatientMessages.Introduce) { }

        /// <summary>
        /// Executes the sign-out procedure for a patient. The patient will be removed from both the general storage and their assigned ward.
        /// </summary>
        public override void Execute()
        {
            UserInterface.ShowMessage(UIMessages.SignOutPatientMessages.SignOutPrompt);
            Patient patient = (Patient)UserInterface.ShowInteractiveMenu(Storage.patients);

            if (Storage.patients.Remove(patient))
            {
                patient.AssignedWard.Patients.Remove(patient);

                // Adjust the capacity of the ward based on the removed patient.
                ManageCapacity.RemovePatientsNumber(patient.AssignedWard, patient);

                UserInterface.ShowMessage(string.Format(UIMessages.SignOutPatientMessages.SuccessSignOutPrompt, patient.Name, patient.Surname));
            }
            else
            {
                UserInterface.ShowMessage(UIMessages.SignOutPatientMessages.ErrorSignOutPrompt);
            }
        }
    }
}
