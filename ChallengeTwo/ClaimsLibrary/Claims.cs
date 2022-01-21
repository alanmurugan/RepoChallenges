using System;

namespace ClaimsLibrary
{
    public enum ClaimType
    {
        Car,
        Home,
        Theft
    }
    public class Claim
    {
        public Claim() {}
        public Claim(int claimID, ClaimType claimType, string claimDescription, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim /*isValid is dateOfClaim - dateOfIncident < 30 days*/)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            ClaimDescription = claimDescription;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;

        }
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string ClaimDescription { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }

        public bool IsValid
        {
            get
            {
                return (DateOfClaim - DateOfIncident).TotalDays < 30;
            }
        }
    }
}
