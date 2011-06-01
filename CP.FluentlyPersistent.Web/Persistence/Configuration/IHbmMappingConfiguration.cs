using FluentNHibernate.Cfg;

namespace CP.FluentlyPersistent.Web.Persistence.Configuration
{
    public interface IHbmMappingConfiguration
    {
        HbmMappingsContainer Configure(HbmMappingsContainer hbmMappings);
    }
}