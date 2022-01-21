using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClaimsLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimsTest
{
    [TestClass]
    public class ClaimsRepositoryTests
    {
        private Claim _claim;
        private ClaimsRepository _repo;
        [TestInitialize]

        //Add menu items
        [TestMethod]
        public void AddClaim_ShouldReturnTrue()
        {
            _claim = new Claim();
            _repo = new ClaimsRepository();
            bool result = _repo.AddClaim(_claim);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GetAllClaims_ShouldReturnCorrectCount()
        {
            _claim = new Claim();
            Claim claimTwo = new Claim();
            Claim claimThree = new Claim();
            Claim claimFour = new Claim();
            _repo = new ClaimsRepository();
            _repo.AddClaim(_claim);
            _repo.AddClaim(claimTwo);
            _repo.AddClaim(claimThree);
            _repo.AddClaim(claimFour);
            List<Claim> result = _repo.GetClaims();
            Assert.AreEqual(4, result.Count);
        }
        [TestMethod]
        public void DeleteClaim_ShouldReturnFalse()
        {
            _claim = new Claim();
            Claim claimTwo = new Claim();
            Claim claimThree = new Claim();
            Claim claimFour = new Claim();
            _repo = new ClaimsRepository();
            _repo.AddClaim(_claim);
            _repo.AddClaim(claimTwo);
            _repo.AddClaim(claimThree);
            _repo.AddClaim(claimFour);
            _repo.DeleteClaim(_claim);
            List<Claim> result = _repo.GetClaims();
            Assert.IsFalse(result.Contains(_claim));
        }
    }
}