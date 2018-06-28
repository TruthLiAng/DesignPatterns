using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Core.Model
{
    public class ApiModel
    {
        public class Test : BaseApiParam
        {
            public string name { get; set; }
            public int age { get; set; }
        }
    }
}
