using System;
using Search_and_Archive;

namespace Task_15_v3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hello, please, enter the name of the file you want to archive:");
            Console.ResetColor();
            string findFile = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please, enter the path to the folder:");
            Console.ResetColor();
            Console.WriteLine("For example: \"D:\\Floder\\...\\\" ");

            string path = Console.ReadLine();    

            var program = new SearchAndArchive(findFile, path);
        }
    }
}