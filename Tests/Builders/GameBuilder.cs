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
        private List<Player> _players = new List<Player>();
        private string _name = "DefaultGame";

        public GameBuilder WithPlayers(List<Player> players)
        {
            _players = players;
            return this;
        }

        public GameBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        #region IBuilder<Game> Members

        public Game Build()
        {
            return new Game(_name, _players);
        }

        #endregion
    }
}
