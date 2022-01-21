using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsLibrary
{
    public class ClaimsRepository
    {
        private readonly List<Claim> _repo = new List<Claim>();
        //Add claim
        public bool AddClaim(Claim newClaim)
        {
            int startingCount = _repo.Count;
            _repo.Add(newClaim);

            return _repo.Count > startingCount;
        }
        //Get claims
        public List<Claim> GetClaims()
        {
            return _repo;
        }
        //Delete claim
        public bool DeleteClaim(Claim existingClaim) {
            return _repo.Remove(existingClaim);
        }
    }
}