using CP.FluentlyPersistent.Web.Persistence;
using CP.FluentlyPersistent.Web.Persistence.Configuration;
using NHibernate;

namespace CP.FluentlyPersistent.Web.Bootstrap
{
    public class NHibernateRegistration : StructureMap.Configuration.DSL.Registry
    {
        public NHibernateRegistration()
        {
            ForSingletonOf<ISessionFactory>().Use(
                x => x.GetInstance<NHibernateConfiguration>().CreateSessionFactory());

            For<IInterceptor>().Use<EmptyInterceptor>();
//            For<IInterceptor>().Use<DefaultInterceptor>();
            
            For<ITransactionBoundary>().HybridHttpOrThreadLocalScoped().Use<TransactionBoundary>();

            For<IStatelessSession>().Use(x => x.GetInstance<ISessionFactory>().OpenStatelessSession());
            
            For<ISession>().Use(x =>
                {
                    var instance = x.GetInstance<ITransactionBoundary>();
                    return instance.CurrentSession;
                });

//            For<IRepository>().Use<Repository>();

            Scan(s =>
                {
                    s.AssembliesFromApplicationBaseDirectory();
                    s.AddAllTypesOf<IHbmMappingConfiguration>();
                    s.AddAllTypesOf<IFluentMappingConfiguration>();
                    s.AddAllTypesOf<IAutoPersistenceModelConfiguration>();
                });

        }
    }
}