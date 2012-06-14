// -----------------------------------------------------------------------
// <copyright file="CleanupHooks.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Restless.Monopoly.Tests.Specification.Steps.Hooks
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
    [Binding]
    public sealed class CleanupHooks
    {
        [AfterStep]
        public void CloseStepScopedSession()
        {
            ISession session = (ISession)ScenarioContext.Current["stepScopedSession"];
            if (session.IsOpen)
            {
                if (session.Transaction.IsActive)
                {
                    session.Transaction.Commit();
                }

                session.Close();
            }
        }
    }
}
