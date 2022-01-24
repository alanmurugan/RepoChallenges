using System;
using System.Collections.Generic;

namespace BadgeLibrary
{
    public class Badge
    {
        public Badge() { }
        public Badge(int badgeID, List<string> doorAccess, string badgeName)
        {
            BadgeID = badgeID;
            DoorAccess = doorAccess;
            BadgeName = badgeName;
        }
        public int BadgeID { get; set; }
        public List<string> DoorAccess { get; set; }
        public string BadgeName { get; set; }

    }
}
