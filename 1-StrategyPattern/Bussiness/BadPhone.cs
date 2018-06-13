using StrategyPattern.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Bussiness
{
    public class BadPhone : Phone, IObject
    {
        public void call()
        {
            Console.WriteLine("I'm badPhone, can't call");
        }

        public void internet()
        {
            Console.WriteLine("I'm badPhone, can't internet");

        }

        public void message()
        {
            Console.WriteLine("I'm badPhone, can't message");
        }
    }
}
