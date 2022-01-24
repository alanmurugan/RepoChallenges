using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadgeLibrary
{
    public class BadgeRepository
    {
        public Dictionary<int, List<string>> _repo = new Dictionary<int, List<string>>();
        //Add Badge
        public bool AddBadge(Badge newBadge)
        {
            int startingCount = _repo.Count;
            _repo.Add(newBadge.BadgeID, newBadge.DoorAccess);

            return _repo.Count > startingCount;
        }
        //Get All Badges
        public Dictionary<int, List<string>> GetBadges()
        {
            return _repo;
        }
        //Add Door
        public bool AddDoor(Badge existingBadge, string newDoor)
        {
            int startingCount = _repo[existingBadge.BadgeID].Count();
            _repo[existingBadge.BadgeID].Add(newDoor);

            return _repo[existingBadge.BadgeID].Count() > startingCount;
        }
        public bool DeleteDoor(Badge existingBadge, string existingDoor)
        {
            return _repo[existingBadge.BadgeID].Remove(existingDoor);
        }
    }
}