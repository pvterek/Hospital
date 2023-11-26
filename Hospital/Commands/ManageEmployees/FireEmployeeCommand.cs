using Hospital.PeopleCategories.PersonClass;
using Hospital.Utilities.ListManagment;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;

namespace Hospital.Commands.ManageEmployees
{
    internal class FireEmployeeCommand : CompositeCommand
    {
        private readonly IMenuHandler _menuHandler;
        private readonly IListManage _listManage;
        private readonly IListsStorage _listsStorage;

        public FireEmployeeCommand(
            IMenuHandler menuHandler,
            IListManage listManage,
            IListsStorage listsStorage)
            : base(UiMessages.FireEmployeeMessages.Introduce)
        {
            _menuHandler = menuHandler;
            _listManage = listManage;
            _listsStorage = listsStorage;
        }

        public override void Execute()
        {
            if (!_listsStorage.Employees.Any())
            {
                _menuHandler.ShowMessage(UiMessages.FireEmployeeMessages.NoEmployeesPrompt);
            }
            else
            {
                _menuHandler.ShowMessage(UiMessages.FireEmployeeMessages.SelectEmployeePrompt);

                var employee = _menuHandler.ShowInteractiveMenu(_listsStorage.Employees.ToList());
                _listManage.Remove(employee, _listsStorage.Employees);

                _menuHandler.ShowMessage(string.Format(UiMessages.FireEmployeeMessages.EmployeeFiredSuccessPrompt,
                    ((Person)employee).Name, ((Person)employee).Surname));
            }
        }
    }
}