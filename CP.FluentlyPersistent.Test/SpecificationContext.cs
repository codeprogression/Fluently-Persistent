using CP.FluentlyPersistent.Web.Persistence.Configuration;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using Machine.Specifications;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace CP.FluentlyPersistent.Test
{
    public class SpecificationContext : NHibernateConfiguration, IAssemblyContext
    {
        public static ISession Session;

        public SpecificationContext() : base(new[] { new EntityAutoPersistenceModelConfiguration() }) { }

        public void OnAssemblyStart()
        {
            InitializeNHibernateProfiler();
            InitializeSession();
        }

        public void OnAssemblyComplete()
        {
            Session.Dispose();
        }


        void InitializeSession()
        {
            var sessionFactory = CreateSessionFactory(GetSqlConfiguration(), BuildSchema);
            Session = sessionFactory.OpenSession();
            Session.FlushMode = FlushMode.Auto;
        }

        static void InitializeNHibernateProfiler()
        {
            NHibernateProfiler.Initialize();
        }
        protected override void BuildSchema(NHibernate.Cfg.Configuration config)
        {
            config.SetProperty("generate-statistics", "true");
            new SchemaExport(config).Create(true, true);
        }
    }
}