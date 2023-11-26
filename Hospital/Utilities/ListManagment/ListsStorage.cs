using Hospital.Database.Interfaces;
using Hospital.PeopleCategories.WardClass;
using Hospital.PeopleCategories.PatientClass;
using Hospital.PeopleCategories.UserClass;
using Hospital.Database;
using NHibernate;
using Hospital.Entities.Interfaces;

namespace Hospital.Utilities.ListManagment
{
    internal class ListsStorage : IListsStorage
    {
        public List<IEmployee> Employees { get; private set; }
        public List<Ward> Wards { get; private set; }
        public List<Patient> Patients { get; private set; }
        public List<User> Users { get; private set; }
        public HashSet<string> Pesels { get; private set; }
        public HashSet<string> Logins { get; private set; }
        public HashSet<string> WardsNames { get; private set; }

        public ListsStorage(IDatabaseOperations databaseOperations)
        {
            using var session = CreateSession.SessionFactory.OpenSession();

            Employees = databaseOperations.GetAll<IEmployee>(session);
            Wards = databaseOperations.GetAll<Ward>(session);
            foreach (var ward in Wards)
            {
                NHibernateUtil.Initialize(ward.AssignedPatients);
                NHibernateUtil.Initialize(ward.AssignedEmployees);
            }
            Patients = databaseOperations.GetAll<Patient>(session);
            Users = databaseOperations.GetAll<User>(session);
            Pesels = Patients.Select(patient => patient.Pesel).ToHashSet();
            Logins = Users.Select(user => user.Login).ToHashSet();
            WardsNames = Wards.Select(ward => ward.Name).ToHashSet();
        }
    }
}