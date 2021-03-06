﻿namespace PoliceUk.Tests.Unit.CustomAssertions.Equality
{
    using NUnit.Framework;

    public class GeopositionEqualityComparer : AbstractEqualityComparer<Geoposition>
    {
        public override bool AreEqual(Geoposition GeopositionOne, Geoposition GeopositionTwo)
        {
            Assert.AreEqual(GeopositionOne.Latitude, GeopositionTwo.Latitude);
            Assert.AreEqual(GeopositionOne.Longitude, GeopositionTwo.Longitude);            

            return true;
        }
    }
}
