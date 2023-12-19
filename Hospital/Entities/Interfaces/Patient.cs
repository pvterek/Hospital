namespace Hospital.Entities.Interfaces
{
    public interface IEmployee : IHasIntroduceString
    {
        static string Position { get; }
    }
}