namespace Hospital.Commands.Navigation
{
    internal interface INavigationService
    {
        CompositeCommand GetPreviousCommand();
        CompositeCommand GetCurrentCommand();
        void Queue(CompositeCommand command);
    }
}