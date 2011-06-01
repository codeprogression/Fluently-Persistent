using FluentNHibernate.Automapping;

namespace CP.FluentlyPersistent.Web.Infrastructure.Persistence.Configuration
{
    public interface IAutoPersistenceModelConfiguration
    {
        AutoPersistenceModel GetModel();
    }
}