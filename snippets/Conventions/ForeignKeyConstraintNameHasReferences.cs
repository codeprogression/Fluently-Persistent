using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace CP.FluentlyPersistent.Core.Persistence.Conventions
{
    public class ForeignKeyConstraintNameHasReferences : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            instance.ForeignKey(string.Format("FK_{0}_{1}",
                                              instance.EntityType == null ? instance.Class.Name : instance.EntityType.Name,
                                              instance.Name));
        }
    }
}