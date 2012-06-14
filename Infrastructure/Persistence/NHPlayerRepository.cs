// -----------------------------------------------------------------------
// <copyright file="NHPlayerRepository.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Restless.Monopoly.Infrastructure.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Restless.Monopoly.Domain.Model.Players;
    using NHibernate;
    using NHibernate.Linq;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class NHPlayerRepository : IPlayerRepository
    {
        private readonly ISession _session;

        public NHPlayerRepository(ISession session)
        {
            _session = session;
        }

        #region IPlayerRepository Members

        public Player GetByName(string playerName)
        {
            return (from player in _session.Query<Player>()
                    where player.Name == playerName
                    select player).Single();
        }

        #endregion
    }
}
