using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Threading;

namespace ToDoList
{
	class Priority
	{
		public void PrioritySelection()
		{
			Console.Clear();
			// todoItemDataManager.GetItems();
			string priority = File.ReadAllText("ToDoListPriority.txt");
			Console.WriteLine("PRIORITY:\n--------------------------------------");
			Console.WriteLine(priority);
			Start:
			Console.WriteLine("---------------------------------------------------------------------------------------------  ");
			Console.WriteLine("| 1: Show all |  2: Mark as complete |  3:  Sort alphabetically  | 4: Completed |  5: Back  |  ");
			Console.WriteLine("---------------------------------------------------------------------------------------------  ");

			string select = Console.ReadLine();

			switch (select)
			{
				case "1":
					FullList fulllist = new FullList();
					fulllist.ShowFullList();
					break;
				case "2":
					Completed markcomplete = new Completed();
					markcomplete.WriteToComplete();
					break;
				case "3":
					SortByABCS sort = new SortByABCS();
					sort.ABCpriority();
					break;
				case "4":
					Completed completed = new Completed();
					completed.ShowCompletedList();
					break;
				case "5":
					MainScreen mainscreen = new MainScreen();
					mainscreen.ShowMainScreen();
					break;
				default:
					Console.WriteLine("Wrong input, please try again:");
					goto Start;
			}
		}

		public void WriteToPriority()
		{
			var toDoList = File.ReadAllLines("ToDoList.txt");
			var newFilePath = "ToDoListPriority.txt";
			Start:
			Console.Write("\nEnter task to copy: ");
			var itemToCopy = Console.ReadLine();
			var wasFound = false;

			foreach (var item in toDoList)
			{
				if (item.Contains(itemToCopy, StringComparison.InvariantCultureIgnoreCase))
				{
					wasFound = true;
					if (!File.Exists(newFilePath))
					{
						using var file = File.Create(newFilePath);
					}
					File.AppendAllLines(newFilePath, new[] { item });
					Console.WriteLine($"Task {item} copied to Priorities");
					Console.WriteLine();
					Console.WriteLine("----------------------------------------------    ");
					Console.WriteLine("| 1: View priority |  2: Completed |  3: Back |   ");
					Console.WriteLine("----------------------------------------------    ");

					string select = Console.ReadLine();

					switch (select)
					{
						case "1":
							Priority priority = new Priority();
							priority.PrioritySelection();
							break;
						case "2":
							Completed completed = new Completed();
							completed.ShowCompletedList();
							break;
						case "3":
							MainScreen mainscreen = new MainScreen();
							mainscreen.ShowMainScreen();
							break;
						default:
							Console.WriteLine("Wrong number, please try again:");
							goto Start;
					}
				}
			}
			if (!wasFound)
			{
				Console.WriteLine("No such task exist, please try again:");
				goto Start;
			}
		}
	}
}