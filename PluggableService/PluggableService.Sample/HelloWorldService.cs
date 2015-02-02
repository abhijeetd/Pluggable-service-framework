using PluggableService.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluggableService.Sample
{
    public class HelloWorldService : BaseService
    {
        protected override ServiceContext OnInitialize()
        {
            // Register plugins - you can read it from XML file, or database or any external source and instantiate them

            var registeredPlugins = new List<Plugin>();
            registeredPlugins.Add(new Plugin { Classname = "PluggableService.Sample.SamplePlugin, PluggableService.Sample" });

            return new SampleServiceContext { SampleProperty = "test data", Plugins = registeredPlugins };
        }

        protected override void Run(ServiceContext context)
        {
            var plugin = PluginService.GetPlugin<SamplePlugin>("SampleType");

            Debug.WriteLine("Instance type: {0}", plugin.GetType());
        }
    }
}
