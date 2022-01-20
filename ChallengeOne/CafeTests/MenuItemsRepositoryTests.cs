using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MenuItemsTests
{

    [TestClass]
    public class MenuItemsRepositoryTests
    {
        private MenuItem _item;
        private MenuItemsRepository _repo;
        [TestInitialize]

        //Add menu items
        [TestMethod]
        public void AddMenuItem_ShouldReturnTrue()
        {
            //Arrange
            _item = new MenuItem();
            _repo = new MenuItemsRepository();
            //Arrange
            bool result = _repo.AddMenuItem(_item);
            //Assert
            Assert.IsTrue(result);
        }

        //Get all menu items
        [TestMethod]
        public void GetAllMenuItems_ShouldReturnCorrectCount()
        {
            //Arrange
            _item = new MenuItem();
            MenuItem itemTwo = new MenuItem();
            MenuItem itemThree = new MenuItem();
            _repo = new MenuItemsRepository();
            _repo.AddMenuItem(_item);
            _repo.AddMenuItem(itemTwo);
            _repo.AddMenuItem(itemThree);
            //Act
            List<MenuItem> result = _repo.GetMenuItems();
            //Assert
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnFalse()
        {
            //Arrange
            _item = new MenuItem();
            MenuItem itemTwo = new MenuItem();
            MenuItem itemThree = new MenuItem();
            _repo = new MenuItemsRepository();
            _repo.AddMenuItem(_item);
            _repo.AddMenuItem(itemTwo);
            _repo.AddMenuItem(itemThree);
            //Act
            _repo.DeleteMenuItem(_item);
            List<MenuItem> result = _repo.GetMenuItems();
            //Assert
            Assert.IsFalse(result.Contains(_item));
        }

    }
}