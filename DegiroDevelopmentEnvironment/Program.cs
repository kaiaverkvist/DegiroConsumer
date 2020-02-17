using System;
using System.Net;
using DegiroConsumer;

namespace DegiroDevelopmentEnvironment
{
    class Program
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Necessary")]
        static void Main(string[] args)
        {
            Console.WriteLine("Username:");
            var username = Console.ReadLine();

            Console.WriteLine("Password:");
            var password = Console.ReadLine();

            // Initialize client with username and password we just fetched.
            DegiroClient Client = new DegiroClient(username, password);

            if (Client.Login())
            {
                Console.WriteLine("Successful login.");
            }

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine($"{Client.ClientInfo.Data.Username}, {Client.ClientInfo.Data.IntAccount}");
            Console.ReadLine();
        }
    }
}
