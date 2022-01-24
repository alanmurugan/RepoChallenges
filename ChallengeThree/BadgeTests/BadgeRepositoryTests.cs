using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BadgeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadgeTests
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        private Badge _badge;
        private BadgeRepository _repo;
        [TestInitialize]

        //Add Badge
        [TestMethod]
        public void AddBadge_ShouldReturnTrue()
        {
            _badge = new Badge();
            _repo = new BadgeRepository();
            bool result = _repo.AddBadge(_badge);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GetAllBadges_ShouldReturnCorrectCount()
        {
            _badge = new Badge();
            Badge badge2 = new Badge(1, null, null);
            Badge badge3 = new Badge(2, null, null);
            _repo = new BadgeRepository();
            _repo.AddBadge(_badge);
            _repo.AddBadge(badge2);
            _repo.AddBadge(badge3);
            Dictionary<int, List<string>> result = _repo.GetBadges();
            Assert.AreEqual(3, result.Count());
        }
        [TestMethod]
        public void AddDoorToBadge_ShouldReturnCorrectDoor()
        {
            _badge = new Badge(1, new List<string> { }, null);
            _repo = new BadgeRepository();
            _repo.AddBadge(_badge);
            _repo.AddDoor(_badge, "A5");
            CollectionAssert.AreEqual(new List<string> { "A5" }, _badge.DoorAccess);
        }
        [TestMethod]
        public void DeleteDoorFromBadge_ShouldReturnFalse()
        {
            _badge = new Badge(1, new List<string> {"A5","B2","B4","C1"}, null);
            _repo = new BadgeRepository();
            _repo.AddBadge(_badge);
            _repo.DeleteDoor(_badge, "B2");
            Assert.IsFalse(_badge.DoorAccess.Contains("B2"));
        }
    }
}