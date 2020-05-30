using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ToDoList
{
    class Completed
    {
        public void ShowCompletedList()
        {
            Console.Clear();
            var completedList = File.ReadAllText("Completed.txt");
            string[] removeDuplicates = File.ReadAllLines("Completed.txt");
            File.WriteAllLines("Completed.txt", removeDuplicates.Distinct().ToArray()); // panaikina duplikatus is full list ir priorities

            Console.WriteLine("COMPLETED:\n--------------------------------------");

            if (new FileInfo("Completed.txt").Length == 0)
            {
                Console.WriteLine("COMPLETED SECTION IS EMPTY");
            }
            else
            {
                Console.WriteLine(completedList);
            }

            Start:
            Console.WriteLine("-------------------------------------------  ");
            Console.WriteLine("| 1: Show all |  2: Priority |   3: Empty |  ");
            Console.WriteLine("-------------------------------------------  ");

            string select = Console.ReadLine(); 

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
                    File.WriteAllText("Completed.txt", String.Empty);
                    Console.WriteLine("Completed tasks successfully deleted!");
                    Console.WriteLine("Press enter to refresh");
                    Console.ReadLine();
                    Console.Clear();
                    Completed completed = new Completed();
                    completed.ShowCompletedList();
                    break;
                default:
                    Console.WriteLine("Wrong input, please try again:");
                    goto Start;
            }
        }

        public void WriteToComplete()
        {
            var toDoList = File.ReadAllLines("ToDoList.txt");
            var priorityList = File.ReadAllLines("ToDoListPriority.txt");
            var completedList = "Completed.txt";
            Start:
            Console.Write("\nEnter task you completed: ");
            var itemToMove = Console.ReadLine();
            var wasFound = false;
            foreach (var item in toDoList)
            {
                if (item.Contains(itemToMove, StringComparison.InvariantCultureIgnoreCase))
                {
                    wasFound = true;
                    if (!File.Exists(completedList))
                    {
                        using var file = File.Create(completedList);
                    }
                    File.AppendAllLines(completedList, new[] { item });
                    Console.WriteLine($"Task {item} moved to Completed");

                    var tempFile = Path.GetTempFileName();
                    var linesToKeep = toDoList.Where(l => l != item);
                    File.WriteAllLines(tempFile, linesToKeep);
                    File.Delete("ToDoList.txt");
                    File.Move(tempFile, "ToDoList.txt");
                }
            }
            if (!wasFound)
            {
                Console.WriteLine("No such task exist, please try again:");
                goto Start;
            }
            foreach (var item in priorityList)
            {
                if (item.Contains(itemToMove, StringComparison.InvariantCultureIgnoreCase))
                {
                    wasFound = true;
                    if (!File.Exists(completedList))
                    {
                        using var file = File.Create(completedList);
                    }
                    File.AppendAllLines(completedList, new[] { item });
                    Console.WriteLine($"Priority task {item} moved to Completed");

                    var tempFile = Path.GetTempFileName();
                    var linesToKeep = priorityList.Where(l => l != item);
                    File.WriteAllLines(tempFile, linesToKeep);
                    File.Delete("ToDoListPriority.txt");
                    File.Move(tempFile, "ToDoListPriority.txt");
                }
            }
            if (!wasFound)
            {
                Console.WriteLine("No such task exist, please try again:");
                goto Start;
            }

            RestartZone:
            Console.WriteLine("----------------------------------------------------------------------  ");
            Console.WriteLine("| 1: Show all | 2: Mark another completed task |  3: View completed  |  ");
            Console.WriteLine("----------------------------------------------------------------------  ");
            string select = Console.ReadLine();

            switch (select)
            {
                case "1":
                    FullList fulllist = new FullList();
                    fulllist.ShowFullList();
                    break;
                case "2":
                    goto Start;
                case "3":
                    Completed completed = new Completed();
                    completed.ShowCompletedList();
                    break;
                default:
                    Console.WriteLine("Wrong number, please try again:");
                    goto RestartZone;
            }
        }
    }
}
