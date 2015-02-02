using PluggableService.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluggableService.Container.Console
{
    class Program
    {
        /// <summary>
        /// Instantiates a service instance and initiates the execution
        /// </summary>
        /// <param name="args"> full classname of the service - to be executed.</param>
        /// <example> > PluggableService.Container.console "PluggableService.Sample.HelloWorldService, PluggableService.Sample"</example>
        static void Main(string[] args)
        {
            if (args == null || args.Length < 1)
            {
                System.Console.WriteLine("Please specify the fullname of the service to be executed");
                return;
            }
            IService service = Activator.CreateInstance(Type.GetType(args[0])) as IService;

            if (service == null)
            {
                System.Console.WriteLine("Invalid service name.");
                return;
            }
            service.Execute();
        }
    }
}
