using StrategyPattern.Bussiness;
using System;

namespace _1_StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            BadPhone badPhone = new BadPhone();

            GoodPhone goodPhone = new GoodPhone();

            badPhone.call();
            badPhone.internet();
            badPhone.message();

            goodPhone.call();
            goodPhone.internet();
            goodPhone.message();

            Console.ReadKey();
        }
    }
}
