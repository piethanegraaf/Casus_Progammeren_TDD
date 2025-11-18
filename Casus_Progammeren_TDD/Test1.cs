namespace Casus_Progammeren_TDD
{
    [TestClass]
    public class UnitTest1
    {
        // test space object
        [TestMethod]
        public void SpaceObjectTest()
        {
            Space objSpace = new Space("Space1", "TypeA", 25, 10, 15);
            string expectedName = "Space1";
            float expectedCapacity = 25;

            Assert.AreEqual(expectedName, objSpace.Naam);
            Assert.AreEqual(expectedCapacity, objSpace.Capacity);
        }

        // test CalculateOxygenUsage method
        [TestMethod]
        public void SpaceObjectTest2()
        {
            Space objSpace = new Space("Space1", "TypeA", 50, 10, 15);
            int numberOfPeople = 5;
            float timeInHours = 2;
            var (oxygenConsumed, oxygenRemaining) = objSpace.CalculateOxygenUsage(numberOfPeople, timeInHours);
            float expectedOxygenConsumed = 30 * numberOfPeople * timeInHours; // 30 * 5 * 2 = 300
            float expectedAvailableOxygen = 50 * 0.21f * 1000; // 50 m³ to liters
            float expectedOxygenRemaining = expectedAvailableOxygen - expectedOxygenConsumed;
            Assert.AreEqual(expectedOxygenConsumed, oxygenConsumed);
            Assert.AreEqual(expectedOxygenRemaining, oxygenRemaining);
        }
    }
}

