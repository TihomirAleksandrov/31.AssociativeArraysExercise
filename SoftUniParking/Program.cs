using System;
using System.Linq;
using System.Collections.Generic;

namespace SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();

            int inputNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputNum; i++)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();

                string command = input[0];
                string userName = input[1];

                if (command == "register")
                {
                    string licensePlate = input[2];

                    if (users.ContainsKey(userName))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {users[userName]}");
                        continue;
                    }
                    else
                    {
                        users.Add(userName, licensePlate);
                        Console.WriteLine($"{userName} registered {licensePlate} successfully");
                        continue;
                    }
                }
                else if (command == "unregister")
                {
                    if (users.ContainsKey(userName))
                    {
                        users.Remove(userName);
                        Console.WriteLine($"{userName} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }
                }
            }

            foreach (var pair in users)
            {
                Console.WriteLine($"{pair.Key} => {pair.Value}");
            }
        }
    }
}
