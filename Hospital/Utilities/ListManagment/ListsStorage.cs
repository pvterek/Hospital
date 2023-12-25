using Hospital.Database;
using Hospital.Database.Interfaces;
using Hospital.Entities.Employee;
using Hospital.PeopleCategories.PatientClass;
using Hospital.PeopleCategories.UserClass;
using Hospital.PeopleCategories.WardClass;
using NHibernate;

namespace Hospital.Utilities.ListManagment
{
    public class ListsStorage : IListsStorage
    {
        private readonly IDatabaseOperations _databaseOperations;
        private readonly CreateSession _createSession;

        public ListsStorage(
            IDatabaseOperations databaseOperations,
            CreateSession createSession)
        {
            _databaseOperations = databaseOperations;
            _createSession = createSession;

            PopulateLists();
        }

        public List<Employee> Employees { get; private set; }
        public List<Ward> Wards { get; private set; }
        public List<Patient> Patients { get; private set; }
        public List<User> Users { get; private set; }
        public HashSet<string> Pesels { get; private set; }
        public HashSet<string> Logins { get; private set; }
        public HashSet<string> WardsNames { get; private set; }

        private void PopulateLists()
        {
            using var session = _createSession.SessionFactory.OpenSession();

            PopulateEmployeesList(session);
            PopulateWardsList(session);
            PopulatePatientsList(session);
            PopulateUsersList(session);

            ExtractUniqueIdentifiers();
        }

        private void PopulateEmployeesList(ISession session)
        {
            Employees = _databaseOperations.GetAll<Employee>(session)
                                           .Where(employee => !employee.IsDeleted).ToList();
        }

        private void PopulateWardsList(ISession session)
        {
            Wards = _databaseOperations.GetAll<Ward>(session)
                                       .Where(ward => !ward.IsDeleted).ToList();

            foreach (var ward in Wards)
            {
                ward.AssignedPatients = session.Query<Patient>()
                                               .Where(patient => patient.AssignedWard == ward && !patient.IsDeleted)
                                               .ToList();

                ward.AssignedEmployees = session.Query<Employee>()
                                                .Where(employee => employee.AssignedWard == ward && !employee.IsDeleted)
                                                .ToList();
            }
        }

        private void PopulatePatientsList(ISession session)
        {
            Patients = _databaseOperations.GetAll<Patient>(session)
                                          .Where(patient => !patient.IsDeleted).ToList();
        }

        private void PopulateUsersList(ISession session)
        {
            Users = _databaseOperations.GetAll<User>(session)
                                       .Where(user => !user.IsDeleted).ToList();
        }

        private void ExtractUniqueIdentifiers()
        {
            Pesels = Patients.Select(patient => patient.Pesel).ToHashSet();
            Logins = Users.Select(user => user.Login).ToHashSet();
            WardsNames = Wards.Select(ward => ward.Name).ToHashSet();
        }
    }
}