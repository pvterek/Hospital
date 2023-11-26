using Hospital.Commands.ManagePatients.ManagePatient;
using Hospital.Commands.Navigation;
using Hospital.Entities.Interfaces;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;

namespace Hospital.Commands.ManagePatients
{
    internal class ManagePatientsCommand : CompositeCommand
    {
        private readonly Lazy<AdmitPatientCommand> _admitPatientCommand;
        private readonly Lazy<DisplayPatientsCommand> _displayPatientsCommand;
        private readonly Lazy<AssignToDoctorCommand> _assignToDoctorCommand;
        private readonly Lazy<ChangeHealthStatusCommand> _changeHealthStatusCommand;
        private readonly Lazy<SignOutPatientCommand> _signOutPatientCommand;
        private readonly Lazy<BackCommand> _backCommand;
        private readonly INavigationService _navigationService;
        private readonly IMenuHandler _menuHandler;

        public ManagePatientsCommand(
            Lazy<AdmitPatientCommand> admitPatientCommand,
            Lazy<DisplayPatientsCommand> displayPatientsCommand,
            Lazy<AssignToDoctorCommand> assignToDoctorCommand,
            Lazy<ChangeHealthStatusCommand> changeHealthStatusCommand,
            Lazy<SignOutPatientCommand> signOutPatientCommand,
            Lazy<BackCommand> backCommand,
            INavigationService navigationService,
            IMenuHandler menuHandler)
            : base(UiMessages.ManagePatientsMessages.Introduce)
        {
            _admitPatientCommand = admitPatientCommand;
            _displayPatientsCommand = displayPatientsCommand;
            _assignToDoctorCommand = assignToDoctorCommand;
            _changeHealthStatusCommand = changeHealthStatusCommand;
            _signOutPatientCommand = signOutPatientCommand;
            _backCommand = backCommand;
            _navigationService = navigationService;
            _menuHandler = menuHandler;
        }

        public override void Execute()
        {
            var commands = new List<IHasIntroduceString>
            {
                _admitPatientCommand.Value,
                _displayPatientsCommand.Value,
                _assignToDoctorCommand.Value,
                _changeHealthStatusCommand.Value,
                _signOutPatientCommand.Value,
                _backCommand.Value
            };

            var selectedCommand = _menuHandler.ShowInteractiveMenu(commands);
            _navigationService.Queue((CompositeCommand)selectedCommand);

            switch (selectedCommand.IntroduceString)
            {
                case UiMessages.AdmitPatientMessages.Introduce:
                    _admitPatientCommand.Value.Execute();
                    break;
                case UiMessages.DisplayPatientsMessages.Introduce:
                    _displayPatientsCommand.Value.Execute();
                    break;
                case UiMessages.AssignToDoctorMessages.Introduce:
                    _assignToDoctorCommand.Value.Execute();
                    break;
                case UiMessages.ChangeHealthStatusMessages.Introduce:
                    _changeHealthStatusCommand.Value.Execute();
                    break;
                case UiMessages.SignOutPatientMessages.Introduce:
                    _signOutPatientCommand.Value.Execute();
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