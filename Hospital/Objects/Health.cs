namespace Hospital.Objects
{
    /// <summary>
    /// Specifies the health status of a patient.
    /// </summary>
    enum Health : byte
    {
        /// <summary>
        /// Represents a very poor health condition.
        /// </summary>
        VeryBad,

        /// <summary>
        /// Represents a poor health condition.
        /// </summary>
        Bad,

        /// <summary>
        /// Represents an average health condition.
        /// </summary>
        Medium,

        /// <summary>
        /// Represents a good health condition.
        /// </summary>
        Good,

        /// <summary>
        /// Represents an excellent health condition.
        /// </summary>
        VeryGood
    }
}
