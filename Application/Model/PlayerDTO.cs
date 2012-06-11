// -----------------------------------------------------------------------
// <copyright file="PlayerDOT.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Restless.Monopoly.Application.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.Serialization;
    
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [DataContract]
    public class PlayerDTO
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
