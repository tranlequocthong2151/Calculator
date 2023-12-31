﻿using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorTester
{
    [TestClass]
    public class UnitTest1
    {
        private Calculation c;
        public TestContext TestContext { get; set; }

        [TestInitialize] // thiet lap du lieu dung chung cho TC 
        public void SetUp()
        {
            c = new Calculation(50, 15);
        }

        [TestMethod] // TC1: a = 50, b = 15, kq = 65
        public void Test_Cong()
        {
            int expected, actual;
            // Caculation c = new Caculation(a,b);
            expected = 65;
            actual = c.Execute("+");
            Assert.AreEqual(expected, actual);

        }

        [TestMethod] // TC2: a = 50, b = 15, kq = 35
        public void Test_Tru()
        {
            int expected, actual;
            // Caculation c = new Caculation(a,b);
            expected = 35;
            actual = c.Execute("-");
            Assert.AreEqual(expected, actual);

        }

        [TestMethod] // TC3: a = 50, b = 15, kq = 750
        public void Test_Nhan()
        {
            int expected, actual;
            // Caculation c = new Caculation(a,b);
            expected = 750;
            actual = c.Execute("*");
            Assert.AreEqual(expected, actual);

        }

        [TestMethod] // TC4: a = 50, b = 15, kq = 65
        public void Test_Chia()
        {
            int expected, actual;
            // Caculation c = new Caculation(a,b);
            expected = 3;
            actual = c.Execute("/");
            Assert.AreEqual(expected, actual);
        }

        [ExpectedException(typeof(DivideByZeroException))]
        [TestMethod]
        public void Test_ChiaZero() // TC5: a=50,b=0,kq=err
        {
            c = new Calculation(50, 0);
            c.Execute("/");
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", 
            @".\Data\TestData.csv", "TestData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestWithDataSource()
        {
            int a = int.Parse(TestContext.DataRow[0].ToString());
            int b = int.Parse(TestContext.DataRow[1].ToString());
            int expected = int.Parse(TestContext.DataRow[2].ToString());

            Calculation c = new Calculation(a, b);
            int actual = c.Execute("/");
            Assert.AreEqual(expected, actual);

            Utils.writeToExcel(); // Test writing excel purpose
        }
    }
}
