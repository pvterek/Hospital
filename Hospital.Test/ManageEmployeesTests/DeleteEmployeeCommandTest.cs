using Hospital.Commands.ManageEmployees;
using Hospital.Database.Interfaces;
using Hospital.Entities.Interfaces;
using Hospital.PeopleCategories.DoctorClass;
using Hospital.Utilities.ListManagment;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;
using Moq;
using NHibernate;

namespace Hospital.Test.ManageEmployeesTests
{
    public class DeleteEmployeeCommandTest
    {
        private Mock<IMenuHandler> mockMenuHandler;
        private Mock<IListManage> mockListManage;
        private Mock<IListsStorage> mockListsStorage;
        private Mock<IDatabaseOperations> mockDatabaseOperations;

        private DeleteEmployeeCommand deleteEmployeeCommand;

        private void SetUpMocks()
        {
            mockMenuHandler = new Mock<IMenuHandler>();
            mockListManage = new Mock<IListManage>();
            mockListsStorage = new Mock<IListsStorage>();
            mockDatabaseOperations = new Mock<IDatabaseOperations>();

            deleteEmployeeCommand = new DeleteEmployeeCommand(
                mockMenuHandler.Object,
                mockListManage.Object,
                mockListsStorage.Object);
        }

        [Fact]
        public void Execute_WhenNoEmployee_ShouldReturnEarly()
        {
            SetUpMocks();

            mockListsStorage.Setup(x => x.Employees)
                .Returns([]);

            deleteEmployeeCommand.Execute();

            mockMenuHandler.Verify(x => x.ShowMessage(UiMessages.DeleteEmployeeMessages.NoEmployeesPrompt), Times.Once());
            mockMenuHandler.Verify(x => x.ShowMessage(UiMessages.DeleteEmployeeMessages.SelectPrompt), Times.Never());
        }

        [Fact]
        public void Execute_WhenIsEmployee_ShouldFireEmployee()
        {
            SetUpMocks();

            var mockDoctor = new Mock<Doctor>();
            var employees = new List<IEmployee> { mockDoctor.Object };

            mockListsStorage.Setup(x => x.Employees)
                .Returns(employees);
            mockMenuHandler.Setup(x => x.ShowInteractiveMenu(mockListsStorage.Object.Employees))
                .Returns(mockDoctor.Object);

            mockDatabaseOperations.Setup(x => x.Delete(It.IsAny<IEmployee>(), It.IsAny<ISession>()))
                .Returns(true);
            mockListManage.Setup(x => x.Remove(It.IsAny<IEmployee>(), It.IsAny<List<IEmployee>>()))
                .Callback((IEmployee item, List<IEmployee> list) =>
                {
                    if (mockDatabaseOperations.Object.Delete(item, new Mock<ISession>().Object))
                    {
                        list.Remove(item);
                    }
                });

            deleteEmployeeCommand.Execute();

            mockMenuHandler.Verify(x => x.ShowMessage(UiMessages.DeleteEmployeeMessages.NoEmployeesPrompt), Times.Never());
            mockMenuHandler.Verify(x => x.ShowMessage(string.Format(UiMessages.DeleteEmployeeMessages.OperationSuccessPrompt, mockDoctor.Object.Name, mockDoctor.Object.Surname)), Times.Once());
            Assert.DoesNotContain(mockDoctor.Object, employees);
        }
    }
}