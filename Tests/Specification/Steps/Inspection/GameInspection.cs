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
    using Restless.Monopoly.Domain.Model.Players;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [Binding]
    public class GameInspection : BaseSteps
    {
        [Then(@"player '(.*)' should be playing in '(.*)'")]
        public void ThenPlayerShouldBePlayingInGame(string playerName, string gameName)
        {
            var game = SelectSingle<Game>(g => g.Name == gameName);
            var playerNames = game.Players.Select(p => p.Name);

            Assert.That(playerNames, Contains.Item(playerName));
        }

        [Then(@"a game '(.*)' should exist")]
        public void ThenAGameShouldExist(string gameName)
        {
            var game = this.SelectSingle<Game>(g => g.Name == gameName);
            Assert.That(game, Is.Not.Null);
        }

        [Then(@"player '(.*)' should be the owner of game '(.*)'")]
        public void ThenPlayereShouldBeTheOwnerOfGame(string playerName, string gameName)
        {
            var player = SelectSingle<Player>(p => p.Name == playerName);
            var game = this.SelectSingle<Game>(g => g.Name == gameName);

            Assert.That(game.Owner == player);
        }
    }
}
