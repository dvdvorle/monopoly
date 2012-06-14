// -----------------------------------------------------------------------
// <copyright file="Players.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Restless.Monopoly.Tests.Specification.Steps.DataSetup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TechTalk.SpecFlow;
    using Restless.Monopoly.Tests.Builders;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [Binding]
    public class PlayerSetup : BaseSteps
    {
        [Given(@"a player '(.*)'")]
        public void GivenAPlayer(string playerName)
        {
            var player = new PlayerBuilder()
                                .WithName(playerName)
                                .Build();

            SaveDomainObject(player);
        }
    }
}
