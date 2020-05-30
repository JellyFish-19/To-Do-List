using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace ToDoList
{
    class FullList
    {
        public void ShowFullList()
        {
            Console.Clear();
            var toDoList = File.ReadAllText("ToDoList.txt");
            var removeEmptySpace = File.ReadAllLines("ToDoList.txt").Where(arg => !string.IsNullOrWhiteSpace(arg));
            File.WriteAllLines("ToDoList.txt", removeEmptySpace); //pasalina tuscias eilutes po to kai uzduotys istrinamos 

            Console.WriteLine("TO DO LIST:\n--------------------------------------");
            Console.WriteLine(toDoList);
            Start:
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("| 1: Add new |  2: Mark as complete |  3: Add to Priority |");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("| 4: View Priority |  5: Sort alphabetically |  6: Back |  ");
            Console.WriteLine("---------------------------------------------------------  ");

            string select = Console.ReadLine();

            switch (select)
            { 
                case "1":
                    AddNew addNew = new AddNew();
                    addNew.AddNewTask();
                    break;
                case "2":
                    Completed markcomplete = new Completed();
                    markcomplete.WriteToComplete();
                    break;
                case "3":
                    Priority addToPriority = new Priority();
                    addToPriority.WriteToPriority();
                    break;
                case "4":
                    Priority priority = new Priority();
                    priority.PrioritySelection();
                    break;
                case "5":
                    SortByABCS sort = new SortByABCS();
                    sort.ABCfull();
                    break;
                case "6":
                    MainScreen mainScreen = new MainScreen();
                    mainScreen.ShowMainScreen();
                    break;
                default:
                    Console.WriteLine("Wrong input, please try again");
                    goto Start;
            }
        }
    }
}
