namespace SampleExercice.UnitTests
{
    [TestClass]
    public class OrderTests
    {
        private Order _order;

        [TestInitialize]
        public void TestInitialize()
        {
            _order = new Order();
        }
        // TEST 1
        [TestMethod]
        public void HasItems_WithNoItemsInOrder_ReturnsFalse()
        {
            // TEST 1 : On vérifie que si on n'a pas d'items, ça retourne bien false

            Assert.IsFalse(_order.HasItems());
        }

        // TEST 2
        [TestMethod]
        public void GetTotal_WithNoItemsInOrder_ReturnsZero()
        {
            // TEST 2 : On vérifie que GetTotal renvoie bien 0 sans items

            Assert.AreEqual(0, _order.GetTotal());
        }

        // TEST 3
        [TestMethod]
        public void ApplyDiscount_WithNoItemsInOrder_ThrowsException()
        {
            // TEST 3 : On vérifie que l'on peut pas appliquer de remise s'il n'y a pas d'items

            Assert.ThrowsException<Exception>(() => _order.ApplyDiscount(50));
        }

        // TEST 4
        // DATAROW
        [TestMethod]
        [DataRow(-10, 5, 1, 1)]
        [DataRow(10, -5, 1, 1)]
        [DataRow(-10, -5, 1, 1)]

        public void AddItem_WithNegativeQuantityOrNegativePrice_ThrowsArgumentException()
        {
            // TEST 4 : On vérifie que l'on peut pas ajouter d'item si le prix ou la quantité n'est pas bonne (DataRow)

            Assert.ThrowsException<ArgumentException>(() => _order.AddItem("Cela ne peut pas fonctionner !", -10, 5));

        }

        // TEST 5
        [TestMethod]
        public void AddItem_WithCorrectValuesForItem_HasItemsReturnsTrueANDItemsCountIsCorrect()
        {
            // TEST 5 : On ajoute des items et on vérifie que HasItem vaut true et on peut également vérifier la quantité d'items

            Assert.IsTrue(_order.HasItems());
        }

        // TEST 6
        // DATAROW
        [TestMethod]
        [DataRow(-8000)]
        public void ApplyDiscount_WithNegativeValueOrValueHigherThan100_ThrowsArgumentException(double number)
        {
            // TEST 6 : On vérifie qu'on ne peut pas appliquer une remise qui n'est pas entre 0 et 100 (DataRow)

            Assert.ThrowsException<ArgumentException>(() => _order.ApplyDiscount(number));
        }

        // TESTS 7 
        [TestMethod]
        public void ApplyDiscount_WithValidValue_DiscountIsSetCorrectly()
        {
            // TEST 7 : On vérifie que si on applique une remise entre 0 et 100 la propriété Discount est bien modifiée

            Assert.AreEqual(50, _order.Discount);
        }

        // TEST 8
        [TestMethod]
        public void GetTotal_WithItemsAndDiscount_ReturnsExpectedTotal()
        {
            // TEST 8 : On vérifie que GetTotal renvoie bien une valeur cohérente par rapport aux items et à la remise

            Assert.AreEqual(50, _order.GetTotal());
        }
    }
}