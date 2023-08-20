using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Objects.PatientObject;

namespace Hospital.Objects.WardObject
{
    /// <summary>
    /// Provides utility methods to manage the capacity of a ward, specifically in relation to patient numbers.
    /// </summary>
    internal class ManageCapacity
    {
        /// <summary>
        /// Adds a patient to the specified ward and updates the patient count for the ward.
        /// </summary>
        /// <param name="ward">The ward to which the patient is being added.</param>
        /// <param name="patient">The patient being added to the ward.</param>
        public static void AddPatientsNumber(Ward ward, Patient patient)
        {
            patient.AssignedWard.Patients.Add(patient);
            ward.PatientsNumber++;
        }

        /// <summary>
        /// Removes a patient from the specified ward and updates the patient count for the ward.
        /// </summary>
        /// <param name="ward">The ward from which the patient is being removed.</param>
        /// <param name="patient">The patient being removed from the ward.</param>
        public static void RemovePatientsNumber(Ward ward, Patient patient)
        {
            patient.AssignedWard.Patients.Remove(patient);
            ward.PatientsNumber--;
        }
    }
}
