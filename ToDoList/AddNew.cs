using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Threading;

namespace ToDoList
{
    class AddNew
    {
        public void AddNewTask ()
        {
            Console.Write("Write task: ");
            string writeTask = Console.ReadLine();
            string convertToNewLine = (writeTask);
            File.AppendAllText("ToDoList.txt", convertToNewLine);
            Console.WriteLine("Task successfully added!");
            Console.WriteLine("Press Enter to refresh");
            Console.ReadLine();
            FullList fulllist = new FullList();
            fulllist.ShowFullList();
        }
    }
}
