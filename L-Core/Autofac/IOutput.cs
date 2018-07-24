﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L0_Core.Autofac
{
    public interface IOutput: IDependency
    {
        void Write(string content);
    }
}
