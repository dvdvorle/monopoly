// -----------------------------------------------------------------------
// <copyright file="AutoMappingConfiguration.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Restless.Monopoly.Infrastructure.Persistence.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FluentNHibernate.Automapping;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class AutoMappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.Namespace.StartsWith("Restless.Monopoly.Domain.Model")
                && type.IsClass;
        }
    }
}
