using System;
using ClaimsLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimsObjectTests
{
    [TestClass]
    public class ClaimsTest
    {
        [TestMethod]
        public void TestClaimsConstructor_ShouldSetCorrectValues()
        {
            Claim testClaim = new Claim(24, ClaimType.Home, 2003.45m, new DateTime (2022, 12, 25), new DateTime (2023, 4, 30));
            Assert.AreEqual(2003.45m, testClaim.ClaimAmount);
            Assert.AreEqual(new DateTime (2022, 12, 25), testClaim.DateOfClaim);
        }
    }
}
