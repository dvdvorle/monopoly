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
        private List<Player> _players;

        public Game(List<Player> players)
        {
            _players = players;
        }
        
        public virtual Guid Id { get; set; }

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
