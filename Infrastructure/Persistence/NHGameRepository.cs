// -----------------------------------------------------------------------
// <copyright file="NHGameRepository.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Restless.Monopoly.Infrastructure.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NHibernate;
    using NHibernate.Linq;
    using Restless.Monopoly.Domain.Model.Games;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class NHGameRepository : IGameRepository
    {
        private readonly ISession _session;

        public NHGameRepository(ISession session)
        {
            _session = session;
        }

        #region IGameRepository Members

        public Game GetById(Guid id)
        {
            return _session.Get<Game>(id);
        }

        public IEnumerable<Game> GetAll()
        {
            return _session.Query<Game>().AsEnumerable();
        }

        #endregion
    }
}
