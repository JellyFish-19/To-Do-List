using System;
using System.IO;
using System.Net.Mail;
using System.Threading;
using ToDoList;

namespace ToDo
{
    class Program
    {
        static void Main(string[] args)
        {
            MainScreen mainscreen = new MainScreen();
            mainscreen.ShowMainScreen();
        }
    }
}

