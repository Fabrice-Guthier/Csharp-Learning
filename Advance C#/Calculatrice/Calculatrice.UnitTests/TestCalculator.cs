namespace Calculatrice.UnitTests
{
    [TestClass]
    public class TestCalculator
    {
        private Calculator _calculator;

        [TestInitialize]
        public void Init()
        {
            _calculator = new Calculator();
        }

        [TestMethod]
        [DataRow(10, 4, 14)]
        [DataRow(10, 0, 10)]
        [DataRow(13, 15, 28)]
        public void Add_withTwoNumbers_ReturnAddition(int numberOne, int numberTwo, int expectedResult)
        {
            // Arrange
            // Act
            var result = _calculator.Add(numberOne, numberTwo);
            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Substract_withTwoNumbers_ReturnSubstraction()
        {
            // Arrange
            // Act
            var result = _calculator.Substract(10, 4);
            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]

        public void Multiply_withTwoNumbers_ReturnMultiplication()
        {
            // Arrange
            // Act
            var result = _calculator.Multiply(10, 4);
            // Assert
            Assert.AreEqual(40, result);
        }

        [TestMethod]

        public void Divide_withTwoNumbers_ReturnDivision()
        {
            // Arrange
            // Act
            var result = _calculator.Divide(10, 4);
            // Assert
            Assert.AreEqual(2.5f, result);
        }

        [TestMethod]
        
        public void TestDivision_ThrowDivideByZeroException()
        {
            // Arrange
        
            // Act
            // Assert
            Assert.ThrowsException<ArgumentException>(() => _calculator.Divide(10, 0));
        }
    }
}
