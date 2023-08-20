using System.Collections.Generic;
using Hospital.Objects.PatientObject;
using Hospital.Objects.WardObject;
using Hospital.Utilities;

namespace Hospital.Commands.ManagePatients
{
    /// <summary>
    /// Represents a command to admit a patient to the hospital.
    /// Inheriting from the <see cref="CompositeCommand"/> class.
    /// </summary>
    internal class AdmitPatientCommand : CompositeCommand
    {
        /// <summary>
        /// Holds a singleton instance of the <see cref="AdmitPatientCommand"/> class.
        /// </summary>
        private static AdmitPatientCommand? _instance;

        /// <summary>
        /// Gets the singleton instance of the <see cref="AdmitPatientCommand"/> class.
        /// </summary>
        internal static AdmitPatientCommand Instance => _instance ??= new AdmitPatientCommand();

        /// <summary>
        /// Initializes a new instance of the <see cref="AdmitPatientCommand"/> class with the specified introduction message.
        /// </summary>
        public AdmitPatientCommand() : base(UIMessages.AdmitPatientMessages.Introduce) { }

        /// <summary>
        /// Executes the admit patient command. If there are no wards available, a message is displayed. 
        /// Otherwise, a patient is created and added to the list of patients.
        /// </summary>
        public override void Execute()
        {
            if (Storage.wards.Count == 0)
            {
                UserInterface.ShowMessage(UIMessages.AdmitPatientMessages.NoWardErrorPrompt);
            }
            else
            {
                Patient patient = PatientFactory.CreatePatient();      
                Storage.patients.Add(patient);
                ManageCapacity.AddPatientsNumber(patient.AssignedWard, patient);
                UserInterface.ShowMessage(UIMessages.AdmitPatientMessages.PatientCreatedPrompt);
            }
        }
    }
}
