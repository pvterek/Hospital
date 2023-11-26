using Hospital.Commands.LoginWindow;
using Hospital.Commands.ManageEmployees;
using Hospital.Commands.ManagePatients;
using Hospital.Commands.ManageWards;

namespace Hospital.Commands.Navigation
{
    internal class NavigationService : INavigationService
    {
        private readonly Stack<CompositeCommand> CommandStack = new();
        private readonly List<Type> NavigationCommands = new() 
        { 
            typeof(MainWindowCommand), 
            typeof(ManageEmployeesCommand), 
            typeof(ManagePatientsCommand), 
            typeof(ManageWardsCommand) 
        };

        public CompositeCommand GetPreviousCommand()
        {
            CommandStack.Pop();
            return CommandStack.Peek();
        }

        public CompositeCommand GetCurrentCommand()
        {
            return CommandStack.Peek();
        }

        public void Queue(CompositeCommand command)
        {
            if (NavigationCommands.Contains(command.GetType()))
                CommandStack.Push(command);
        }
    }
}