using PluggableService.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluggableService.Sample
{
    public class SamplePlugin : Plugin
    {
        public SamplePlugin()
        {
            Title = "Sample plugin";
            PluginType = "SampleType";
        }
    }
}
