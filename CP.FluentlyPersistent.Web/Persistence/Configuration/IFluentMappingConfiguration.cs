using FluentNHibernate.Cfg;

namespace CP.FluentlyPersistent.Web.Persistence.Configuration
{
    public interface IFluentMappingConfiguration
    {
        FluentMappingsContainer Configure(FluentMappingsContainer fluentMappings);
    }
}