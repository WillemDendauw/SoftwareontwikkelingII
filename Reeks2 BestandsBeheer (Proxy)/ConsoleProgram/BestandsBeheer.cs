using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProxyModel;
using ProxyModel.Pattern;

namespace ConsoleProgram
{
    public class BestandsBeheer
    {
        static void Main(string[] args)
        {
            //testusers toevoegen
            Dictionary<string, User> users = new Dictionary<string, User>();
            users.Add("gast", new User("gast"));
            users.Add("admin", new User("admin", true));

            //Simple user login
            Console.Out.WriteLine("Enter username:");
            string tempuser = Console.ReadLine();
            while (!users.ContainsKey(tempuser))
            {
                PrintError("User not found, enter valid username: ");
                tempuser = Console.ReadLine();
            }
            Console.Out.WriteLine();

            //open files
            Console.Out.WriteLine("Enter file name or STOP to exit");
            string filename = Console.ReadLine();
            while(filename != "STOP")
            {
                try
                {
                    string fileContent = new AuthenticationProxyFile(users[tempuser], filename).Content;
                    Console.Out.WriteLine();
                    Console.WriteLine("===== " + filename + " =====");
                    Console.WriteLine(fileContent);
                    Console.WriteLine("========================");
                }
                catch(Exception e)
                {
                    PrintError(e.Message);
                }
                Console.Out.WriteLine();
                Console.Out.WriteLine("Enter filename or STOP to exit");
                filename = Console.ReadLine();
            }
        }

        static void PrintError(string errorMessage)
        {
            Console.Out.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Out.Write("[ERR] ");
            Console.ResetColor();
            Console.Out.WriteLine(errorMessage);
        }
    }
}
