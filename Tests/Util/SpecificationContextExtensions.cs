// -----------------------------------------------------------------------
// <copyright file="SpecificationContextExtensions.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Restless.Monopoly.Tests.Util
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NHibernate;
    using TechTalk.SpecFlow;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    static class ScenarioContextExtensions
    {
        public static ISession OpenSession(this ScenarioContext context)
        {
            ISessionFactory sessionFactory = (ISessionFactory)context["sessionFactory"];
            ISession keepConnectionAlive = (ISession)context["keepConnectionAlive"];
            return sessionFactory.OpenSession(keepConnectionAlive.Connection);
        }
    }
}
