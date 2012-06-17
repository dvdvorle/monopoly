// -----------------------------------------------------------------------
// <copyright file="GameBuilder.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Restless.Monopoly.Tests.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
using Restless.Monopoly.Domain.Model.Games;
using Restless.Monopoly.Domain.Model.Players;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class GameBuilder : IBuilder<Game>
    {
        private string _name = "DefaultGame";
        private Player _owner = new PlayerBuilder().Build();
        private IEnumerable<Player> _players = new List<Player>();
        
        public GameBuilder WithPlayers(IEnumerable<Player> players)
        {
            _players = players;
            return this;
        }

        public GameBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public GameBuilder WithOwner(Player owner)
        {
            _owner = owner;
            return this;
        }

        #region IBuilder<Game> Members

        public Game Build()
        {
            var game = new Game(_name, _owner);
            foreach (var player in _players)
            {
                game.AddPlayer(player);
            }

            return game;
        }

        #endregion
    }
}
