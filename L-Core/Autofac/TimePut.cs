using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0_Core.Autofac
{
    public class TimePut : ITimePut
    {
        public IOutput Iput;

        public TimePut(IOutput output)
        {
            this.Iput = output;
        }
        public void TimeOutPut()
        {
            string dateStr = DateTime.Now.ToString();
            Iput.Write(dateStr);
        }
    }
}
