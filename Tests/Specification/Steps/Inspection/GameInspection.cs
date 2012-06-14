// -----------------------------------------------------------------------
// <copyright file="GameInspection.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Restless.Monopoly.Tests.Specification.Steps.Inspection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TechTalk.SpecFlow;
    using Restless.Monopoly.Domain.Model.Games;
    using NHibernate.Linq;
    using NUnit.Framework;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [Binding]
    public class GameInspection : BaseSteps
    {
        [Then(@"player '(.*)' should be playing in '(.*)'")]
        public void ThenPlayerShouldBePlayingInGame(string playerName, string gameName)
        {
            var game = GetCurrentSession().Query<Game>().Single(g => g.Name == gameName);
            var playerNames = game.Players.Select(p => p.Name);

            Assert.That(playerNames, Contains.Item(playerName));
        }

    }
}
