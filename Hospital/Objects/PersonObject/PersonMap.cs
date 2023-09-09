using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Hospital.Objects.PersonObject
{
    /// <summary>
    /// Provides the mapping configuration for the <see cref="Person"/> class.
    /// </summary>
    internal class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Surname).Not.Nullable();
            Map(x => x.Gender).CustomType<int>().Not.Nullable();
            Map(x => x.Birthday).Not.Nullable();
            Map(x => x.IntroduceString).Length(500).Nullable(); 
        }
    }
}