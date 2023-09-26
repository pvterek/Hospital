﻿using FluentNHibernate.Mapping;

namespace Hospital.PeopleCategories.WardClass
{
    /// <summary>
    /// Provides the mapping configuration for the <see cref="Ward"/> class.
    /// </summary>
    internal class WardMap : ClassMap<Ward>
    {
        public WardMap() 
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Unique().Not.Nullable();
            Map(x => x.Capacity).Not.Nullable();
            Map(x => x.IntroduceString);

            HasMany(x => x.AssignedPatients)
                .Inverse()
                .Cascade.All();

            //HasMany(x => x.AssignedUsers)
            //    .Inverse();

            HasMany(x => x.AssignedEmployees)
                .Inverse()
                .KeyColumn("WardId");
        }
    }
}