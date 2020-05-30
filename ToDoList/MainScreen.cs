using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList
{
    class MainScreen
    {
        public void ShowMainScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("    ▀█▀ █▀█   █▀▄ █▀█   █   █ █▀ ▀█▀    ");
            Console.WriteLine("     █  █▄█   █▄▀ █▄█   █▄▄ █ ▄█  █     ");
            Console.WriteLine();    
            Console.WriteLine("----------------------------------------------    ");
            Console.WriteLine("| 1: Show all |  2: Priority |  3: Completed |    ");
            Console.WriteLine("----------------------------------------------    ");

            Start:
            string select = Console.ReadLine(); // konvertuoju input i string, kad vietoj skaiciaus ivedus teksta programa neuzluztu

            switch (select)
            {
                case "1":
                    FullList fulllist = new FullList();
                    fulllist.ShowFullList();
                    break;
                case "2":
                    Priority priority = new Priority();
                    priority.PrioritySelection();
                    break;
                case "3":
                    Completed completed = new Completed();
                    completed.ShowCompletedList();
                    break;
                default:
                    Console.Write("Wrong input. Please try again: ");
                    goto Start;
            }
        }
    }
}

