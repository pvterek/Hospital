using Hospital.Entities.Interfaces;
using Hospital.PeopleCategories.Factory.Interfaces;
using Hospital.PeopleCategories.PersonClass;
using Hospital.Utilities.ListManagment;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;

namespace Hospital.Commands.ManageEmployees
{
    public class CreateEmployeeCommand : CompositeCommand
    {
        private readonly IDTOFactory _dtoFactory;
        private readonly IMenuHandler _menuHandler;
        private readonly IListManage _listManage;
        private readonly IEmployeeFactory _employeeFactory;
        private readonly IListsStorage _listsStorage;

        public CreateEmployeeCommand(
            IDTOFactory dtoFactory,
            IMenuHandler menuHandler,
            IListManage listManage,
            IEmployeeFactory employeeFactory,
            IListsStorage listsStorage)
            : base(UiMessages.CreateEmployeeMessages.Introduce)
        {
            _dtoFactory = dtoFactory;
            _menuHandler = menuHandler;
            _listManage = listManage;
            _employeeFactory = employeeFactory;
            _listsStorage = listsStorage;
        }

        public override void Execute()
        {
            if (!_listsStorage.Wards.Any())
            {
                _menuHandler.ShowMessage(UiMessages.FactoryMessages.NoWardErrorPrompt);
                return;
            }

            var employeeTypes = _employeeFactory.GetEmployeeTypes().ToList();
            var employeeType = _menuHandler.ShowInteractiveMenu(employeeTypes);

            PersonDTO dto = employeeType switch
            {
                UiMessages.DoctorObjectMessages.Position => _dtoFactory.GatherDoctorData(_listsStorage.Wards),
                UiMessages.NurseObjectMessages.Position => _dtoFactory.GatherNurseData(_listsStorage.Wards),
                _ => throw new ArgumentException(
                    string.Format(UiMessages.CreateEmployeeMessages.UnsupportedEntityPrompt, employeeType))
            };

            var employee = _employeeFactory.CreateEmployee(employeeType, dto);
            _listManage.Add((IEmployee)employee, _listsStorage.Employees);
            _menuHandler.ShowMessage(string.Format(
                UiMessages.CreateEmployeeMessages.OperationSuccessPrompt, employee.Name, employee.Surname));
        }
    }
}