// -----------------------------------------------------------------------
// <copyright file="MockPlayerContext.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Restless.Monopoly.Tests.Specification.Steps.Hooks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;
    using Restless.Monopoly.Domain.Model.Players;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class MockPlayerContext : IPlayerContext
    {
        private readonly IPlayerRepository _playerRepository;

        public MockPlayerContext(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [ThreadStatic]
        private static string _currentPlayerName;
        public static string CurrentPlayerName
        {
            get
            {
                return _currentPlayerName;
            }
            set
            {
                _currentPlayerName = value;
            }
        }

        #region IPlayerContext Members

        public Player GetCurrentPlayer()
        {
            Assert.That(CurrentPlayerName, Is.Not.Null, "You forgot to set currentPlayerName on MockPlayerContext while the current player is relevant in this test.");
            return _playerRepository.GetByName(CurrentPlayerName);
        }

        #endregion
    }
}
