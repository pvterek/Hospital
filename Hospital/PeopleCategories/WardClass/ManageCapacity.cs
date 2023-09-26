using Hospital.Commands.ManagePatients;
using Hospital.Database;
using Hospital.PeopleCategories.PatientClass;
using Hospital.Utilities.UserInterface;
using NHibernate;

namespace Hospital.PeopleCategories.WardClass
{
    /// <summary>
    /// Provides utility method to manage the capacity of a ward, specifically in relation to patient numbers.
    /// </summary>
    internal class ManageCapacity
    {
        /// <summary>
        /// Updates the capacity and introduce string of a hospital ward in the database.
        /// </summary>
        /// <param name="ward">The ward to update.</param>
        /// <param name="session">The database session to use for the operation.</param>
        public static void UpdateWardCapacity(Ward ward, Patient patient, OperationType.Operation operation, ISession session)
        {
            switch (operation)
            {
                case OperationType.Operation.AddPatient:
                    ward.AssignedPatients.Add(patient);
                    break;
                case OperationType.Operation.RemovePatient:
                    ward.AssignedPatients.Remove(patient);
                    break;
            }
            
            ward.IntroduceString = string.Format(UiMessages.WardObjectMessages.Introduce, ward.Name, ward.PatientsNumber, ward.Capacity);
            DatabaseOperations<Ward>.Update(ward, session);
        }
    }
}
