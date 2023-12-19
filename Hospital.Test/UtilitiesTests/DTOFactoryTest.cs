using Hospital.PeopleCategories.PersonClass;
using Hospital.PeopleCategories.WardClass;
using Hospital.Utilities.UserInterface;
using Hospital.Utilities.UserInterface.Interfaces;
using Moq;

namespace Hospital.Test.UtilitiesTests
{
    public class DTOFactoryTest
    {
        private Mock<IInputHandler> mockInputHandler;
        private Mock<IMenuHandler> mockMenuHandler;

        private DTOFactory dtoFactory;

        private void SetUpMocks()
        {
            mockInputHandler = new Mock<IInputHandler>();
            mockMenuHandler = new Mock<IMenuHandler>();

            dtoFactory = new DTOFactory(
                mockMenuHandler.Object,
                mockInputHandler.Object);
        }

        [Fact]
        public void GatherPersonData_WhenCorrectData_ShouldReturnPersonDTO()
        {
            SetUpMocks();

            var expectedName = "John";
            var expectedSurname = "Doe";
            var expectedGender = Gender.Male;
            var expectedBirthday = new DateTime(1990, 1, 1);

            mockInputHandler.Setup(x => x.GetInput(UiMessages.FactoryMessages.ProvideNamePrompt))
                .Returns(expectedName);
            mockInputHandler.Setup(x => x.GetInput(UiMessages.FactoryMessages.ProvideSurnamePrompt))
                .Returns(expectedSurname);
            mockMenuHandler.Setup(x => x.ShowInteractiveMenu<Gender>())
                .Returns(expectedGender);
            mockInputHandler.Setup(x => x.GetDateTimeInput(It.IsAny<string>()))
                .Returns(expectedBirthday);

            var result = dtoFactory.GatherPersonData();

            Assert.Equal(expectedName, result.Name);
            Assert.Equal(expectedSurname, result.Surname);
            Assert.Equal(expectedGender, result.Gender);
            Assert.Equal(expectedBirthday, result.Birthday);
        }

        [Fact]
        public void GatherDoctorData_WhenCorrectData_ShouldReturnDoctorDTO()
        {
            SetUpMocks();

            var mockWard = new Mock<Ward>();
            var wardsList = new List<Ward>() { mockWard.Object };

            mockMenuHandler.Setup(x => x.ShowInteractiveMenu(wardsList))
                .Returns(mockWard.Object);

            var doctorDTO = dtoFactory.GatherDoctorData(wardsList);

            Assert.Equal(mockWard.Object, doctorDTO.AssignedWard);
            Assert.NotNull(doctorDTO.AssignedPatients);
        }

        [Fact]
        public void GatherPatientData_WhenCorrectData_ShouldReturnPatientDTO()
        {
            SetUpMocks();

            var expectedPesel = "12345678901";
            var mockWard = new Mock<Ward>();
            var wardsList = new List<Ward>() { mockWard.Object };

            mockInputHandler.Setup(x => x.GetInput(It.IsAny<string>()))
                .Returns(expectedPesel);
            mockMenuHandler.Setup(x => x.ShowInteractiveMenu(wardsList))
                .Returns(mockWard.Object);

            var patientDTO = dtoFactory.GatherPatientData(wardsList);

            Assert.Equal(expectedPesel, patientDTO.Pesel);
            Assert.Equal(mockWard.Object, patientDTO.AssignedWard);
        }

        [Fact]
        public void GatherNurseData_WhenCorrectData_ShouldReturnNurseDTO()
        {
            SetUpMocks();

            var mockWard = new Mock<Ward>();
            var wardsList = new List<Ward>() { mockWard.Object };

            mockMenuHandler.Setup(x => x.ShowInteractiveMenu(wardsList))
                .Returns(mockWard.Object);

            var nurseDTO = dtoFactory.GatherNurseData(wardsList);

            Assert.Equal(mockWard.Object, nurseDTO.AssignedWard);
        }

        [Fact]
        public void GatherUserData_WhenCorrectData_ShouldReturnUserDTO()
        {
            SetUpMocks();

            var expectedLogin = "login";
            var expectedPassword = "passwordpassword";

            mockInputHandler.Setup(x => x.GetInput(UiMessages.FactoryMessages.ProvideLoginPrompt))
                .Returns(expectedLogin);
            mockInputHandler.Setup(x => x.GetInput(UiMessages.FactoryMessages.ProvidePasswordPrompt))
                .Returns(expectedPassword);

            var userDTO = dtoFactory.GatherUserData();

            Assert.Equal(expectedLogin, userDTO.Login);
            Assert.Equal(expectedPassword, userDTO.Password);
        }

        [Fact]
        public void GatherWardData_WhenCorrectData_ShouldReturnWardDTO()
        {
            SetUpMocks();

            var excpectedName = "testward";
            var excpectedCapacity = 10;

            mockInputHandler.Setup(x => x.GetInput(UiMessages.FactoryMessages.ProvideNamePrompt))
                .Returns(excpectedName);
            mockInputHandler.Setup(x => x.GetIntInput(UiMessages.FactoryMessages.ProvideCapacityPrompt))
                .Returns(excpectedCapacity);

            var wardDTO = dtoFactory.GatherWardData();

            Assert.Equal(excpectedName, wardDTO.Name);
            Assert.Equal(excpectedCapacity, wardDTO.Capacity);
            Assert.NotNull(wardDTO.AssignedPatients);
            Assert.NotNull(wardDTO.AssignedEmployees);
        }
    }
}