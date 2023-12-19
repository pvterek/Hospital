using Hospital.PeopleCategories.PatientClass;
using Hospital.Utilities.ListManagment;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;

namespace Hospital.Commands.ManagePatients.ManagePatient
{
    public class ChangeHealthStatusCommand : CompositeCommand
    {
        private readonly IMenuHandler _menuHandler;
        private readonly IListManage _listManage;
        private readonly IListsStorage _listsStorage;

        public ChangeHealthStatusCommand(
            IMenuHandler menuHandler,
            IListManage listManage,
            IListsStorage listsStorage)
            : base(UiMessages.ChangeHealthStatusMessages.Introduce)
        {
            _menuHandler = menuHandler;
            _listManage = listManage;
            _listsStorage = listsStorage;
        }

        public override void Execute()
        {
            if (!_listsStorage.Patients.Any())
            {
                _menuHandler.ShowMessage(UiMessages.DisplayPatientsMessages.NoPatientsPrompt);
                return;
            }

            var patient = _menuHandler.SelectObject(_listsStorage.Patients,
                UiMessages.ChangeHealthStatusMessages.SelectPatientPrompt);
            patient.HealthStatus = _menuHandler.ShowInteractiveMenu<Health>();
            _listManage.Update(patient, _listsStorage.Patients);

            _menuHandler.ShowMessage(string.Format(UiMessages.ChangeHealthStatusMessages.OperationSuccessPrompt,
                patient.Name, patient.Surname));
        }
    }
}