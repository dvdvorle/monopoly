// -----------------------------------------------------------------------
// <copyright file="Board.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Restless.Monopoly.Domain.Model.Games
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Players;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Game
    {
        private IList<Player> _players;

        // For NH
        protected Game()
        {
        }

        public Game(string name, IList<Player> players)
        {
            _players = players;
            Name = name;
        }

        public virtual Guid Id { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual IEnumerable<Player> Players
        {
            get
            {
                return _players;
            }
        }
              
        public virtual void AddPlayer(Player player)
        {
            _players.Add(player);
        }
    }
}
