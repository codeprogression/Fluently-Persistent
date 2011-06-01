using System;
using System.Collections.Generic;
using System.Data;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace CP.FluentlyPersistent.Web.Infrastructure.Persistence.Configuration
{
    public class NHibernateConfiguration
    {

        #region 
        
        readonly IEnumerable<IAutoPersistenceModelConfiguration> _models;
        readonly IEnumerable<IFluentMappingConfiguration> _fluentMappings;
        readonly IEnumerable<IHbmMappingConfiguration> _hbmMappings;
        protected ISessionFactory SessionFactory;
        protected NHibernate.Cfg.Configuration SchemaConfig;

        public NHibernateConfiguration(IEnumerable<IAutoPersistenceModelConfiguration> models) : this(models,null,null) {}
        
        #endregion

        #region Constructor

        public NHibernateConfiguration(IEnumerable<IAutoPersistenceModelConfiguration> models, 
            IEnumerable<IFluentMappingConfiguration> fluentMappings, 
            IEnumerable<IHbmMappingConfiguration> hbmMappings)
        {
            _models = models??new List<IAutoPersistenceModelConfiguration>();
            _fluentMappings = fluentMappings ?? new List<IFluentMappingConfiguration>();
            _hbmMappings = hbmMappings ?? new List<IHbmMappingConfiguration>();
        }
        
        #endregion
        
        public ISessionFactory CreateSessionFactory()
        {
            SessionFactory = CreateSessionFactory(GetSqlConfiguration(), BuildSchema);
            return SessionFactory;
        }

        public virtual ISessionFactory CreateSessionFactory(Func<IPersistenceConfigurer> configuration, 
                                                            Action<NHibernate.Cfg.Configuration> schema)
        {
            try
            {
                return Fluently.Configure()
                    .Database(configuration)
                    .Mappings(CreateMappings())
                    .ExposeConfiguration(schema)
                    .BuildSessionFactory();
            }
            catch (Exception ex)
            {
//                Log.Fatal(this, "Failed to create session factory", ex);
                throw;
            }
        }

        protected virtual Func<IPersistenceConfigurer> GetSqlConfiguration()
        {
            var msSql2008 = MsSqlConfiguration.MsSql2008;

            Action<MsSqlConnectionStringBuilder> expression = c => c.FromConnectionStringWithKey("default");
            
            return () => msSql2008.ConnectionString(expression)
                            .UseReflectionOptimizer()
                            .IsolationLevel(IsolationLevel.ReadUncommitted)
                            .ShowSql();
        }

        protected virtual Action<MappingConfiguration> CreateMappings()
        {
            return m =>
                {
                    foreach (var model in _models)
                        m.AutoMappings.Add(model.GetModel());
                   
                    foreach (var mapping in _fluentMappings)
                        mapping.Configure(m.FluentMappings);
                    
                    foreach (var mapping in _hbmMappings)
                        mapping.Configure(m.HbmMappings);
                };
        }

        protected virtual void BuildSchema(NHibernate.Cfg.Configuration config)
        {
            new SchemaExport(config).Create(true, true);
        }
    }
}