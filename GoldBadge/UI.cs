using _01_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge
{
    public class UI
    {
        private readonly IConsole _console;
        private readonly MenuRepository _menuRepo = new MenuRepository();

        public UI(IConsole console)
        {
            _console = console;
        }
        public void Run()
        {
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                _console.Clear();
                _console.WriteLine("Enter the number of the action you'd like to select: \n" +
                    "1) See all menu items \n" +
                    "2) Add a new menu item \n" +
                    "3) Delete an old menu item \n" +
                    "4) Exit");
                string userInput = _console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowAllContent();
                        break;
                    case "2":
                        CreateNewItem();
                        break;
                    case "3":
                        RemoveItemFromMenu();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        _console.WriteLine("Please choose a number 1 through 4.");
                        _console.ReadKey();
                        break;
                }
            }
        }
        private void CreateNewItem()
        {
            Menu content = new Menu();

            _console.WriteLine("Please enter the new menu item's menu number");
            int menuNumber = int.Parse(_console.ReadLine());
            content.Number = menuNumber;

            _console.WriteLine("Please enter the item's name");
            string menuTitle = _console.ReadLine();
            content.Name = menuTitle;

            _console.WriteLine("Please enter the item's description");
            string menuDescription = _console.ReadLine();
            content.Description = menuDescription;

            _console.WriteLine("Please enter the item's price");
            decimal menuPrice = decimal.Parse(_console.ReadLine());
            content.Price = menuPrice;

            _console.WriteLine("Please enter the item's list of ingredients.");
            string menuIngredients = _console.ReadLine();
            content.Ingredients = menuIngredients;

            _menuRepo.AddToMenu(content);
        }

        private void ShowAllContent()
        {
            _console.Clear();
            List<Menu> menuList = _menuRepo.GetMenus();
            foreach (Menu content in menuList)
            {
                Display(content);
            }
            _console.WriteLine("Press a key to continue.");
            _console.ReadKey();
        }
        private void RemoveItemFromMenu()
        {
            _console.WriteLine("Which item to remove?");
            List<Menu> contentList = _menuRepo.GetMenus();
            int count = 0;
            foreach (var content in contentList)
            {
                count++;
                _console.WriteLine($"{count}) {content.Name}");
            }
            int targetContentID = int.Parse(_console.ReadLine());
            int correctIndex = targetContentID - 1;
            if (correctIndex >= 0 && correctIndex < contentList.Count)
            {
                Menu desiredContent = contentList[correctIndex];
                if (_menuRepo.DeleteMenuItem(desiredContent))
                {
                    _console.WriteLine($"Item #{desiredContent.Number}: {desiredContent.Name} is removed.");
                }
                else
                {
                    _console.WriteLine("Error 404: File not found.");
                }
            }
            else
            {
                _console.WriteLine("Error... Please try again.");
            }
            _console.WriteLine("Press a key to continue.");
            _console.ReadKey();
        }
        private void Display(Menu menu)
        {
            _console.WriteLine($"{menu.Number}. \n" +
                $"${menu.Price}   {menu.Name} \n" +
                $"{menu.Description} \n" +
                $"Ingredients include: {menu.Ingredients}\n");
        }
    }
}
