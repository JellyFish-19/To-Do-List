using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ToDoList
{
    class SortByABCS
    {
        public void ABCfull()
        {
            FileStream readerStream = new FileStream("ToDoList.txt", FileMode.Open);
            string[] content = null;

            using (StreamReader reader = new StreamReader(readerStream))
            {
                content = reader.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                readerStream.SetLength(0);
            }

            FileStream writerStream = new FileStream("ToDoList.txt", FileMode.OpenOrCreate);
            using (StreamWriter writer = new StreamWriter(writerStream))
            {
                Array.Sort(content);
                writer.Write(string.Join(Environment.NewLine, content));
            }

            Console.WriteLine("Tasks sorted alphabetically");
            Console.WriteLine("Press Enter to refresh");
            Console.ReadLine();
            FullList fulllist = new FullList();
            fulllist.ShowFullList();
        }

        public void ABCpriority()
        {
            FileStream readerStream = new FileStream("ToDoListPriority.txt", FileMode.Open);
            string[] content = null;

            using (StreamReader reader = new StreamReader(readerStream))
            {
                content = reader.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                readerStream.SetLength(0);
            }

            FileStream writerStream = new FileStream("ToDoListPriority.txt", FileMode.OpenOrCreate);
            using (StreamWriter writer = new StreamWriter(writerStream))
            {
                Array.Sort(content);
                writer.Write(string.Join(Environment.NewLine, content));
            }

            Console.WriteLine("Tasks sorted alphabetically");
            Console.WriteLine("Press Enter to refresh");
            Console.ReadLine();
            Priority priority = new Priority();
            priority.PrioritySelection();
        }
    }
}
