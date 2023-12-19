namespace Hospital.Commands.Navigation
{
    public interface INavigationService
    {
        CompositeCommand GetPreviousCommand();
        CompositeCommand GetCurrentCommand();
        void Queue(CompositeCommand command);
    }
}