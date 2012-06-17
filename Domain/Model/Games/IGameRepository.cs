// -----------------------------------------------------------------------
// <copyright file="IGameRepository.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Restless.Monopoly.Domain.Model.Games
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IGameRepository
    {
        void Add(Game game);
        Game GetById(Guid id);
        IEnumerable<Game> GetAll();
    }
}
