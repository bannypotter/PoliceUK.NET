namespace PoliceUK.Tests.Unit.TestDataFactories
{

    using PoliceUk.Entities;
    using PoliceUk.Entities.Location;
    using PoliceUk.Entities.StreetLevel;
    using PoliceUk.Tests.Unit.TestDataFactories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class StreetLevelOutcomeDataFactory
    {
        protected static readonly Outcome DummyOutcomeOne = new Outcome
        {
            Category = new OutcomeCategory {  Code = "imprisoned", Name = "Offender sent to prison" },
            Date = "2013-01",
            PersonId = "7508313", // issue in json needs to be bigint
            Crime = new Crime
            {
                Category = "violent-crime",
                PersistentId = "5ae43b96a401aea27b4a82898652f6fd88354115d20fdb8bbfaf5b16da2ff9f8",
                LocationType = "Force",
                LocationSubtype = "",
                Id = "9723278",
                Location = new CrimeLocation
                {
                    Latitude = 52.63447444219649,
                    Longitude = -1.1491966631305148,
                    Street = new Street
                    {
                        Id = 883498,
                        Name = "On or near Kate Street"
                    }
                },
                Context = "",
                Month = "2012-01"
            }
        };

        protected static readonly Outcome DummyOutcomeTwo = new Outcome
        {
            Category = new OutcomeCategory { Code = "no-further-action", Name = "Investigation complete; no suspect identified" },
            PersonId = null,
            Date = "2013-01",
            Crime = new Crime
            {
                Category = "criminal-damage-arson",
                PersistentId = "96716a931aa965894af2456ad8ae2216af0c270294f6ae67758e579eb2c48e82",
                LocationType = "Force",
                LocationSubtype = "",
                Id = "10464498",
                Location = new CrimeLocation
                {
                    Latitude = 52.63447444219649,
                    Longitude = -1.1491966631305148,
                    Street = new Street
                    {
                        Id = 883498,
                        Name = "On or near Kate Street"
                    }
                },
                Context = "",
                Month = "2012-02",
            }
        };

        protected static readonly object[] NoOutcome =
        {
             new object[]
            {
                "PoliceUK.Tests.Unit.TestData.EmptyArray.json",
                new Outcome[]{}
            }
        };

        protected static readonly object[] DummyOutcome =
        {
            new object[]
            {
                "PoliceUK.Tests.Unit.TestData.StreetLevelOutcome.Single.json",
                new Outcome[]
                {
                    DummyOutcomeOne
                }
            }
        };

        public static readonly object[] DummyOutcomes =
        {
            new object[]
            {
                "PoliceUK.Tests.Unit.TestData.StreetLevelOutcome.Multiple.json",
                new Outcome[]
                {
                    DummyOutcomeOne,
                    DummyOutcomeTwo
                }
            }
        };
    }
}