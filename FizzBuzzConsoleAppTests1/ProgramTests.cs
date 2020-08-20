using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FizzBuzzConsoleApp.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        /// <summary>
        /// Test for a text replacement.
        /// </summary>
        [TestMethod()]
        public void FizzBuzzMatchTest()
        {
            var FizzBuzzValDict = new Dictionary<ushort, string>() { { 5, "Five" }, { 2, "Two" } };

            var resultStr = Program.FizzBuzzOneNumber(5, FizzBuzzValDict);

            Assert.AreEqual(resultStr, "Five");
        }

        /// <summary>
        /// Test when there is not a text replacement.
        /// </summary>
        [TestMethod()]
        public void FizzBuzzNotMatchTest()
        {
            var FizzBuzzValDict = new Dictionary<ushort, string>() { { 5, "Five" }, { 2, "Two" } };

            var resultStr = Program.FizzBuzzOneNumber(7, FizzBuzzValDict);

            Assert.AreEqual(resultStr, "7");
        }

        /// <summary>
        /// Test for multiple matches.
        /// </summary>
        [TestMethod()]
        public void FizzBuzzMultipleMatchTest()
        {
            var FizzBuzzValDict = new Dictionary<ushort, string>() { { 3, "Fizz" }, { 5, "Buzz" } };

            var resultStr = Program.FizzBuzzOneNumber(15, FizzBuzzValDict);

            Assert.AreEqual(resultStr, "FizzBuzz");
        }

        /// <summary>
        /// Test for exceptions where the list is empty.
        /// </summary>
        [TestMethod()]
        public void FizzBuzzEmptyListTest()
        {
            var FizzBuzzValDict = new Dictionary<ushort, string>();

            Assert.ThrowsException<ArgumentException>(() => Program.FizzBuzzOneNumber(1, FizzBuzzValDict));
        }

        /// <summary>
        /// Test where a list is null.
        /// </summary>
        [TestMethod()]
        public void FizzBuzzNullListTest()
        {
            Dictionary<ushort, string> FizzBuzzValDict = null;

            Assert.ThrowsException<ArgumentException>(() => Program.FizzBuzzOneNumber(1, FizzBuzzValDict));
        }

        /// <summary>
        /// Test where a test int is 0.
        /// </summary>
        [TestMethod()]
        public void FizzBuzzZeroTestNumTest()
        {
            var FizzBuzzValDict = new Dictionary<ushort, string>() { { 3, "Fizz" }, { 5, "Buzz" } };

            Assert.ThrowsException<ArgumentException>(() => Program.FizzBuzzOneNumber(0, FizzBuzzValDict));
        }
    }
}