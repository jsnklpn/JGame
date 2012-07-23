using JGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace JGame_UnitTests
{
    
    
    /// <summary>
    ///This is a test class for RevolvingDoorTimerTest and is intended
    ///to contain all RevolvingDoorTimerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RevolvingDoorTimerTest
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
        ///A test for AverageDelta
        ///</summary>
        [TestMethod()]
        public void AverageDeltaTest1_None()
        {
            int maxCapacity = 10;
            RevolvingDoorTimer target = new RevolvingDoorTimer(maxCapacity);
            float expected = 0f;
            float actual;
            actual = target.AverageDelta();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for AverageDelta
        ///</summary>
        [TestMethod()]
        public void AverageDeltaTest2_One()
        {
            int maxCapacity = 10;
            RevolvingDoorTimer target = new RevolvingDoorTimer(maxCapacity);
            int valueToAdd = 5;
            float expected = 0f;
            float actual;
            target.AddTick(valueToAdd);
            actual = target.AverageDelta();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for AverageDelta
        ///</summary>
        [TestMethod()]
        public void AverageDeltaTest3_NotFilled()
        {
            int maxCapacity = 10;
            RevolvingDoorTimer target = new RevolvingDoorTimer(maxCapacity);

            int amountToAdd = maxCapacity - 1;
            int total = 0;
            for (int i = 0; i < amountToAdd; i++)
            {
                target.AddTick(i);
                total += i;
            }

            float expected = 1f;
            float actual;
            actual = target.AverageDelta();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for AverageDelta
        ///</summary>
        [TestMethod()]
        public void AverageDeltaTest4_Filled()
        {
            int maxCapacity = 10;
            RevolvingDoorTimer target = new RevolvingDoorTimer(maxCapacity);

            int total = 0;
            for (int i = 0; i < maxCapacity; i++)
            {
                target.AddTick(i);
                total += i;
            }

            float expected = 1f;
            float actual;
            actual = target.AverageDelta();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for AverageDelta
        ///</summary>
        [TestMethod()]
        public void AverageDeltaTest5_FilledExtra()
        {
            int maxCapacity = 10;
            RevolvingDoorTimer target = new RevolvingDoorTimer(maxCapacity);

            // Add number to throw it off, then add max numbers to overwrite this value
            target.AddTick(1234567);

            int total = 0;
            for (int i = 0; i < maxCapacity; i++)
            {
                target.AddTick(i);
                total += i;
            }

            float expected = 1f;
            float actual;
            actual = target.AverageDelta();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for AverageDelta
        ///</summary>
        [TestMethod()]
        public void AverageDeltaTest6_FilledTons()
        {
            int maxCapacity = 10;
            RevolvingDoorTimer target = new RevolvingDoorTimer(maxCapacity);

            // Add numbers to throw it off, then add max numbers to overwrite this value
            for (int i = 0; i < 5000; i++)
            {
                target.AddTick(i * 5);
            }

            int total = 0;
            for (int i = 0; i < maxCapacity; i++)
            {
                target.AddTick(i);
                total += i;
            }

            float expected = 1f;
            float actual;
            actual = target.AverageDelta();
            Assert.AreEqual(expected, actual);

        }
    }
}
