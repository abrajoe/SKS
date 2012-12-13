using SKS.Scada.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SKS.Scada.DAL;
using System.Collections.Generic;

namespace BusinessTest
{
    
    
    /// <summary>
    ///This is a test class for SiteServiceTest and is intended
    ///to contain all SiteServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SiteServiceTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetLatestSiteState
        ///</summary>
        [TestMethod()]
        public void GetLatestSiteStateTest()
        {
            SiteService target = new SiteService(new RepositoryMock<Site>(), new RepositoryMock<Measurement>());
            Site site = new Site()
            {
                Description = "Description",
                Latitude = 43.012312,
                Longitude = 12.12312,
                Serialnumber = "!§$%&/()",
                SiteID = 1
            };
            Measurement expected = new Measurement()
            {
                MeasurementID = 1,
                Time = DateTime.Now,
                Value = 100
            };
            site.Measurements.Add(expected);
            site.Measurements.Add(new Measurement()
            {
                MeasurementID = 2,
                Time = DateTime.Now.Subtract(TimeSpan.FromDays(1000)),
                Value = 100
            });

            site.Measurements.Add(new Measurement()
            {
                MeasurementID = 3,
                Time = DateTime.Now.Subtract(TimeSpan.FromHours(1)),
                Value = 100
            });


            site.Measurements.Add(new Measurement()
            {
                MeasurementID = 4,
                Time = DateTime.Now.Subtract(TimeSpan.FromSeconds(1)),
                Value = 100
            });

            Measurement actual;
            actual = target.GetLatestSiteState(site);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetSites
        ///</summary>
        [TestMethod()]
        public void GetSitesTest()
        {
            SiteService target = new SiteService(new RepositoryMock<Site>(), new RepositoryMock<Measurement>());
            Customer customer = new Customer()
            {
                Person = new Person()
                {
                    Email = "person@person.com",
                    Firstname = "PersonVorname",
                    Lastname = "PersonNachname",
                    Password = "!§$%&/()=",
                    Username = "person"
                }
            };

            customer.Sites.Add(new Site()
            {
                Description = "Description",
                Latitude = 43.012312,
                Longitude = 12.12312,
                Serialnumber = "!§$%&/()",
                SiteID = 1
            });

            customer.Sites.Add(new Site()
            {
                Description = "Description",
                Latitude = 43.012312,
                Longitude = 12.12312,
                Serialnumber = "!§$%&/()",
                SiteID = 2
            });

            List<Site> expected = new List<Site>(customer.Sites);
            List<Site> actual;
            actual = target.GetSites(customer);
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidationException))]
        public void GetLatestSiteExceptionStateTest()
        {
            SiteService siteservice = new SiteService(new RepositoryMock<Site>(), new RepositoryMock<Measurement>());
            siteservice.GetLatestSiteState(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidationException))]
        public void GetSitesExceptionStateTest()
        {
            SiteService siteservice = new SiteService(new RepositoryMock<Site>(), new RepositoryMock<Measurement>());
            siteservice.GetSites(null);
        }
    }
}
