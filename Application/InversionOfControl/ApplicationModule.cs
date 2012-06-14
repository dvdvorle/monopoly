// -----------------------------------------------------------------------
// <copyright file="ApplicationModule.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Restless.Monopoly.Application.InversionOfControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Ninject.Modules;
    using Restless.Monopoly.Application.Webservice;
    using Restless.Monopoly.Application.Webservice.Core;
    using Restless.Monopoly.Domain.Model.Players;
    using Restless.Monopoly.Infrastructure.Persistence;
    using Restless.Monopoly.Domain.Model.Games;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMonopoly>().To<MonopolyService>();

            BindRepositories();
        }

        private void BindRepositories()
        {
            Bind<IPlayerRepository>().To<NHPlayerRepository>();
            Bind<IGameRepository>().To<NHGameRepository>();
        }

        public object MonoPolyService { get; set; }
    }
}
