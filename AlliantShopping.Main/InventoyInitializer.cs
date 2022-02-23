using AlliantShopping.Business.Interface;
using AlliantShopping.Business.Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AlliantShopping.Main
{
    public class InventoyInitializer
    {
        public static ProductStoreManager LoadInventory()
        {
            string fileName = "productstore.json";
            string jsonString = File.ReadAllText(fileName);
            return new ProductStoreManager(jsonString);
        }

        public static TerminalManager LoadTerminal(IProductStoreManager ProductStoreManager)
        {
            return new TerminalManager(ProductStoreManager);
        }
    }
}
