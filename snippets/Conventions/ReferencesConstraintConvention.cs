using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace CP.FluentlyPersistent.Web.Persistence.Conventions
{
    public class ReferencesConstraintConvention : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            instance.ForeignKey(string.Format("FK_{0}{1}", instance.EntityType.Name, instance.Name));
        }
    }
}