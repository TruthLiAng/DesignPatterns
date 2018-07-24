using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0_Core.Autofac
{
    public class Output : IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
            Console.ReadKey();
        }
    }
}
