namespace Hospital.Commands.ManagePatients
{
    /// <summary>
    /// Contains the types of operations that can be performed on ward capacity.
    /// </summary>
    internal class OperationType
    {
        /// <summary>
        /// Enumerates the different operations that can be performed on ward capacity.
        /// </summary>
        internal enum Operation
        {
            /// <summary>
            /// Represents the operation of adding a new patient.
            /// </summary>
            AddPatient,
            
            /// <summary>
            /// Represents the operation of removing an existing patient.
            /// </summary>
            RemovePatient
        }
    }   
}