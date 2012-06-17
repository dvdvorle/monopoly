// -----------------------------------------------------------------------
// <copyright file="GameExecution.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Restless.Monopoly.Tests.Specification.Steps.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TechTalk.SpecFlow;
    using Restless.Monopoly.Tests.Specification.Steps.Hooks;
    using Restless.Monopoly.Application.Webservice;
    using Restless.Monopoly.Application.Model;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [Binding]
    public class GameExecution : BaseSteps
    {
        [When(@"player '(.*)' joins '(.*)'")]
        public void WhenPlayerJoinsGame(string playerName, string gameName)
        {
            MockPlayerContext.CurrentPlayerName = playerName;

            var monopolyService = LocateService<IMonopoly>();
            IEnumerable<GameDTO> games = monopolyService.GetGamesList().ToList();
            
            SimulatePerCallSessionBehavior();
            
            monopolyService = LocateService<IMonopoly>();
            monopolyService.JoinGame(games.Single(g => g.Name == gameName));
        }

        [When(@"player '(.*)' creates the game '(.*)'")]
        public void WhenPlayerCreatesTheGame(string playerName, string gameName)
        {
            MockPlayerContext.CurrentPlayerName = playerName;

            var monopolyService = LocateService<IMonopoly>();
            monopolyService.CreateNewGame(gameName);
        }

    }
}
