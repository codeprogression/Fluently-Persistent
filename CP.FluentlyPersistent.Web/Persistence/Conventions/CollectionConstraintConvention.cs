using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace CP.FluentlyPersistent.Web.Persistence.Conventions
{
    public class CollectionConstraintConvention : ICollectionConvention
    {
        public void Apply(ICollectionInstance instance)
        {
            instance.Key.ForeignKey(string.Format("FK_{0}{1}",instance.Member.Name,instance.EntityType.Name+"Id"));
        }
    }
}