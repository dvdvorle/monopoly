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
        }

        public virtual void addCard(Card card)
        {
            Cards.Add(card);
        }

        public virtual void addHouse(House house)
        {
            BuyedHouses.Add(house);
        }
    }
}
