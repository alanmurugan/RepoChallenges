using System.Collections.Generic;
using BadgeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadgeTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBadgeConstructor_ShouldSetCorrectValues()
        {
            Badge testBadge = new Badge (1234, new List<string> {"A1", "A2", "B1", "B4"}, "Alyssa");
            Assert.AreEqual(1234, testBadge.BadgeID);
            CollectionAssert.AreEqual(new List<string> {"A1", "A2", "B1", "B4"}, testBadge.DoorAccess);
        }
    }
}
