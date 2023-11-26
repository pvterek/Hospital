using Hospital.Utilities.UserInterface;
using Hospital.Utilities.ListManagment;
using Hospital.Commands.ManageWards;
using Hospital.Utilities.UserInterface.Interfaces;

namespace Hospital.Commands.ManagePatients.ManagePatient
{
    internal class SignOutPatientCommand : CompositeCommand
    {
        private readonly IMenuHandler _menuHandler;
        private readonly IListManage _listManage;
        private readonly IListsStorage _listsStorage;
        private readonly IManageCapacity _manageCapacity;

        public SignOutPatientCommand(
            IMenuHandler menuHandler,
            IListManage listManage,
            IListsStorage listsStorage,
            IManageCapacity manageCapacity)
            : base(UiMessages.SignOutPatientMessages.Introduce)
        {
            _menuHandler = menuHandler;
            _listManage = listManage;
            _listsStorage = listsStorage;
            _manageCapacity = manageCapacity;
        }

        public override void Execute()
        {
            if (!_listsStorage.Patients.Any())
            {
                _menuHandler.ShowMessage(UiMessages.DisplayPatientsMessages.NoPatientsPrompt);
                return;
            }

            var patient = _menuHandler.SelectObject(_listsStorage.Patients, UiMessages.SignOutPatientMessages.SignOutPrompt);
            _manageCapacity.UpdateWardCapacity(patient.AssignedWard, patient, OperationType.Operation.RemovePatient);
            _listManage.Remove(patient, _listsStorage.Patients);

            _menuHandler.ShowMessage(string.Format(UiMessages.SignOutPatientMessages.SuccessSignOutPrompt, patient.Name, patient.Surname));
        }
    }
}