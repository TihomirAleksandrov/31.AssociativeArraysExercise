using System;
using System.Linq;
using System.Collections.Generic;

namespace LegendaryFarming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyResources = new Dictionary<string, int>();
            keyResources["shards"] = 0;
            keyResources["motes"] = 0;
            keyResources["fragments"] = 0;
            
            Dictionary<string, int> junkResources = new Dictionary<string, int>();
            string legendaryItem = string.Empty;

            while (true)
            {
                List<string> input = Console.ReadLine().Split().Select(x => x.ToLower()).ToList();

                keyResources = GetKeyPairs(input, keyResources);
                junkResources = GetJunkPairs(input, junkResources, keyResources);

                if (keyResources["shards"] >= 250)
                {
                    keyResources["shards"] -= 250;
                    legendaryItem = "Shadowmourne";
                    break;
                }
                else if (keyResources["fragments"] >= 250)
                {
                    keyResources["fragments"] -= 250;
                    legendaryItem = "Valanyr";
                    break;
                }
                else if (keyResources["motes"] >= 250)
                {
                    keyResources["motes"] -= 250;
                    legendaryItem = "Dragonwrath";
                    break;
                }
            }

            Console.WriteLine($"{legendaryItem} obtained!");
            foreach (var pair in keyResources)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
            foreach(var pair in junkResources)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

        }

        static Dictionary<string, int> GetKeyPairs(List<string> input, Dictionary<string, int> resources)
        {
            int value = 0;

            for (int i = 0; i < input.Count; i++)
            {
                if (i % 2 == 0)
                {
                    value = int.Parse(input[i]);
                }
                else
                {
                    if (input[i] == "motes" || input[i] == "shards" || input[i] == "fragments")
                    {

                        resources[input[i]] += value;
                        if (resources[input[i]] >= 250)
                        {
                            return resources;
                        }

                    }
                }
            }

            return resources;
        }

        static Dictionary<string, int> GetJunkPairs(List<string> input, Dictionary<string, int> resources, Dictionary<string, int> keyResources)
        {
            int value = 0;

            for (int i = 0; i < input.Count; i++)
            {
                if (i % 2 == 0)
                {
                    value = int.Parse(input[i]);
                }
                else
                {
                    if (input[i] != "motes" && input[i] != "shards" && input[i] != "fragments")
                    {
                        if (resources.Keys.Contains(input[i]))
                        {
                            resources[input[i]] += value;
                        }
                        else
                        {
                            resources.Add(input[i], value);
                        }
                    }
                    else
                    {
                        if (keyResources[input[i]] >= 250)
                        {
                            return resources;
                        }
                    }
                }
            }

            return resources;
        }
    }
}
