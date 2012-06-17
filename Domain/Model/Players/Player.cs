// -----------------------------------------------------------------------
// <copyright file="Player.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Restless.Monopoly.Domain.Model.Players
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Games;

    /// <summary>
    /// </summary>
    public class Player
    {
        public virtual Guid Id { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual Stats Score { get; protected set; }
        public virtual IList<Card> Cards { get; protected set; }
        public virtual IList<House> BuyedHouses { get; protected set; }
        public virtual IList<Game> OwnedGames { get; protected set; }

        // For NH
        protected Player()
        {
        }

        public Player(string name)
        {
            Name = name;
            Score = new Stats();
            Cards = new List<Card>();
            BuyedHouses = new List<House>();
            OwnedGames = new List<Game>();
        }

        public virtual void addCard(Card card)
        {
            Cards.Add(card);
        }

        public virtual void addHouse(House house)
        {
            BuyedHouses.Add(house);
        }

        public virtual void Join(Game game)
        {
            game.AddPlayer(this);
        }

        public virtual void Start(Game game)
        {
            if (OwnedGames.Contains(game))
            {
                game.Start();
            }
        }

        public virtual Game CreateGame(string gameName)
        {
            var game = new Game(gameName, this);
            OwnedGames.Add(game);
            return game;
        }
    }
}
