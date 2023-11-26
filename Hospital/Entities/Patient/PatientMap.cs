using FluentNHibernate.Mapping;
using Hospital.PeopleCategories.PersonClass;

namespace Hospital.PeopleCategories.PatientClass
{
    internal class PatientMap : ClassMap<Patient>
    {
        public PatientMap()
        {
            Id(x => x.Id).Not.Nullable();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Surname).Not.Nullable();
            Map(x => x.Gender).CustomType<Gender>().Not.Nullable();
            Map(x => x.Birthday).CustomType<DateTime>().Not.Nullable();
            Map(x => x.Pesel).Not.Nullable();
            Map(x => x.IntroduceString).Not.Nullable();
            Map(x => x.HealthStatus).CustomType<Health>();

            References(x => x.AssignedWard);

            References(x => x.AssignedDoctor);
        }
    }
}