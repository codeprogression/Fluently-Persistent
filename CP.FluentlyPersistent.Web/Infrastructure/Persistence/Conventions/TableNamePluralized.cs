using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace CP.FluentlyPersistent.Core.Persistence.Conventions
{
    public class TableNamePluralized : IClassConvention
    {
        public bool Accept(IClassInstance classMap)
        {
            return true;
        }

        public void Apply(IClassInstance classMap)
        {
            classMap.Table(Inflector.Pluralize(classMap.EntityType.Name));
        }
    }
}