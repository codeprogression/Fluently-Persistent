using System;
using FluentNHibernate;
using FluentNHibernate.Conventions;

namespace CP.FluentlyPersistent.Core.Persistence.Conventions
{
    public class ForeignKeyNamePlusId : ForeignKeyConvention
    {
        //protected override string GetKeyName(PropertyInfo property, Type type)
        //{
        //    // type.Name for many-to-many, one-to-many, join
        //    // property.Name for many-to-one
        //}

        protected override string GetKeyName(Member property, Type type)
        {
            return property == null ? type.Name + "Id" : property.Name + "Id";
        }
    }
}