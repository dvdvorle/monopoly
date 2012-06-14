// -----------------------------------------------------------------------
// <copyright file="GameSetup.cs" company="">
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
    public class GameSetup : BaseSteps
    {
        [Given(@"a game '(.*)'")]
        public void GivenAGame(string gameName)
        {
            var game = new GameBuilder()
                            .WithName(gameName)
                            .Build();

            SaveDomainObject(game);
        }

    }
}
