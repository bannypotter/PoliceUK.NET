﻿namespace PoliceUK.Tests.Integrated
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PoliceUk;
    using PoliceUk.Entities;
    using PoliceUK.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class PoliceUkClientTests
    {
        [TestMethod]
        public void CrimeCategories_Call_Returns_Results()
        {
            PoliceUkClient policeApi = new PoliceUkClient();

            IEnumerable<Category> categories = policeApi.CrimeCategories(DateTime.Now);

            Assert.IsNotNull(categories);
            Assert.AreEqual(true, categories.Count() > 0);

            Category category = categories.First();
            Assert.IsNotNull(category.Url);
        }

        [TestMethod]
        public void StreetLevelCrimes_Call_Returns_Results()
        {
            PoliceUkClient policeApi = new PoliceUkClient();

            IEnumerable<Crime> crimes = policeApi.StreetLevelCrimes(new Geoposition(51.513016, -0.10231));

            Assert.IsNotNull(crimes);
            Assert.AreEqual(true, crimes.Count() > 0);

            Crime crime = crimes.First();
            Assert.IsNotNull(crime.Id);
        }

        [TestMethod]
        public void Forces_Call_Returns_Results()
        {
            PoliceUkClient policeApi = new PoliceUkClient();

            IEnumerable<ForceSummary> forces = policeApi.Forces();

            Assert.IsNotNull(forces);
            Assert.AreEqual(true, forces.Count() > 0);

            ForceSummary force = forces.First();
            Assert.IsNotNull(force.Id);
        }
    }
}
