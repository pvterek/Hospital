using Hospital.Commands.Navigation;
using Hospital.Entities.Interfaces;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;

namespace Hospital.Commands.ManageWards
{
    public class ManageWardsCommand : Command
    {
        private readonly Lazy<CreateWardCommand> _createWardCommand;
        private readonly Lazy<DisplayWardCommand> _displayWardCommand;
        private readonly Lazy<DeleteWardCommand> _deleteWardCommand;
        private readonly Lazy<BackCommand> _backCommand;
        private readonly INavigationService _navigationService;
        private readonly IMenuHandler _menuHandler;

        public ManageWardsCommand(
            Lazy<CreateWardCommand> createWardCommand,
            Lazy<DisplayWardCommand> displayWardCommand,
            Lazy<DeleteWardCommand> deleteWardCommand,
            Lazy<BackCommand> backCommand,
            INavigationService navigationService,
            IMenuHandler menuHandler)
            : base(UiMessages.ManageWardsMessages.Introduce)
        {
            _createWardCommand = createWardCommand;
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
                _createWardCommand.Value,
                _displayWardCommand.Value,
                _deleteWardCommand.Value,
                _backCommand.Value
            };

            var selectedCommand = _menuHandler.ShowInteractiveMenu(commands);
            _navigationService.Queue((Command)selectedCommand);

            switch (selectedCommand.IntroduceString)
            {
                case UiMessages.CreateWardMessages.Introduce:
                    _createWardCommand.Value.Execute();
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