# Pluggable service framework

A simple framework to get started with building extensible application that is based on pluggable architecture.


* See [PluggableService.Sample](https://github.com/abhijeetd/Pluggable-service-framework/tree/master/PluggableService/PluggableService.Sample) for sample implementation
* See [PluggableService.Container.Console](https://github.com/abhijeetd/Pluggable-service-framework/tree/master/PluggableService/PluggableService.Container.Console) for sample of how to host/invoke this pluggable service 

A real world implementation of this can be found at **[DONE criteria evaluation tool](https://github.com/abhijeetd/Agile-done-criteria-evaluator)**
### Getting started

There are mainly 4 main components:
* **ServiceContext** - service specific service context 
* **ServiceContextProvider** - Context provider that returns an instance of service specific ServiceContext
* **Service** - Actual service that implements specific functionality
* **Plugin** - One or more plugins that can be injected into the service for specific processing 
 


Create service specific ServiceContext extending *ServiceContext* class

```
      public class SampleServiceContext : ServiceContext
      {
            public string SampleProperty { get; set; }
      }
```   

Create context provider by implementing *IContextProvider* interface

```
      public class SampleContextProvider : IContextProvider
      {
            public ServiceContext GetServiceContext()
            {
                  var registeredPlugins = new List<Plugin>();
                  registeredPlugins.Add(new Plugin { 
                  Classname = "PluggableService.Sample.SamplePlugin, PluggableService.Sample" 
                  });

                  return new SampleServiceContext 
                        { 
                              SampleProperty = "test data", 
                              Plugins = registeredPlugins 
                        };
            }
    }
```   


Create your service class by extending *BaseService* class

```
      public class HelloWorldService : BaseService
      {
            protected override void Run(ServiceContext context)
            {
                  var plugin = PluginService.GetPlugin<SamplePlugin>("SampleType");

                  Console.WriteLine("Instance type: {0}", plugin.GetType());
            }
      }
```

Create custom plugin by extending *Plugin* class

```
      public class SamplePlugin : Plugin
      {
            public SamplePlugin()
            {
                  Title = "Sample plugin";
                  PluginType = "SampleType";
            }
      }
```   
 


