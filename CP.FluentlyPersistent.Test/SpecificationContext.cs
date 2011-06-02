using System;
using System.Collections.Generic;
using CP.FluentlyPersistent.Web.Bootstrap;
using CP.FluentlyPersistent.Web.Persistence.Configuration;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using Machine.Specifications;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using StructureMap;
using Container = CP.FluentlyPersistent.Web.Bootstrap.Container;

namespace CP.FluentlyPersistent.Test
{
    public class SpecificationContext : IAssemblyContext
    {
        public static ISession Session;

        public void OnAssemblyStart()
        {
            Container.Initialize(GetContainerConfiguration());
            NHibernateProfiler.Initialize();
            Session = Container.GetInstance<ISession>();
        }

        public void OnAssemblyComplete()
        {
        }


        static Action<ConfigurationExpression> GetContainerConfiguration()
        {
            Action<ConfigurationExpression> config = x =>
                {
                    x.Scan(s =>
                        {
                            s.LookForRegistries();
                            s.AssembliesFromApplicationBaseDirectory();
                            s.WithDefaultConventions();
                        });

                    //Making sure I add this instance before adding from NHibernateRegistration
                    x.ForSingletonOf<ISessionFactory>().Use(
                        c => c.GetInstance<NHibernateConfiguration>().CreateSessionFactory());

                    x.AddRegistry<NHibernateRegistration>();
                };
            return config;
        }
    }

    public class NHibernateConfiguration : Web.Persistence.Configuration.NHibernateConfiguration
    {
        public NHibernateConfiguration(IEnumerable<IAutoPersistenceModelConfiguration> models) : base(models)
        {
        }
        protected override void BuildSchema(NHibernate.Cfg.Configuration config)
        {
            config.SetProperty("generate-statistics", "true");
            new SchemaExport(config).Create(true, true);
        }
    }
}