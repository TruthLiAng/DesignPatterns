using StrategyPattern.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Bussiness
{
    public class GoodPhone : Phone, IObject
    {
        public void call()
        {
            Console.WriteLine("I'm goodPhone, can call");
        }

        public void internet()
        {
            Console.WriteLine("I'm goodPhone, can internet");

        }

        public void message()
        {
            Console.WriteLine("I'm goodPhone, can message");

        }
    }
}
