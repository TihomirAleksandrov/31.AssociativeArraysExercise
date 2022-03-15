using System;
using System.Linq;
using System.Collections.Generic;

namespace StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> students = new Dictionary<string, double>();
            
            int inputNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputNum; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (students.ContainsKey(name))
                {
                    students[name] = (grade + students[name]) / 2;
                }
                else
                {
                    students.Add(name, grade);
                }
            }

            Dictionary<string, double> goodStudents = students
                .Where(x => x.Value >= 4.5)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var pair in goodStudents)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value:f2}");
            }
        }
    }
}
