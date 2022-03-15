using System;
using System.Linq;
using System.Collections.Generic;

namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "buy")
            {
                string[] parts = input.Split().ToArray();
                string name = parts[0];
                double price = double.Parse(parts[1]); 
                int quantity = int.Parse(parts[2]);

                if (products.Keys.Contains(name))
                {
                    products[name].Quantity += quantity;
                    products[name].Price = price;
                }
                else
                {
                    products.Add(name, new Product(quantity, price));
                }
            }

            foreach (var pair in products)
            {
                double totalPrice = pair.Value.Quantity * pair.Value.Price;

                Console.WriteLine($"{pair.Key} -> {totalPrice:f2}");
            }
        }
    }

    public class Product
    {
        public Product(int quantity, double price)
        {
            Quantity = quantity;
            Price = price;
        }

        public int Quantity { get; set; }

        public double Price { get; set; }
    }
}
