using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace CP.FluentlyPersistent.Core.Persistence.Conventions
{
    public class ConstraintConvention: ICollectionConvention
    {
        public void Apply(ICollectionInstance instance)
        {
            var key = string.Format("FK_{0}_{1}", instance.Member.Name, instance.EntityType.Name);
            instance.Key.ForeignKey(key);
        }
    }
}