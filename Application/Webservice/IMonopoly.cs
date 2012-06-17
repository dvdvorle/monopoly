// -----------------------------------------------------------------------
// <copyright file="IMonopoly.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Restless.Monopoly.Application.Webservice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ServiceModel;
    using Restless.Monopoly.Application.Model;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [ServiceContract]
    public interface IMonopoly
    {
        IEnumerable<GameDTO> GetGamesList();
        void CreateNewGame(string gameName);
        IEnumerable<PlayerDTO> GetPlayersIn(GameDTO game);
        void JoinGame(GameDTO game);
    }
}
