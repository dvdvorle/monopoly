// -----------------------------------------------------------------------
// <copyright file="Player.cs" company="">
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
    /// </summary>
    public class Player
    {
        public string Name { get; private set; }
        public Stats Score { get; private set; }
        public List<Card> Cards { get; private set; }
        public List<House> BuyedHouses { get; private set; }

        public Player(string name)
        {
            Name = name;
            Score = new Stats();
            Cards = new List<Card>();
            BuyedHouses = new List<House>();
        }

        public void addCard(Card card)
        {
            Cards.Add(card);
        }

        public void addHouse(House house)
        {
            BuyedHouses.Add(house);
        }
    }
}
