namespace PoliceUk.Tests.Unit
{
    using CustomAssertions;
    using CustomAssertions.Equality;
    using FakeItEasy;
    using NUnit.Framework;
    using PoliceUk;
    using Request;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using InvalidDataException = Exceptions.InvalidDataException;
    using Entities.StreetLevel;
    using TestDataFactories;
    using PoliceUK.Tests.Unit.TestDataFactories;

    public class StreetLevelOutcomesTests : BaseMethodTests
    {
        [TestFixture]
        public class LatLngOverride
        {
            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void Call_With_Null_Position_Throws_ArgumentNullException()
            {
                (new PoliceUkClient()).StreetLevelOutcomes((IGeoposition)null);
            }

            [Test]
            [ExpectedException(typeof(InvalidDataException))]
            public void Call_With_Malformed_Response_Throwns_InvalidDataException()
            {
                using (Stream stream = GetTestDataFromResource(MalformedTestDataResource))
                {
                    var policeApi = new PoliceUkClient
                    {
                        RequestFactory = CreateRequestFactory(stream)
                    };

                    policeApi.StreetLevelOutcomes(A.Fake<IGeoposition>(), DateTime.Now);
                }
            }

            [Test]
            public void Call_Contains_Date_In_Request()
            {
                using (Stream stream = GetTestDataFromResource(EmptyArrayTestDataResource))
                {
                    var policeApi = new PoliceUkClient
                    {
                        RequestFactory = CreateRequestFactory(stream)
                    };

                    DateTime nowDateTime = DateTime.Now;
                    string formattedDateTime = nowDateTime.ToString("yyyy'-'MM");

                    policeApi.StreetLevelOutcomes(A.Fake<IGeoposition>(), nowDateTime);

                    // Assert
                    IHttpWebRequestFactory factory = policeApi.RequestFactory;
                    A.CallTo(() => factory.Create(A<string>.That.Contains(formattedDateTime))).MustHaveHappened();
                }
            }

            [Test]
            public void Call_Contains_LatLng_In_Request()
            {
                using (Stream stream = GetTestDataFromResource(EmptyArrayTestDataResource))
                {
                    var policeApi = new PoliceUkClient
                    {
                        RequestFactory = CreateRequestFactory(stream)
                    };

                    var geoPosition = new Geoposition(123, 456);

                    policeApi.StreetLevelOutcomes(geoPosition);

                    // Assert
                    string latitude = geoPosition.Latitude.ToString();
                    string longitude = geoPosition.Longitude.ToString();

                    IHttpWebRequestFactory factory = policeApi.RequestFactory;
                    A.CallTo(() => factory.Create(A<string>.That.Contains(latitude))).MustHaveHappened();
                    A.CallTo(() => factory.Create(A<string>.That.Contains(longitude))).MustHaveHappened();
                }
            }

            [Test, TestCaseSource(typeof(StreetLevelOutcomeDataFactory), "NoOutcome"),
                   TestCaseSource(typeof(StreetLevelOutcomeDataFactory), "DummyOutcome"),
                   TestCaseSource(typeof(StreetLevelOutcomeDataFactory), "DummyOutcomes")]
            public void Call_Parses_Elements_From_Json_Repsonse(string jsonResourceName, Outcome[] expectedOutcomes)
            {
                using (Stream stream = GetTestDataFromResource(jsonResourceName))
                {
                    IPoliceUkClient policeApi = new PoliceUkClient
                    {
                        RequestFactory = CreateRequestFactory(stream)
                    };

                    StreetLevelOutcomeResults result = policeApi.StreetLevelOutcomes(A.Fake<IGeoposition>());

                    // Assert
                    Assert.IsNotNull(result);
                    Assert.That(result.Outcomes, Is.Not.Null.And.Length.EqualTo(expectedOutcomes.Length));

                    int total = result.Outcomes.Count();
                    for (int i = 0; i < total; i++)
                    {
                        Outcome expected = expectedOutcomes[i];
                        Outcome actual = result.Outcomes.ElementAtOrDefault(i);

                        CustomAssert.AreEqual(expected, actual, new OutcomeEqualityComparer());
                    }
                }
            }
        }
    }

}
