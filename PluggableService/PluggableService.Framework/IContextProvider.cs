using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluggableService.Framework
{
    public interface IContextProvider
    {
        ServiceContext GetServiceContext();
    }
}
