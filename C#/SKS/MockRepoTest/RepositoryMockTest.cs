using SKS.Scada.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MockRepoTest
{
    
    
    /// <summary>
    ///This is a test class for RepositoryMockTest and is intended
    ///to contain all RepositoryMockTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RepositoryMockTest
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
        ///A test for Add
        ///</summary>
        public void AddTestHelper<T>()
            where T : class
        {
            RepositoryMock<T> target = new RepositoryMock<T>(); // TODO: Initialize to an appropriate value
            T EntityObject = null; // TODO: Initialize to an appropriate value
            target.Add(EntityObject);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void AddTest()
        {
            AddTestHelper<MeasurementTyp>();
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        public void DeleteTestHelper<T>()
            where T : class
        {
            RepositoryMock<T> target = new RepositoryMock<T>(); // TODO: Initialize to an appropriate value
            T EntityObject = null; // TODO: Initialize to an appropriate value
            target.Delete(EntityObject);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void DeleteTest()
        {
            DeleteTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for GetAll
        ///</summary>
        public void GetAllTestHelper<T>()
            where T : class
        {
            RepositoryMock<T> target = new RepositoryMock<T>(); // TODO: Initialize to an appropriate value
            List<T> expected = null; // TODO: Initialize to an appropriate value
            List<T> actual;
            actual = target.GetAll();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void GetAllTest()
        {
            GetAllTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        public void UpdateTestHelper<T>()
            where T : class
        {
            RepositoryMock<T> target = new RepositoryMock<T>(); // TODO: Initialize to an appropriate value
            T EntityObject = null; // TODO: Initialize to an appropriate value
            target.Update(EntityObject);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void UpdateTest()
        {
            UpdateTestHelper<GenericParameterHelper>();
        }
    }
}
