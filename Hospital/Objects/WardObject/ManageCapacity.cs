using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Objects.PatientObject;
using Hospital.Database;
using NHibernate;
using Hospital.Utilities.UI.UserInterface;

namespace Hospital.Objects.WardObject
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
        public static void UpdateWardCapacity(Ward ward, ISession session)
        {
            ward.IntroduceString = string.Format(UIMessages.WardObjectMessages.Introduce, ward.Name, ward.PatientsNumber, ward.Capacity);
            DatabaseOperations<Ward>.Update(ward, session);
        }
    }
}
