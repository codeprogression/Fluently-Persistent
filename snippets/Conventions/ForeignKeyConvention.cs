﻿using System;
using FluentNHibernate;

namespace CP.FluentlyPersistent.Web.Persistence.Conventions
{
    public class ForeignKeyConvention : FluentNHibernate.Conventions.ForeignKeyConvention
    {
        protected override string GetKeyName(Member property, Type type)
        {
            return property == null ? type.Name + "Id" : property.Name + "Id";
        }
    }
}