using FluentNHibernate.Mapping;

namespace Hospital.PeopleCategories.UserClass
{
    /// <summary>
    /// Provides the mapping configuration for the <see cref="User"/> class.
    /// </summary>
    internal class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Surname);
            Map(x => x.Gender);
            Map(x => x.Birthday);
            Map(x => x.Login);
            Map(x => x.Password);
            Map(x => x.IntroduceString);

            //References(x => x.AssignedWard);
        }
    }
}
