using AlliantShopping.Business.Interface;
using AlliantShopping.Business.Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlliantShopping.Main
{
    internal class Program
    {
        private static IProductStoreManager _productStoreManager;
        private static ITerminal _terminal;
        static void Main(string[] args)
        {
            LoadInventory();
            LoadTerminal();
            Console.WriteLine("Enter Product Codes");
            string s = Console.ReadLine().ToUpper().Trim();
            Console.WriteLine(s);
            List<string> productCodes = new List<string>(s
                .Where(c => !string.IsNullOrEmpty(c.ToString().Trim()))
                .Select(c => c.ToString()));
            foreach (var item in productCodes)
            {
                _terminal.Scan(item);
            }

            // Get Total
            var result = _terminal.Total();
            Console.WriteLine("$" + result.ToString("0.00"));
        }

        private static void LoadInventory()
        {
            _productStoreManager = InventoyInitializer.LoadInventory();
        }

        private static void LoadTerminal()
        {
            _terminal = InventoyInitializer.LoadTerminal(_productStoreManager);
        }
    }
}
