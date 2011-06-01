using FluentNHibernate.Cfg;

namespace CP.FluentlyPersistent.Web.Infrastructure.Persistence.Configuration
{
    public interface IHbmMappingConfiguration
    {
        HbmMappingsContainer Configure(HbmMappingsContainer hbmMappings);
    }
}