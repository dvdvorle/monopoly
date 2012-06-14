// -----------------------------------------------------------------------
// <copyright file="BaseSteps.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Restless.Monopoly.Tests.Specification.Steps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NHibernate;
    using NHibernate.Linq;
    using Ninject;
    using TechTalk.SpecFlow;
    using System.Linq.Expressions;
    using Util;
    using Restless.Monopoly.Tests.Specification.Steps.Hooks;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class BaseSteps : TechTalk.SpecFlow.Steps
    {
        /// <summary>
        /// This helper method will persist the Domain objects to the database in
        /// a new session. Each object is saved within the same session.
        /// </summary>
        /// <param name="domainObjs">The Domain objects to persist.</param>
        protected void SaveDomainObjectInIsolatedTransaction(params object[] domainObjs)
        {
            using (ISession session = OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    foreach (object domainObj in domainObjs)
                    {
                        session.Save(domainObj);
                    }

                    tx.Commit();
                }
            }
        }

        protected void SaveDomainObject(params object[] domainObjs)
        {
            ISession session = GetCurrentSession();

            foreach (object domainObj in domainObjs)
            {
                session.Save(domainObj);
            }
        }

        protected T LocateService<T>()
        {
            return ((IKernel)ScenarioContext.Current["kernel"]).Get<T>();
        }

        protected ISession OpenSession()
        {
            return ScenarioContext.Current.OpenSession();
        }

        protected ISession GetCurrentSession()
        {
            return (ISession)ScenarioContext.Current["stepScopedSession"];
        }

        protected ITransaction BeginTransactionForCurrentSession()
        {
            return GetCurrentSession().BeginTransaction();
        }

        /// <summary>
        /// In a percall webservice situation, for each webservice method call
        /// a new ISession would be opened. To simulate this in an execution step,
        /// call this method in between method calls, and then retrieve a new instance
        /// of the webservice implementation using LocateService()
        /// </summary>
        protected void SimulatePerCallSessionBehavior()
        {
            new CleanupHooks().CloseStepScopedSession();
            new SetupHooks().OpenNewStepScopedSession();
        }

        protected void AndFormat(string format, params object[] args)
        {
            And(String.Format(format, args));
        }

        protected void AndFormat(string format, Table table, params object[] args)
        {
            And(String.Format(format, args), table);
        }

        protected T SelectSingle<T>(Expression<Func<T, bool>> predicate)
        {
            ISession session = GetCurrentSession();

            return session.Query<T>().SingleOrDefault(predicate);
        }
    }
}
