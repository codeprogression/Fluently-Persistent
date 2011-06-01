using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace CP.FluentlyPersistent.Core.Persistence.Conventions
{
    public class CascadeOneToOne : IReferenceConvention
    {
        public bool Accept(IManyToOneInstance target)
        {
            return true;
        }


        public void Apply(IManyToOneInstance instance)
        {
            instance.Cascade.All();
        }
    }
}