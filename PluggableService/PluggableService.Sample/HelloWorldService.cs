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
        protected override void Run(ServiceContext context)
        {
            var plugin = PluginService.GetPlugin<SamplePlugin>("SampleType");

            Console.WriteLine("Instance type: {0}", plugin.GetType());
        }
    }
}
