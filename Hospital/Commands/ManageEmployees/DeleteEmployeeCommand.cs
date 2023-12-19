using Hospital.PeopleCategories.PersonClass;
using Hospital.Utilities.ListManagment;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;

namespace Hospital.Commands.ManageEmployees
{
    public class DeleteEmployeeCommand : CompositeCommand
    {
        private readonly IMenuHandler _menuHandler;
        private readonly IListManage _listManage;
        private readonly IListsStorage _listsStorage;

        public DeleteEmployeeCommand(
            IMenuHandler menuHandler,
            IListManage listManage,
            IListsStorage listsStorage)
            : base(UiMessages.DeleteEmployeeMessages.Introduce)
        {
            _menuHandler = menuHandler;
            _listManage = listManage;
            _listsStorage = listsStorage;
        }

        public override void Execute()
        {
            if (!_listsStorage.Employees.Any())
            {
                _menuHandler.ShowMessage(UiMessages.DeleteEmployeeMessages.NoEmployeesPrompt);
                return;
            }

            _menuHandler.ShowMessage(UiMessages.DeleteEmployeeMessages.SelectPrompt);

            var employee = _menuHandler.ShowInteractiveMenu(_listsStorage.Employees.ToList());
            _listManage.Remove(employee, _listsStorage.Employees);

            _menuHandler.ShowMessage(string.Format(UiMessages.DeleteEmployeeMessages.OperationSuccessPrompt,
                ((Person)employee).Name, ((Person)employee).Surname));
        }
    }
}