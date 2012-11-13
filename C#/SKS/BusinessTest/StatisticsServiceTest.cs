#define TEST
using SKS.Scada.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SKS.Scada.DAL;
using System.Collections.Generic;

namespace BusinessTest
{
    
    
    /// <summary>
    ///This is a test class for StatisticsServiceTest and is intended
    ///to contain all StatisticsServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StatisticsServiceTest
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
        ///A test for GetCustomerStatistics
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ValidationException))]
        public void GetCustomerStatisticsTest()
        {
            IRepository<Measurement> measurerepo = new RepositoryMock<Measurement>();
            StatisticsService target = new StatisticsService(measurerepo); 
            Customer customer = null;
            DateTime StartDate = new DateTime();
            DateTime EndDate = new DateTime();            
            target.GetCustomerStatistics(customer, StartDate, EndDate);
        }

        [TestMethod()]
        public void GetCustomerStatisticsExceptionTest()
        {
            IRepository<Measurement> measurerepo = new RepositoryMock<Measurement>();
            
            DateTime StartDate = DateTime.Now.Subtract(TimeSpan.FromDays(1000)); ;
            DateTime EndDate = StartDate.AddDays(100);
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
            StatisticsService target = new StatisticsService(measurerepo);
            Site site = new Site()
            {
                Description = "Description",
                Latitude = 43.012312,
                Longitude = 12.12312,
                Serialnumber = "!§$%&/()",
                SiteID = 1
            };

            Measurement exp1 = new Measurement()
            {
                MeasurementID = 2,
                Time = StartDate.AddDays(11),
                Value = 100,
                Site = site
            };

            Measurement exp2 = new Measurement()
            {
                MeasurementID = 4,
                Time = StartDate.AddDays(25),
                Value = 100,
                Site = site
            };

            
            
            Measurement somemeasure1 = new Measurement()
            {
                MeasurementID = 1,
                Time = StartDate.Subtract(TimeSpan.FromDays(1)),
                Value = 100,
                Site = site
            };
            site.Measurements.Add(somemeasure1);

            Measurement somemeasure2 = new Measurement()
            {
                MeasurementID = 3,
                Time = EndDate.AddDays(1),
                Value = 100,
                Site = site
            };

            site.Measurements.Add(somemeasure2);
            site.Customer = customer;

            customer.Sites.Add(site);

            measurerepo.Add(somemeasure1);
            measurerepo.Add(somemeasure2);
            measurerepo.Add(exp1);
            measurerepo.Add(exp2);
            List<Measurement> expected =  new List<Measurement>(){ exp1, exp2};
            List<Measurement> actual;
            actual = target.GetCustomerStatistics(customer, StartDate, EndDate);
            CollectionAssert.AreEqual(actual, expected);
        }
    }
}
