# Pluggable service framework

A simple framework to get started with building extensible application that is based on pluggable architecture.

The code base also has a sample implementation.

### Getting started
1. Create your service class by extending *BaseService* class

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

2. Create custom plugin by extending *Plugin* class

    public class SamplePlugin : Plugin
    {
        public SamplePlugin()
        {
            Title = "Sample plugin";
            PluginType = "SampleType";
        }
    }
