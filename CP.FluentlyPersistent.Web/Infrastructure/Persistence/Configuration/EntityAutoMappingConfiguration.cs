using System;
using System.Linq;
using CP.FluentlyPersistent.Web.Models.Domain;
using FluentNHibernate.Automapping;

namespace CP.FluentlyPersistent.Web.Infrastructure.Persistence.Configuration
{
    public class EntityAutoMappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.GetInterfaces().Contains(typeof (IPersistable));
        }

        public override bool IsComponent(Type type)
        {
            return type.GetInterfaces().Contains(typeof (IComponent));
        }

        public override string GetComponentColumnPrefix(FluentNHibernate.Member member)
        {
            return member.PropertyType.Name + "_";
        }
    }
}