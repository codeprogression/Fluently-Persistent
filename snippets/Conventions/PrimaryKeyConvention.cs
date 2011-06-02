using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace CP.FluentlyPersistent.Web.Persistence.Conventions
{
    public class PrimaryKeyConvention: IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.Column(instance.EntityType.Name + "Id");
        }
    }
}