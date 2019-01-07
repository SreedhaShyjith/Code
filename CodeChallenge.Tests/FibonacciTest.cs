using CodingChallenge.Models;
using CodingChallenge.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Tests
{
    [TestClass]
    public class FibonacciTest
    {
        FibanocciService fibanocciService;
        public FibonacciTest()
        {
            fibanocciService = new FibanocciService();
        }

        [TestMethod]
        public void FibonacciNegativeInput()
        {
            Fibonacci fibonacciExpected = fibanocciService.GenerateFebinocciSeries(-2);
            Assert.AreEqual(fibonacciExpected.Message, "Please enter a numeric value greater than 0.");
        }

        [TestMethod]
        public void FibonacciZeroAsInput()
        {
            Fibonacci fibonacciExpected = fibanocciService.GenerateFebinocciSeries(0);
            Assert.AreEqual(fibonacciExpected.Message, "Please enter a numeric value greater than 0.");

        }
        [TestMethod]
        public void FibonaccioneAsInput()
        {
            Fibonacci fibonacciExpected = new Fibonacci();
            fibonacciExpected.FibonacciSequence = new List<int> {0};
            fibonacciExpected.Message = "Success";
            Fibonacci fibonacciActual = fibanocciService.GenerateFebinocciSeries(1);
            Assert.IsTrue(fibonacciExpected.FibonacciSequence.SequenceEqual(fibonacciActual.FibonacciSequence));
            Assert.AreEqual(fibonacciExpected.Message, fibonacciActual.Message);
        }

        [TestMethod]
        public void FibonacciResultTest()
        {
            Fibonacci fibonacciExpected = new Fibonacci();
            fibonacciExpected.FibonacciSequence = new List<int> { 0, 1, 1, 2};
            fibonacciExpected.Message = "Success";
            Fibonacci fibonacciActual = fibanocciService.GenerateFebinocciSeries(4);
            Assert.IsTrue(fibonacciExpected.FibonacciSequence.SequenceEqual(fibonacciActual.FibonacciSequence));
            Assert.AreEqual(fibonacciExpected.Message, fibonacciActual.Message);
        }

        [TestMethod]
        public void FibonacciNotEqualResultTest()
        {
            Assert.AreNotEqual(10, fibanocciService.GenerateFebinocciSeries(6));
        }


        [TestMethod]
        public void FibonacciSequenceNullTest()
        {
            Fibonacci fibonacciActual = fibanocciService.GenerateFebinocciSeries(null);
            Assert.IsNull(fibonacciActual.FibonacciSequence);
            Assert.AreEqual(fibonacciActual.Message, "Please enter a numeric value greater than 0.");
        }

        [TestMethod]
        public void FibonacciSequenceTest()
        {
            Fibonacci fibonacciExpected = new Fibonacci();
            fibonacciExpected.FibonacciSequence = new List<int> { 0, 1, 1, 2, 3, 5, 8, 13, 21 };
            fibonacciExpected.Message = "Success";
            Fibonacci fibonacciActual = fibanocciService.GenerateFebinocciSeries(9);
            Assert.IsTrue(fibonacciExpected.FibonacciSequence.SequenceEqual(fibonacciActual.FibonacciSequence));
            Assert.AreEqual(fibonacciExpected.Message, fibonacciActual.Message);
        }
    }
}
