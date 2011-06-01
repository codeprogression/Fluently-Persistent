using FluentNHibernate.Cfg;

namespace CP.FluentlyPersistent.Web.Infrastructure.Persistence.Configuration
{
    public interface IFluentMappingConfiguration
    {
        FluentMappingsContainer Configure(FluentMappingsContainer fluentMappings);
    }
}