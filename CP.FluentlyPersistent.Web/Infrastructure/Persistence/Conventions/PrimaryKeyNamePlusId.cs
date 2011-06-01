using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace CP.FluentlyPersistent.Core.Persistence.Conventions
{
    public class PrimaryKeyNamePlusId : IIdConvention 
    {
        public bool Accept(IIdentityInstance target)
        {
            return string.IsNullOrEmpty(target.Name);
        }

        public void Apply(IIdentityInstance instance)
        {
            instance.GeneratedBy.HiLo("1000");
            instance.Column(instance.EntityType.Name+"Id");
        }
    }
}