using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Core.Model
{
    public class BaseApiParam
    {
        public long _timestamp { get; set; }
        public string appKey { get; set; }
        public string _sign { get; set; }
    }

    public class MessageReq
    {
        public int code { get; set; }
        public string msg { get; set; }
    }
}
