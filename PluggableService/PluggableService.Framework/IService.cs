﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluggableService.Framework
{
    public interface IService
    {
        void Execute(IContextProvider contextProvider);
    }
}
