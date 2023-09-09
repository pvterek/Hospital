using System.Collections.Generic;
using Antlr.Runtime.Tree;
using Hospital.Commands.Navigation;
using Hospital.Objects.PatientObject;
using Hospital.Objects.WardObject;
using Hospital.Utilities.UI;
using Hospital.Utilities.UI.UserInterface;
using NHibernate;
using NHibernate.Id.Insert;

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
            using var session = Program.sessionFactory.OpenSession();

            try
            {
                List<Ward> wards = WardDatabaseOperations.GetAllWards(session);    

                if (!wards.Any())
                {
                    UI.ShowMessage(UIMessages.AdmitPatientMessages.NoWardErrorPrompt);
                }
                else
                {
                    AdmitPatient(session);
                }
            }
            catch (Exception ex) 
            {
                UIHelper.HandleError(UIMessages.AdmitPatientMessages.ErrorAdmitPatientPropmt, ex);
            }

            NavigationCommand.Instance.Execute();
        }

        /// <summary>
        /// Admits a new patient, creates their record in the database, and updates ward capacity.
        /// </summary>
        /// <param name="session">The database session to use for the operation.</param>
        private void AdmitPatient(ISession session)
        {
            Patient patient = PatientFactory.CreatePatient(session);

            if (patient == null)
            {
                return;
            }

            PatientDatabaseOperations.AddPatient(patient, session);
            ManageCapacity.UpdateWardCapacity(patient.AssignedWard, session);

            UI.ShowMessage(string.Format(UIMessages.AdmitPatientMessages.PatientCreatedPrompt, patient.Name, patient.Surname));
        }
    }
}