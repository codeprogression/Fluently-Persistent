using FluentNHibernate.Automapping;

namespace CP.FluentlyPersistent.Web.Persistence.Configuration
{
    public interface IAutoPersistenceModelConfiguration
    {
        AutoPersistenceModel GetModel();
    }
}