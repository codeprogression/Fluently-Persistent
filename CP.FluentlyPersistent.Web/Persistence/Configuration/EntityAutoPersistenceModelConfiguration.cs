using CP.FluentlyPersistent.Web.Models.Domain;
using FluentNHibernate.Automapping;

namespace CP.FluentlyPersistent.Web.Persistence.Configuration
{
    public class EntityAutoPersistenceModelConfiguration : IAutoPersistenceModelConfiguration
    {
        public AutoPersistenceModel GetModel()
        {
            return AutoMap
                .AssemblyOf<Entity>(new EntityAutoMappingConfiguration())
                .IgnoreBase<Entity>()
                .UseOverridesFromAssemblyOf<Entity>()
                .Conventions.AddFromAssemblyOf<Entity>()
                .OverrideAll(x=> x.IgnoreProperties(p => !p.CanWrite));
        }
    }
}