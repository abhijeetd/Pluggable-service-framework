using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluggableService.Framework
{
    public abstract class BaseService : IService
    {
        private bool IsInitialized { get; set; }
        protected PluginManager PluginService { get; set; }
        public void Execute(IContextProvider contextProvider)
        {
            var context = contextProvider.GetServiceContext();
            if (context != null)
            {
                if (PluginService == null)
                {
                    PluginService = new PluginManager();
                }

                PluginService.LoadPlugins(context.Plugins);
                IsInitialized = true;
                Run(context);
            }
        }

        protected abstract void Run(ServiceContext context);
    }
}
