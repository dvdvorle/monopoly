// -----------------------------------------------------------------------
// <copyright file="Board.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Restless.Monopoly.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Game
    {
        public IEnumerable<Player> Players
        {
            get
            {
                return _players;
            }
        }

        private List<Player> _players;

        public Game(List<Player> players)
        {
            _players = players;
        }

        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }
    }
}
