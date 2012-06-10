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
        public IEnumerable<Player> Players { get; private set; }

        public Game(List<Player> players)
        {
            Players = players;
        }
    }
}
