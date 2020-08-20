using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzConsoleApp
{
    public class Program
    {
        /// <summary>
        /// This is my solution to the standard FizzBuzz test. This is extensible, and can have the dictionary stored in 
        /// the app settings, an JSON, XML, or text file. That way the values to be tested, and their string replacements
        /// could be changed without changing the source code, or recompiling. 
        /// </summary>
        /// <param name="args"></param>
        private static void Main()
        {
            Console.Write(FizzBuzz(500));
            
            // Wait for user input so the console does not close.
            Console.Read();
        }

        /// <summary>
        /// Default FizzBuzz system.
        /// </summary>
        /// <returns>A FizzBuzz list for values 1 to 100.</returns>
        public static string FizzBuzz()
        {
            var FizzBuzzValDict = new Dictionary<ushort, string>() {
                { 3, "Fizz" },
                { 5, "Buzz" }
            };

            return FizzBuzz(FizzBuzzValDict, 100);
        }

        /// <summary>
        /// FizzBuzz for a custom number of rounds.
        /// </summary>
        /// <param name="NumberOfRounds"></param>
        /// <returns>A FizzBuzz list for values 1 to NumberOfRounds.</returns>
        public static string FizzBuzz(ushort NumberOfRounds)
        {
            // Argument exception checking.
            if (NumberOfRounds.Equals(0))
                throw new ArgumentException("NumberOfRounds must be greater than 0.", "NumberOfRounds");

            var FizzBuzzValDict = new Dictionary<ushort, string>() {
                { 3, "Fizz" },
                { 5, "Buzz" }
            };

            string returnValues = string.Empty;

            foreach (ushort i in Enumerable.Range(1, NumberOfRounds))
            {
                returnValues += FizzBuzzOneNumber(i, FizzBuzzValDict);
                returnValues += "\r\n";
            }

            return returnValues;
        }

        /// <summary>
        /// Accepts an int to test against and a dictionary of values, int and string, to match against. 
        /// If the int is divisible by a number in the dictionary, then it is replaced by the string.
        /// If it is not divisible by any number in the dictionary, then the int is returned as a string.
        /// 
        /// This method could also be exposed as a web service. 
        /// 
        /// The developer can either use this method that loops through the number of rounds and returns one result,
        /// or they can call the other FizzBuzzMe method and pass in one int value at a time.
        /// </summary>
        /// <param name="FizzBuzzVals"></param>
        /// <param name="NumberOfRounds"></param>
        /// <returns></returns>
        public static string FizzBuzz(Dictionary<ushort, string> FizzBuzzVals, ushort NumberOfRounds)
        {
            // Argument exception checking.
            if (NumberOfRounds.Equals(0))
                throw new ArgumentException("NumberOfRounds must be greater than 0.", "NumberOfRounds");
            if (FizzBuzzVals == null || FizzBuzzVals.Count.Equals(0))
                throw new ArgumentException("FizzBuzzVals must have at least one value.", "FizzBuzzVals");

            string returnValues = string.Empty;

            foreach (ushort i in Enumerable.Range(1, NumberOfRounds))
            {
                returnValues += FizzBuzzOneNumber(i, FizzBuzzVals);
                returnValues += "\r\n";
            }

            return returnValues;
        }

        /// <summary>
        /// Accepts an int to test against and a dictionary of values, int and string, to match against. 
        /// If the int is divisible by a number in the dictionary, then it is replaced by the string.
        /// If it is not divisible by any number in the dictionary, then the int is returned as a string.
        /// 
        /// This method could also be exposed as a web service. 
        /// 
        /// Please note that this method has six unit tests to fully test it's functionality.
        /// </summary>
        /// <param name="iNum">Number to test against</param>
        /// <param name="FizzBuzzVals">Dictionary of numbers and replacement strings.</param>
        /// <returns></returns>
        public static string FizzBuzzOneNumber(ushort iNum, Dictionary<ushort, string> FizzBuzzVals)
        {
            // Argument exception checking.
            if (iNum.Equals(0))
                throw new ArgumentException("iNum must be greater than 0.", "iNum");
            if(FizzBuzzVals == null || FizzBuzzVals.Count.Equals(0))
                throw new ArgumentException("FizzBuzzVals must have at least one value.", "FizzBuzzVals");
            
            string returnVal = string.Empty;

            // Check each value in the dictionary against the int supplied
            foreach(var fbVal in FizzBuzzVals) {
                if (iNum % fbVal.Key == 0)
                    returnVal += fbVal.Value;   // Only add to the string, not replace
                                                // so that the string can show multiple divisible answers.
            }

            if (returnVal != string.Empty)
                return returnVal;

            return iNum.ToString();
        }
    }
}
