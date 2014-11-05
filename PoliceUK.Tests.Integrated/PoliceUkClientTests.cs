﻿namespace PoliceUK.Tests.Integrated
{
    using Entities;
    using Entities.Force;
    using NUnit.Framework;
    using PoliceUk;
    using PoliceUk.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class PoliceUkClientTests
    {
        [Test]
        public void CrimeCategories_Call_Returns_Results()
        {
            var policeApi = new PoliceUkClient();

            IEnumerable<Category> categories = policeApi.CrimeCategories(DateTime.Now);

            Assert.IsNotNull(categories);
            Assert.AreEqual(true, categories.Any());

            Category category = categories.First();
            Assert.IsNotNull(category.Url);
        }

        [Test]
        public void StreetLevelCrimes_Point_Call_Returns_Results()
        {
            var policeApi = new PoliceUkClient();

            StreetLevelCrimeResults result = policeApi.StreetLevelCrimes(new Geoposition(51.513016, -0.10231));

            Assert.IsNotNull(result);
            Assert.IsFalse(result.TooManyCrimesOrError);

            Assert.IsNotNull(result.Crimes);
            Assert.AreEqual(true, result.Crimes.Any());

            Crime crime = result.Crimes.First();
            Assert.IsNotNull(crime.Id);
        }

        [Test]
        public void StreetLevelCrimes_Polygon_Call_Returns_Results()
        {
            var policeApi = new PoliceUkClient();

            var polygon = new[] {
                new Geoposition(50.181460, -5.419521),
                new Geoposition(50.193935,-5.394716),
                new Geoposition(50.196353,-5.402184),
                new Geoposition(50.184263,-5.424070)
            };

            StreetLevelCrimeResults result = policeApi.StreetLevelCrimes(polygon);

            Assert.IsNotNull(result);
            Assert.IsFalse(result.TooManyCrimesOrError);

            Assert.IsNotNull(result.Crimes);
            Assert.AreEqual(true, result.Crimes.Any());

            Crime crime = result.Crimes.First();
            Assert.IsNotNull(crime.Id);
        }

        [Test]
        public void Forces_Call_Returns_Results()
        {
            var policeApi = new PoliceUkClient();

            IEnumerable<ForceSummary> forces = policeApi.Forces();

            Assert.IsNotNull(forces);
            Assert.AreEqual(true, forces.Any());

            ForceSummary force = forces.First();
            Assert.IsNotNull(force.Id);
        }

        [Test]
        public void Force_Call_Returns_Result()
        {
            var policeApi = new PoliceUkClient();

            ForceDetails force = policeApi.Force("leicestershire");

            Assert.IsNotNull(force);
            Assert.IsNotNull(force.Id);
        }

        [Test]
        public void Force_Call_With_No_Result_Returns_Null()
        {
            var policeApi = new PoliceUkClient();

            ForceDetails force = policeApi.Force("");

            Assert.IsNull(force);
        }
    }
}
