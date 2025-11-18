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

        [TestMethod]
        // ruimte 1: lokaal P2.167 "ICT lokaal", inhoud van 500 m3, met capaciteit van 60
        // personen, met 52 aanwezige studenten, met 2 docenten, 3 uur college.


        public void SpaceObjectRoom1()
        {
            Space objSpace = new Space("ICT lokaal", "lokaal", 500, 0, 0);
            int numberOfPeople = 54; // 52 students + 2 teachers
            float timeInHours = 3;
            var (oxygenConsumed, oxygenRemaining, timeOxygenLasts) = objSpace.CalculateOxygenUsage(numberOfPeople, timeInHours);
            float expectedOxygenConsumed = 30 * numberOfPeople * timeInHours; // 4860 liters
            float expectedOxygenRemaining = (500 * 0.21f * 1000) - expectedOxygenConsumed; // 105000 - 4860 = 100140 liters
            float expectedTimeOxygenLasts = (500 * 0.21f * 1000) / (30 * numberOfPeople); // 64.81 hours
            Assert.AreEqual(expectedOxygenConsumed, oxygenConsumed);
            Assert.AreEqual(expectedOxygenRemaining, oxygenRemaining);
            Assert.AreEqual(expectedTimeOxygenLasts, timeOxygenLasts);
        }

        [TestMethod]
        // ruimte 2: overlegruimte S0.096 "werkruimte", inhoud van 45 m3, met capaciteit van
        // 4 personen, met 4 aanwezige personen, 1.5 uur vergadering.

        public void SpaceObjectRoom2()
        {
            Space objSpace = new Space("werkruimte", "overlegruimte", 45, 0, 0);
            int numberOfPeople = 4;
            float timeInHours = 1.5f;
            var (oxygenConsumed, oxygenRemaining, timeOxygenLasts) = objSpace.CalculateOxygenUsage(numberOfPeople, timeInHours);
            float expectedOxygenConsumed = 30 * numberOfPeople * timeInHours; // 180 liters
            float expectedOxygenRemaining = (45 * 0.21f * 1000) - expectedOxygenConsumed; // 9450 - 180 = 9270 liters
            float expectedTimeOxygenLasts = (45 * 0.21f * 1000) / (30 * numberOfPeople); // 65 hours
            Assert.AreEqual(expectedOxygenConsumed, oxygenConsumed);
            Assert.AreEqual(expectedOxygenRemaining, oxygenRemaining);
            Assert.AreEqual(expectedTimeOxygenLasts, timeOxygenLasts);
        }

        [TestMethod]
        // ruimte 3: lokaal E0.000 "bowling", inhoud van -20 m3, met capaciteit van 10
        // personen, met -5 aanwezige personen.
        // Dit zou een error moeten geven bij het aanmaken van de ruimte met bericht "ongeldige waarde voor inhoud ruimte".
        // Dit zou een error moeten geven bij de berekening met bericht "ongeldige waarde voor aantal personen".

        public void SpaceObjectRoom3()
        {
            try
            {
                Space objSpace = new Space("bowling", "lokaal", -20, 0, 0);
                Assert.Fail("Expected exception for invalid room volume not thrown.");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("ongeldige waarde voor inhoud ruimte", ex.Message);
            }
            try
            {
                Space objSpace = new Space("bowling", "lokaal", 20, 0, 0);
                int numberOfPeople = -5;
                float timeInHours = 1;
                var result = objSpace.CalculateOxygenUsage(numberOfPeople, timeInHours);
                Assert.Fail("Expected exception for invalid number of people not thrown.");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("ongeldige waarde voor aantal personen", ex.Message);
            }

        }


        // test CalculateOxygenUsage method
        [TestMethod]
        public void SpaceObjectTest2()
        {
            Space objSpace = new Space("Space1", "TypeA", 50, 10, 15);
            int numberOfPeople = 5;
            float timeInHours = 2;
            var (oxygenConsumed, oxygenRemaining, timeOxygenLasts) = objSpace.CalculateOxygenUsage(numberOfPeople, timeInHours);
            float expectedOxygenConsumed = 30 * numberOfPeople * timeInHours; // 300 liters
            float expectedOxygenRemaining = (50 * 0.21f * 1000) - expectedOxygenConsumed; // 10500 - 300 = 10200 liters
            float expectedTimeOxygenLasts = (50 * 0.21f * 1000) / (30 * numberOfPeople); // 70 hours
            Assert.AreEqual(expectedOxygenConsumed, oxygenConsumed);
            Assert.AreEqual(expectedOxygenRemaining, oxygenRemaining);
            Assert.AreEqual(expectedTimeOxygenLasts, timeOxygenLasts);
        }
    }
}

