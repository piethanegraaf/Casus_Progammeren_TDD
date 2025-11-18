namespace Casus_Progammeren_TDD
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetNameTest()
        {
            // Arrange
            Employee objEmployee = new Employee();
            string firstName = "Narasimha";
            string lastName = "Reddy";
            string expected = "Narasimha Reddy";
            string actual;
            // Act
            actual = objEmployee.GetName(firstName, lastName);
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

