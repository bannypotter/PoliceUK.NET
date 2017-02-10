using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoliceUk.Entities.StreetLevel
{
    public class StreetLevelOutcomeResults
    {
        /// <summary>
        /// The API has returned an Internal Error status code, which it
        /// does when more than 10,000 crimes are requested or an internal 
        /// error has actually occurred.
        /// </summary>
        public bool TooManyCrimesOrError { get; set; }

        public IEnumerable<Outcome> Outcomes { get; set; }
    }
}
