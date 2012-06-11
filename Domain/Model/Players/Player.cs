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
        public virtual string Name { get; private set; }
        public virtual Stats Score { get; private set; }
        public virtual List<Card> Cards { get; private set; }
        public virtual List<House> BuyedHouses { get; private set; }

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
