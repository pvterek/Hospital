namespace Hospital.PeopleCategories
{
    /// <summary>
    /// Defines a contract for objects that can provide an introducing string in GUI
    /// </summary>
    public interface IHasIntroduceString
    {
        /// <summary>
        /// Gets or sets the introduce string, which represents the command in the GUI.
        /// </summary>
        string IntroduceString { get; }
    }
}
