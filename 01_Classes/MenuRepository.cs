using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Classes
{
    public class MenuRepository
    {
        protected readonly List<Menu> _menuContent = new List<Menu>();
        public bool AddToMenu(Menu menu)
        {
            int startingCount = _menuContent.Count;
            _menuContent.Add(menu);
            bool wasAdded = (_menuContent.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public List<Menu> GetMenus()
        {
            return _menuContent;
        }
        public bool DeleteMenuItem(Menu existingItem)
        {
            bool deleteResult = _menuContent.Remove(existingItem);
            return deleteResult;
        }
    }
}
