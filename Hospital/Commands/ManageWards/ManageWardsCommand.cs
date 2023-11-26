using Hospital.Commands.Navigation;
using Hospital.Entities.Interfaces;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;

namespace Hospital.Commands.ManageWards
{
    internal class ManageWardsCommand : CompositeCommand
    {
        private readonly Lazy<AddWardCommand> _addWardCommand;
        private readonly Lazy<DisplayWardCommand> _displayWardCommand;
        private readonly Lazy<DeleteWardCommand> _deleteWardCommand;
        private readonly Lazy<BackCommand> _backCommand;
        private readonly INavigationService _navigationService;
        private readonly IMenuHandler _menuHandler;

        public ManageWardsCommand(
            Lazy<AddWardCommand> addWardCommand,
            Lazy<DisplayWardCommand> displayWardCommand,
            Lazy<DeleteWardCommand> deleteWardCommand,
            Lazy<BackCommand> backCommand,
            INavigationService navigationService,
            IMenuHandler menuHandler)
            : base(UiMessages.ManageWardsMessages.Introduce)
        {
            _addWardCommand = addWardCommand;
            _displayWardCommand = displayWardCommand;
            _deleteWardCommand = deleteWardCommand;
            _backCommand = backCommand;
            _navigationService = navigationService;
            _menuHandler = menuHandler;
        }

        public override void Execute()
        {
            var commands = new List<IHasIntroduceString>
            {
                _addWardCommand.Value,
                _displayWardCommand.Value,
                _deleteWardCommand.Value,
                _backCommand.Value
            };

            var selectedCommand = _menuHandler.ShowInteractiveMenu(commands);
            _navigationService.Queue((CompositeCommand)selectedCommand);

            switch (selectedCommand.IntroduceString)
            {
                case UiMessages.AddWardMessages.Introduce:
                    _addWardCommand.Value.Execute();
                    break;
                case UiMessages.DisplayWardMessages.Introduce:
                    _displayWardCommand.Value.Execute();
                    break;
                case UiMessages.DeleteWardMessages.Introduce:
                    _deleteWardCommand.Value.Execute();
                    break;
                case UiMessages.BackCommandMessages.Introduce:
                    _backCommand.Value.Execute();
                    break;
                default:
                    Console.WriteLine(UiMessages.ExceptionMessages.Command);
                    break;
            }
        }
    }
}