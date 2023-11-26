using Autofac;
using Hospital.Commands.ManageEmployees;
using Hospital.Database.Interfaces;
using Hospital.Database;
using Hospital.Utilities;
using Hospital.Utilities.UserInterface;
using Hospital.PeopleCategories.Factory;
using Hospital.Commands.ManagePatients;
using Hospital.Commands.ManageWards;
using Hospital.Commands.LoginWindow;
using Hospital.Commands.Navigation;
using Hospital.Utilities.ListManagment;
using Hospital.PeopleCategories.Factory.Interfaces;
using Hospital.Utilities.ErrorLogger;
using Hospital.Utilities.UserInterface.Interfaces;
using Hospital.Commands.ManagePatients.ManagePatient;

namespace Hospital.Commands
{
    internal class AutofacConfig
    {
        public IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MenuHandler>().As<IMenuHandler>().SingleInstance();
            builder.RegisterType<DTOFactory>().As<IDTOFactory>().SingleInstance();
            builder.RegisterType<ObjectsFactory>().As<IObjectsFactory>().SingleInstance();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<InputHandler>().As<IInputHandler>().SingleInstance();
            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
            builder.RegisterType<ExitCommand>().AsSelf().SingleInstance();
            builder.RegisterType<BackCommand>().AsSelf().SingleInstance();
            builder.RegisterType<LogoutCommand>().AsSelf().SingleInstance();
            builder.RegisterType<DatabaseOperations>().As<IDatabaseOperations>().SingleInstance();
            builder.RegisterType<ListsStorage>().As<IListsStorage>().SingleInstance();
            builder.RegisterType<ListManage>().As<IListManage>().SingleInstance();
            builder.RegisterType<ManageCapacity>().As<IManageCapacity>().SingleInstance();
            builder.RegisterType<Validators>().As<IValidators>().SingleInstance();
            builder.RegisterType<EmployeeFactory>().As<IEmployeeFactory>().SingleInstance();
            builder.RegisterType<ValidateObjects>().As<IValidateObjects>().SingleInstance();
            builder.Register(c => new StreamWriter(Logger.filePath, true)).As<StreamWriter>().SingleInstance();


            //LoginWindowCommand
            builder.RegisterType<LoginCommand>().AsSelf().SingleInstance();
            builder.RegisterType<CreateAccountCommand>().AsSelf().SingleInstance();
            builder.RegisterType<LogoutCommand>().AsSelf().SingleInstance();
            builder.RegisterType<LoginWindowCommand>().AsSelf().SingleInstance();

            //ManageEmployeesCommand
            builder.RegisterType<FireEmployeeCommand>().AsSelf().SingleInstance();
            builder.RegisterType<DisplayEmployeesCommand>().AsSelf().SingleInstance();
            builder.RegisterType<HireEmployeeCommand>().AsSelf().SingleInstance();
            builder.RegisterType<ManageEmployeesCommand>().AsSelf().SingleInstance();

            //ManagePatientsCommand
            builder.RegisterType<AdmitPatientCommand>().AsSelf().SingleInstance();
            builder.RegisterType<DisplayPatientsCommand>().AsSelf().SingleInstance();
            builder.RegisterType<AssignToDoctorCommand>().AsSelf().SingleInstance();
            builder.RegisterType<ChangeHealthStatusCommand>().AsSelf().SingleInstance();
            builder.RegisterType<SignOutPatientCommand>().AsSelf().SingleInstance();
            builder.RegisterType<ManagePatientsCommand>().AsSelf().SingleInstance();

            //ManageWardsCommand
            builder.RegisterType<AddWardCommand>().AsSelf().SingleInstance();
            builder.RegisterType<DisplayWardCommand>().AsSelf().SingleInstance();
            builder.RegisterType<DeleteWardCommand>().AsSelf().SingleInstance();
            builder.RegisterType<ManageWardsCommand>().AsSelf().SingleInstance();

            //MainWindowCommand
            builder.RegisterType<MainWindowCommand>().AsSelf().SingleInstance();

            return builder.Build();
        }
    }
}