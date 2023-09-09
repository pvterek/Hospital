using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Commands.Navigation;
using Hospital.Database;
using Hospital.Objects.DoctorObject;
using Hospital.Objects.Employee;
using Hospital.Objects.PatientObject;
using Hospital.Utilities.UI;
using Hospital.Utilities.UI.UserInterface;
using NHibernate;

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
            using var session = Program.sessionFactory.OpenSession();

            try
            {
                List<Patient> patients = PatientDatabaseOperations.GetAllPatients(session);
                List<Doctor> doctors = EmployeeDatabaseOperations.GetAllDoctors(session);

                if (!patients.Any())
                {
                    UI.ShowMessage(UIMessages.DisplayPatientsMessages.NoPatientsPrompt);
                }
                else if (!doctors.Any())
                {
                    UI.ShowMessage(UIMessages.AssignToDoctorMessages.NoDoctorsPrompt);
                }
                else
                {
                    AssignToDoctor(patients, doctors, session);
                }
            }
            catch (Exception ex) 
            {
                UIHelper.HandleError(UIMessages.AssignToDoctorMessages.ErrorAssignToDoctorPrompt, ex);
            }

            NavigationCommand.Instance.Execute();
        }

        /// <summary>
        /// Assigns a patient to a selected doctor from a list and updates the patient's information in the database.
        /// </summary>
        /// <param name="patients">The list of patients to choose from.</param>
        /// <param name="doctors">The list of doctors to choose from for assignment.</param>
        /// <param name="session">The database session to use for the operation.</param>
        private void AssignToDoctor(List<Patient> patients, List<Doctor> doctors, ISession session)
        {
            Patient patient = UI.ShowInteractiveMenu(patients);

            UI.ShowMessage(UIMessages.AssignToDoctorMessages.SelectDoctorPrompt);
            patient.AssignedDoctor = UI.ShowInteractiveMenu(doctors);

            DatabaseOperations<Patient>.Update(patient, session);
        }
    }
}
