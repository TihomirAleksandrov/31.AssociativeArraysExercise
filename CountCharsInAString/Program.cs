using System;
using System.Linq;
using System.Collections.Generic;

namespace CountCharsInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split()
                .ToList();

            Dictionary<char, int> characters = new Dictionary<char, int>();

            foreach (string word in input)
            {
                foreach(char c in word)
                {
                    if (characters.ContainsKey(c))
                    {
                        characters[c]++;
                    }
                    else
                    {
                        characters.Add(c, 1);
                    }
                }
            }

            foreach (var pair in characters)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
