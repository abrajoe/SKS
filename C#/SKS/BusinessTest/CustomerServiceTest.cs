#define TEST

using SKS.Scada.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SKS.Scada.DAL;
using System.Collections.Generic;


namespace BusinessTest
{
    
    
    /// <summary>
    ///This is a test class for CustomerServiceTest and is intended
    ///to contain all CustomerServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CustomerServiceTest
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
        ///A test for GetCustomers
        ///</summary>
        [TestMethod()]
        public void GetCustomersTest()
        {
            Technician technician = new Technician(); 
            technician.TechnicianID = 1;
            technician.Person = new Person()
            {
                Email = "person@person.com",
                Firstname = "PersonVorname",
                Lastname = "PersonNachname",
                Password = "!§$%&/()=",
                Username = "person"
            };

            Customer cus = new Customer()
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
            technician.Customers.Add(cus);

            CustomerService target = new CustomerService(new RepositoryMock<Customer>());

            List<Customer> expected = new List<Customer>(technician.Customers) ; 
            List<Customer> actual;
            actual = target.GetCustomers(technician);
            Assert.AreEqual(expected[0], actual[0]);
            
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidationException))]
        public void GetCustomersTestValidationException()
        {
            Technician technician = null;
            CustomerService service = new CustomerService(new RepositoryMock<Customer>());
            service.GetCustomers(technician);
        }

    }
}
