// -----------------------------------------------------------------------
// <copyright file="SetupHooks.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Restless.Monopoly.Tests.Specification.Steps.Hooks
{
    using System.Collections.Generic;
    using NHibernate;
    using Ninject;
    using Ninject.Modules;
    using Restless.Monopoly.Application.InversionOfControl;
    using Restless.Monopoly.Domain.Model.Players;
    using TechTalk.SpecFlow;
    using Util;
    using NHibernate.Tool.hbm2ddl;
    using FluentNHibernate.Cfg.Db;
    using FluentNHibernate.Cfg;
    using NHibernate.Cfg;
    using FluentNHibernate.Automapping;
    using Restless.Monopoly.Infrastructure.Persistence.Mapping;
    using System.Reflection;
    using FluentNHibernate.Conventions.Helpers;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [Binding]
    public sealed class SetupHooks
    {
        // ISessionFactory is expensive to create and it's threadsafe.
        // So we cache it here.
        private static ISessionFactory _sessionFactory;
        private static Configuration _configuration;

        static SetupHooks()
        {
            _configuration = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.InMemory())
                .Mappings(m => m.AutoMappings.Add(CreateAutoMappings()))
                .BuildConfiguration();

            _sessionFactory = _configuration.BuildSessionFactory();
        }

        private static AutoPersistenceModel CreateAutoMappings()
        {
            var model = AutoMap.AssemblyOf<Player>(new AutoMappingConfiguration());
            model.Conventions.Add(DefaultCascade.All());
            
            return model;
        }

        [BeforeScenario]
        private void RecreateDB()
        {
            // This is needed for the in-memory DB of SQLite. If the connection 
            // to the in-memory DB is closed, the DB would be gone entirely.
            // We can't use the SQLite connection pooling since that pool
            // has a chance to be cleared by the GC which makes our tests
            // randomly fail.
            ISession keepConnectionAlive = _sessionFactory.OpenSession();
            new SchemaExport(_configuration)
                .Execute(false, true, false, keepConnectionAlive.Connection, null);

            // Make sure the session stays open untill at least the end of this scenario.
            ScenarioContext.Current["keepConnectionAlive"] = keepConnectionAlive;
            ScenarioContext.Current["sessionFactory"] = _sessionFactory;
        }

        [BeforeScenario]
        private void InitIoC()
        {
            // FunctionalTestModule must be last, since it overrides earlier bindings we want mocked.
            var kernel = new StandardKernel(new ApplicationModule(),
                                            new FuncModule(),
                                            new FunctionalTestModule());

            ScenarioContext.Current["kernel"] = kernel;
        }
        
        [BeforeStep]
        public void OpenNewStepScopedSession()
        {
            var session = ScenarioContext.Current.OpenSession();
            session.BeginTransaction();
            ScenarioContext.Current["stepScopedSession"] = session;
        }
    
        private class FunctionalTestModule : NinjectModule
        {
            public override void Load()
            {
                Rebind<ISession>()
                    .ToMethod(context => (ISession)ScenarioContext.Current["stepScopedSession"]);
                Rebind<IPlayerContext>()
                    .To<MockPlayerContext>();
            }
        }
    }
}
