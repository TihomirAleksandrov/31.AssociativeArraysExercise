using System;
using System.Linq;
using System.Collections.Generic;

namespace Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] info = input.Split(" : ").ToArray();
                string course = info[0];
                string student = info[1];

                if (courses.ContainsKey(course))
                {
                    courses[course].Add(student);
                }
                else
                {
                    courses.Add(course, new List<string>());
                    courses[course].Add(student);
                }
            }

            foreach (var pair in courses)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value.Count}");
                foreach (var item in pair.Value)
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
