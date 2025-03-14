using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FizzBuzz_25_02.UnitTests
{
    [TestClass]
    public class FizzBuzzTests
    {
        private FizzBuzz _fizzBuzz;

        [TestInitialize]
        public void Init()
        {
            _fizzBuzz = new FizzBuzz();
        }

        [TestMethod]
        [DataRow(15, "FIZZBUZZ")]
        [DataRow(30, "FIZZBUZZ")]
        [DataRow(45, "FIZZBUZZ")]
        [DataRow(60, "FIZZBUZZ")]
        public void GetOutput_WithThreeAndFive_ReturnsFizzBuzz(int number, string expected)
        {
            var result = _fizzBuzz.GetOutput(number);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(3)]
        public void GetOutput_WithThree_ReturnsFizz(int number)
        {
            var result = _fizzBuzz.GetOutput(number);

            Assert.AreEqual("FIZZ", result);
        }

        [TestMethod]
        [DataRow(5)]
        public void GetOutput_WithFive_ReturnsBuzz(int number)
        {
            var result = _fizzBuzz.GetOutput(number);

            Assert.AreEqual("BUZZ", result);
        }

        [TestMethod]
        [DataRow(1)]
        public void GetOutput_WithNumber_ReturnsNumber(int number)
        {
            var result = _fizzBuzz.GetOutput(number);

            Assert.AreEqual(result, result);
        }

        [TestMethod]
        public void getOutputWithNumberLowerThanZero_ThrowsExceptionArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => _fizzBuzz.GetOutput(0));
        }
    }
}
