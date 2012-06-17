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

        public Game(string name, Player owner)
        {
            _players = new List<Player>();
            _players.Add(owner);

            Owner = owner;
            Name = name;
            IsStarted = false;
        }

        public virtual Guid Id { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual Player Owner { get; protected set; }
        public virtual bool IsStarted { get; protected set; }

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

        public virtual void Start()
        {
            IsStarted = true;
        }
    }
}
