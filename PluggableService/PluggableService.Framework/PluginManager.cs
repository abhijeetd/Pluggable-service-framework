using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluggableService.Framework
{
    public class PluginManager
    {
        private IDictionary<string, List<Plugin>> Plugins { get; set; }

        public List<T> GetPlugins<T>(string type) where T : Plugin
        {
            if (Plugins != null && Plugins.ContainsKey(type))
            {
                return Plugins[type].Select(p => (T)p).ToList();
            };
            return null;
        }
        public T GetPlugin<T>(string type) where T : Plugin
        {
            return GetPlugins<T>(type).SingleOrDefault();
        }

        public void LoadPlugins(List<Plugin> plugins)
        {
            Plugins = new Dictionary<string, List<Plugin>>();
            if (plugins != null && plugins.Count > 0)
            {
                var loadedPlugins = InstantiatePlugins(plugins);
                Plugins = loadedPlugins.GroupBy(p => p.PluginType).ToDictionary(p => p.Key, p => p.ToList());
            }
        }

        private IList<Plugin> InstantiatePlugins(List<Plugin> list)
        {
            IList<Plugin> loadedPlugins = new List<Plugin>();

            list.ForEach(p =>
            {
                var current = Activator.CreateInstance(Type.GetType(p.Classname)) as Plugin;
                if (current != null)
                {
                    current.Clone(p);
                    current.InitializeParameters();
                    if (current.Plugins != null && current.Plugins.Count > 0)
                    {
                        current.Plugins = InstantiatePlugins(current.Plugins).ToList();
                    }
                    loadedPlugins.Add(current);
                }
            });

            return loadedPlugins;
        }
    }
}
