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
        public List<Employee> Employees { get; private set; }
        public List<Ward> Wards { get; private set; }
        public List<Patient> Patients { get; private set; }
        public List<User> Users { get; private set; }
        public HashSet<string> Pesels { get; private set; }
        public HashSet<string> Logins { get; private set; }
        public HashSet<string> WardsNames { get; private set; }

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

        private void PopulateLists()
        {
            using var session = _createSession.SessionFactory.OpenSession();

            Employees = _databaseOperations.GetAll<Employee>(session)
                .Where(employee => !employee.IsDeleted).ToList();
            Wards = _databaseOperations.GetAll<Ward>(session)
                .Where(ward => !ward.IsDeleted).ToList();
            foreach (var ward in Wards)
            {
                NHibernateUtil.Initialize(ward.AssignedPatients);
                NHibernateUtil.Initialize(ward.AssignedEmployees);
            }
            Patients = _databaseOperations.GetAll<Patient>(session)
                .Where(patient => !patient.IsDeleted).ToList();
            Users = _databaseOperations.GetAll<User>(session)
                .Where(user => !user.IsDeleted).ToList();
            Pesels = Patients.Select(patient => patient.Pesel).ToHashSet();
            Logins = Users.Select(user => user.Login).ToHashSet();
            WardsNames = Wards.Select(ward => ward.Name).ToHashSet();
        }
    }
}