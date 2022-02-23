﻿using AlliantShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlliantShopping.Data
{
    /// <summary>
    /// Cart Object.
    /// Holds Products Added and the associated quantity
    /// Also displays total price to user
    /// </summary>
    public class Cart
    {
        public Dictionary<Product,int> ItemDict { get; set; }
        public decimal Total { get; set; }
    }
}