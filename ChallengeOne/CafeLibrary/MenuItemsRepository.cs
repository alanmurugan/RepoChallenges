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
        //CRUD
        //CREATE
        //Add Menu Items
        public bool AddMenuItem(MenuItem newItem)
        {
            int initialCount = _repo.Count;
            _repo.Add(newItem);

            return _repo.Count > initialCount;
        }
        //READ
        //See All Menu Items
        public List<MenuItem> GetContents()
        {
            return _repo;
        }
        //UPDATE (not needed for assignment)
        //Optional: Update Menu Item

        //DELETE
        //Delete Menu Items
        public bool DeleteMenuItem(MenuItem existingItem)
        {
            return _repo.Remove(existingItem);
        }
    }
}