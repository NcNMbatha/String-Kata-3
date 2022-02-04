using NUnit.Framework;
using KataAttemptThree;
using System;

namespace KataAttemptThreeTest
{
    public class AttempThreeTest
    {
        AttemptThree kata;
        [SetUp]
        public void Setup()
        {
            kata = new AttemptThree();
        }

        [Test]
        public void AddTestEmpty()
        {
            int results = kata.Add("");
            int expected = 0;
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void AddTestOneDigit()
        {
            int results = kata.Add("1");
            int expected = 1;
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void AddTestMultiplyDigits()
        {
            int results = kata.Add("1,2");
            int expected = 3;
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void AddTestMultiplyDelimeters()
        {
            int results = kata.Add("1\n2,3");
            int expected = 6;
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void AddTestNewDelimeter()
        {
            int results = kata.Add("//;\n1;2");
            int expected = 3;
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void AddTestThrowNegetiveException()
        {
            Assert.Throws<Exception>(() => kata.Add("1\n2,-3"));
        }
        [Test]
        public void AddTestSkipNumbersGreaterThanThousand()
        {
            int results = kata.Add("//;\n1;2000,2");
            int expected = 3;
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void AddTestDelimetersWithDifferentLength()
        {
            int results = kata.Add("//%%%\n1%%%2%%%3");
            int expected = 6;
            Assert.AreEqual(expected, results);
        }
    }
}