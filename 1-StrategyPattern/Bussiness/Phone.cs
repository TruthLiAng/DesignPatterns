using StrategyPattern.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Bussiness
{
    public class Phone
    {
        public string name { get; set; }
        public float price { get; set; } 
        public IObject method { get; set; }

        public void SetMethod(IObject method)
        {
            this.method = method;
        }
    }
}
