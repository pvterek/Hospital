using Hospital.Commands.ManageWards;
using Hospital.Database.Interfaces;
using Hospital.PeopleCategories.Factory.Interfaces;
using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.ListManagment;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;
using Moq;
using NHibernate;

namespace Hospital.Test.ManageWardsTests
{
    public class CreateWardCommandTest
    {
        private Mock<IObjectsFactory> mockObjectsFactory;
        private Mock<IValidateObjects> mockValidateObjects;
        private Mock<IDTOFactory> mockDtoFactory;
        private Mock<IMenuHandler> mockMenuHandler;
        private Mock<IListManage> mockListManage;
        private Mock<IListsStorage> mockListsStorage;
        private Mock<IDatabaseOperations> mockDatabaseOperations;

        private CreateWardCommand createWardCommand;

        private void SetUpMocks()
        {
            mockObjectsFactory = new Mock<IObjectsFactory>();
            mockValidateObjects = new Mock<IValidateObjects>();
            mockDtoFactory = new Mock<IDTOFactory>();
            mockMenuHandler = new Mock<IMenuHandler>();
            mockListManage = new Mock<IListManage>();
            mockListsStorage = new Mock<IListsStorage>();
            mockDatabaseOperations = new Mock<IDatabaseOperations>();

            createWardCommand = new CreateWardCommand(
                mockObjectsFactory.Object,
                mockValidateObjects.Object,
                mockDtoFactory.Object,
                mockMenuHandler.Object,
                mockListManage.Object,
                mockListsStorage.Object);
        }

        [Fact]
        public void Execute_WhenWardDataNotPassValidation_ShouldReturnEarly()
        {
            SetUpMocks();

            mockValidateObjects.Setup(x => x.ValidateWardObject(It.IsAny<WardDTO>()))
                .Returns(false);

            createWardCommand.Execute();

            mockObjectsFactory.Verify(x => x.CreateWard(It.IsAny<WardDTO>()), Times.Never());
        }

        [Fact]
        public void Execute_WhenValidationPassed_ShouldCreateWard()
        {
            SetUpMocks();

            var wardsList = new List<Ward>();
            var mockWard = new Mock<Ward>();

            mockValidateObjects.Setup(x => x.ValidateWardObject(It.IsAny<WardDTO>()))
                .Returns(true);
            mockObjectsFactory.Setup(x => x.CreateWard(It.IsAny<WardDTO>()))
                .Returns(mockWard.Object);
            mockListsStorage.Setup(x => x.Wards)
                .Returns(wardsList);

            mockDatabaseOperations.Setup(x => x.Add(It.IsAny<Ward>(), It.IsAny<ISession>()))
                .Returns(true);
            mockListManage.Setup(x => x.Add(It.IsAny<Ward>(), wardsList))
                .Callback((Ward item, List<Ward> list) =>
                {
                    if (mockDatabaseOperations.Object.Add(item, new Mock<ISession>().Object))
                    {
                        list.Add(item);
                    }
                });

            createWardCommand.Execute();

            mockMenuHandler.Verify(x => x.ShowMessage(string.Format(UiMessages.CreateWardMessages.OperationSuccessPrompt, mockWard.Object.Name)), Times.Once());
            Assert.Contains(mockWard.Object, wardsList);
        }
    }
}