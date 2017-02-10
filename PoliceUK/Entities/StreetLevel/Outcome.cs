using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PoliceUk.Entities.StreetLevel
{
    [DataContract]
    public class Outcome
    {
        /// <summary>
        /// Category of the outcome
        /// </summary>
        [DataMember(Name = "category")]
        public OutcomeCategory Category { get; set; }

        /// <summary>
        /// Date of the outcome
        /// </summary>
        [DataMember(Name = "date")]
        public string Date { get; set; }

        /// <summary>
        /// An identifier for the suspect/offender, where available.
        /// </summary>
        [DataMember(Name = "person_id")]
        public string PersonId { get; set; }

        /// <summary>
        /// Crime information
        /// </summary>
        [DataMember(Name = "crime")]
        public Crime Crime { get; set; }
    }
}
