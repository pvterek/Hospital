using Hospital.Commands.ManageEmployees;
using Hospital.Entities.Interfaces;
using Hospital.PeopleCategories.DoctorClass;
using Hospital.PeopleCategories.Factory.Interfaces;
using Hospital.PeopleCategories.NurseClass;
using Hospital.PeopleCategories.PersonClass;
using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.ListManagment;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;
using Moq;

namespace Hospital.Test.ManageEmployeesTests
{
    public class CreateEmployeeCommandTest
    {
        private Mock<IDTOFactory> mockDtoFactory;
        private Mock<IMenuHandler> mockMenuHandler;
        private Mock<IListManage> mockListManage;
        private Mock<IEmployeeFactory> mockEmployeeFactory;
        private Mock<IListsStorage> mockListsStorage;

        private CreateEmployeeCommand createEmployeeCommand;

        private void SetUpMocks()
        {
            mockDtoFactory = new Mock<IDTOFactory>();
            mockMenuHandler = new Mock<IMenuHandler>();
            mockListManage = new Mock<IListManage>();
            mockEmployeeFactory = new Mock<IEmployeeFactory>();
            mockListsStorage = new Mock<IListsStorage>();

            createEmployeeCommand = new CreateEmployeeCommand(
                mockDtoFactory.Object,
                mockMenuHandler.Object,
                mockListManage.Object,
                mockEmployeeFactory.Object,
                mockListsStorage.Object);
        }

        [Fact]
        public void Execute_WhenNoWard_ShouldReturnEarly()
        {
            SetUpMocks();

            mockListsStorage.Setup(x => x.Wards)
                .Returns([]);

            createEmployeeCommand.Execute();

            mockMenuHandler.Verify(x => x.ShowMessage(UiMessages.FactoryMessages.NoWardErrorPrompt), Times.Once());
            mockEmployeeFactory.Verify(x => x.GetEmployeeTypes(), Times.Never());
        }

        [Fact]
        public void Execute_WhenWrongEmployeeType_ShouldThrowException()
        {
            SetUpMocks();

            var mockWard = new Mock<Ward>();
            mockListsStorage.Setup(x => x.Wards)
                .Returns([mockWard.Object]);

            mockMenuHandler.Setup(x => x.ShowInteractiveMenu(new List<string>()))
                .Returns(string.Empty);

            var command = createEmployeeCommand;

            Assert.Throws<ArgumentException>(command.Execute);
        }

        [Theory]
        [InlineData(UiMessages.DoctorObjectMessages.Position)]
        [InlineData(UiMessages.NurseObjectMessages.Position)]
        public void Execute_WhenIsWardAndCorrectEmployeeType_ShouldCreateEmployee(string employeeType)
        {
            SetUpMocks();

            var mockDoctor = new Mock<Doctor>();
            var mockNurse = new Mock<Nurse>();
            var mockWard = new Mock<Ward>();
            var employeesList = new List<IEmployee>();
            var employeeTypes = new List<string>
            {
                UiMessages.DoctorObjectMessages.Position,
                UiMessages.NurseObjectMessages.Position
            };

            mockListsStorage.Setup(x => x.Wards)
                .Returns([mockWard.Object]);
            mockListsStorage.Setup(x => x.Employees)
                .Returns(employeesList);

            mockEmployeeFactory.Setup(x => x.GetEmployeeTypes())
                .Returns(employeeTypes);
            mockMenuHandler.Setup(x => x.ShowInteractiveMenu(employeeTypes))
                .Returns(employeeType);


            var doctorDTO = new DoctorDTO(new PersonDTO());
            mockDtoFactory.Setup(x => x.GatherDoctorData(new List<Ward>() { mockWard.Object }))
                .Returns(doctorDTO);

            var nurseDTO = new NurseDTO(new PersonDTO());
            mockDtoFactory.Setup(x => x.GatherNurseData(new List<Ward>() { mockWard.Object }))
                .Returns(nurseDTO);

            switch (employeeType)
            {
                case UiMessages.DoctorObjectMessages.Position:
                    mockEmployeeFactory.Setup(x => x.CreateEmployee(UiMessages.DoctorObjectMessages.Position, doctorDTO))
                        .Returns(mockDoctor.Object);
                    return;

                case UiMessages.NurseObjectMessages.Position:
                    mockEmployeeFactory.Setup(x => x.CreateEmployee(UiMessages.NurseObjectMessages.Position, nurseDTO))
                        .Returns(mockNurse.Object);
                    return;
            }

            createEmployeeCommand.Execute();

            mockMenuHandler.Verify(x => x.ShowMessage(It.Is<string>(x => x.Contains(UiMessages.CreateEmployeeMessages.OperationSuccessPrompt))), Times.Once());
            Assert.Contains(It.IsAny<IEmployee>(), employeesList);
        }
    }
}