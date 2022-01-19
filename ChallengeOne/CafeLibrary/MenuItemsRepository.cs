using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeLibrary
{
    public class MenuItemsRepository
    {
        //Empty repo for Menu Items
        private readonly List<MenuItem> _repo = new List<MenuItem>();

        //See All Menu Items
        public List<MenuItem> GetContents()
        {
            return _repo;
        }
        //Add Menu Items
        public bool AddMenuItems(MenuItem item)
        {
            int initialCount = _repo.Count;
            _repo.Add(item);

            return _repo.Count > initialCount;
        }

        //Delete Menu Items
    }
}