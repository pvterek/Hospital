using Hospital.Commands.Navigation;
using Hospital.Database;
using Hospital.PeopleCategories.DoctorClass;
using Hospital.PeopleCategories.PatientClass;
using Hospital.Utilities.UserInterface;
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
        private AssignToDoctorCommand() : base(UiMessages.AssignToDoctorMessages.Introduce) { }

        /// <summary>
        /// Executes the command to assign a patient to a doctor. It prompts the user to select a patient and then a doctor from the provided lists.
        /// </summary>
        public override void Execute()
        {
            using var session = CreateSession.SessionFactory.OpenSession();

            var patients = (List<Patient>)DatabaseOperations<Patient>.GetAll(session);
            var doctors = (List<Doctor>)DatabaseOperations<Doctor>.GetAll(session);

            if (!patients.Any())
            {
                Ui.ShowMessage(UiMessages.DisplayPatientsMessages.NoPatientsPrompt);
            }
            else if (!doctors.Any())
            {
                Ui.ShowMessage(UiMessages.AssignToDoctorMessages.NoDoctorsPrompt);
            }
            else
            {
                var patient = UiHelper.SelectObject(patients, UiMessages.AssignToDoctorMessages.SelectPatientPrompt);
                var doctor = UiHelper.SelectObject(doctors, UiMessages.AssignToDoctorMessages.SelectDoctorPrompt);

                AssignToDoctor(patient, doctor, session);

                Ui.ShowMessage(string.Format(UiMessages.AssignToDoctorMessages.OperationSuccessPrompt, 
                    UiMessages.DoctorObjectMessages.Position, doctor.Surname, patient.Name, patient.Surname));
            }

            NavigationCommand.Instance.Execute();
        }

        /// <summary>
        /// Assigns the provided patient to the specified doctor and updates the patient's information in the database.
        /// </summary>
        /// <param name="patient">The patient to be assigned to a doctor.</param>
        /// <param name="doctor">The doctor to whom the patient will be assigned.</param>
        /// <param name="session">The database session to use for the operation.</param>
        private void AssignToDoctor(Patient patient, Doctor doctor, ISession session)
        {
            patient.AssignedDoctor = doctor;

            DatabaseOperations<Patient>.Update(patient, session);
        }
    }
}