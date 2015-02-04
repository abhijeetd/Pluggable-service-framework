using PluggableService.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluggableService.Sample
{
    public class SampleContextProvider : IContextProvider
    {
        public ServiceContext GetServiceContext()
        {
            var registeredPlugins = new List<Plugin>();
            registeredPlugins.Add(new Plugin { Classname = "PluggableService.Sample.SamplePlugin, PluggableService.Sample" });

            return new SampleServiceContext { SampleProperty = "test data", Plugins = registeredPlugins };
        }
    }
}
