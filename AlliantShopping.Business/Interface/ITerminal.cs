using AlliantShopping.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlliantShopping.Business.Interface
{
    public interface ITerminal
    {
        void Scan(string item);
        decimal Total();

        Cart GetCurrentCart();
    }
}
