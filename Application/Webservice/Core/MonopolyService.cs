// -----------------------------------------------------------------------
// <copyright file="MonopolyService.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Restless.Monopoly.Application.Webservice.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NHibernate;
    using NHibernate.Linq;
using Restless.Monopoly.Domain.Model.Players;
    using Restless.Monopoly.Domain.Model.Games;
    using Restless.Monopoly.Application.Model;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class MonopolyService : IMonopoly
    {
        private readonly IGameRepository _gameRepository;
        private readonly IPlayerContext _playerContext;

        public MonopolyService(IPlayerContext playerContext, IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
            _playerContext = playerContext;
        }

        #region IMonopoly Members

        public IEnumerable<GameDTO> GetGamesList()
        {
            return from game in _gameRepository.GetAll()
                   select new GameDTO() { Id = game.Id, Name = game.Name };
        }

        public void CreateNewGame(string gameName)
        {
            Game game = CurrentPlayer.CreateGame(gameName);
            _gameRepository.Add(game);
        }

        public IEnumerable<PlayerDTO> GetPlayersIn(GameDTO game)
        {
            throw new NotImplementedException();
        }

        public void JoinGame(GameDTO gameDTO)
        {
            var game = _gameRepository.GetById(gameDTO.Id);
            CurrentPlayer.Join(game);
        }

        public void StartGame(GameDTO gameDTO)
        {
            var game = _gameRepository.GetById(gameDTO.Id);
            CurrentPlayer.Start(game);
        }

        #endregion

        #region Helpers

        private Player CurrentPlayer
        {
            get
            {
                return _playerContext.GetCurrentPlayer();
            }
        }
        #endregion 
    }
}
