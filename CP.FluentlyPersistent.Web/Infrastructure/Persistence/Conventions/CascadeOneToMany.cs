using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace CP.FluentlyPersistent.Core.Persistence.Conventions
{
    public class CascadeOneToMany : IHasManyConvention
    {
        public bool Accept(IOneToManyCollectionInstance target)
        {
            return true;
        }

        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.Cascade.All();
        }
    }
}