namespace PoliceUk.Tests.Unit.CustomAssertions.Equality
{
    using Entities.Location;
    using Entities.StreetLevel;
    using Location;
    using NUnit.Framework;
    using System.Collections.Generic;

    public class OutcomeEqualityComparer : AbstractEqualityComparer<Outcome>
    {
        private readonly IEqualityComparer<Crime> crimeComparer
            = new CrimeEqualityComparer();

        public override bool AreEqual(Outcome outcomeOne, Outcome outcomeTwo)
        {
            Assert.AreEqual(outcomeOne.Category.Code, outcomeTwo.Category.Code);
            Assert.AreEqual(outcomeOne.Category.Name, outcomeTwo.Category.Name);

            Assert.AreEqual(outcomeOne.Date, outcomeTwo.Date);
            Assert.AreEqual(outcomeOne.PersonId, outcomeOne.PersonId);

            return crimeComparer.Equals(outcomeOne.Crime, outcomeTwo.Crime);
        }
    }
}
