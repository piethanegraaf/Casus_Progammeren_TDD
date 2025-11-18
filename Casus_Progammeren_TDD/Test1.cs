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
    }
}

