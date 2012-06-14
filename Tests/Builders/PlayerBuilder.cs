// -----------------------------------------------------------------------
// <copyright file="PlayerBuilder.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Restless.Monopoly.Tests.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Restless.Monopoly.Domain.Model.Players;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class PlayerBuilder : IBuilder<Player>
    {
        private string _name = "DefaultPlayer";

        public PlayerBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
        #region IBuilder<Player> Members

        public Player Build()
        {
            return new Player(_name);
        }

        #endregion
    }
}
