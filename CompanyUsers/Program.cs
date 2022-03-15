using System;
using System.Linq;
using System.Collections.Generic;

namespace CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split(" -> ").ToArray();

                string companyName = info[0];
                string id = info[1];

                if (companies.ContainsKey(companyName))
                {
                    if (!companies[companyName].Contains(id))
                    {
                        companies[companyName].Add(id);
                    }
                }
                else
                {
                    companies.Add(companyName, new List<string>());
                    companies[companyName].Add(id);
                }
            }

            foreach (var pair in companies)
            {
                Console.WriteLine(pair.Key);

                foreach (var item in pair.Value)
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
