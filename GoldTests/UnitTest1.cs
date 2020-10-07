using System;
using System.Collections.Generic;
using _01_Classes;
using _02_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoldTests
{
    [TestClass]
    public class MenuTests
    {
        [TestMethod]
        public void AddingToMenu()
        {
            Menu content = new Menu();
            MenuRepository repository = new MenuRepository();
            bool cResult = repository.AddToMenu(content);
            Assert.IsTrue(cResult);
        }
        [TestMethod]
        public void ReturnMenu()
        {
            Menu newItem = new Menu();
            MenuRepository repo = new MenuRepository();
            repo.AddToMenu(newItem);
            List<Menu> menuList = repo.GetMenus();
            bool hasItems = menuList.Contains(newItem);
            Assert.IsTrue(hasItems);
        }
        [DataTestMethod]
        [DataRow(CustomerType.Potential, "We currently have the lowest rates on Helicopter Insurance!")]
        public void EmailCheck(CustomerType type, string email)
        {
            Customer content = new Customer("Billy", "Bob", CustomerType.Potential);
            string real = content.Email;
            string expected = email;
            Assert.AreEqual(real, expected);
        }
    }
}
