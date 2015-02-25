using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluggableService.Framework
{
    public class Plugin
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Classname { get; set; }
        public string PluginType { get; set; }

        public List<Parameter> Parameters { get; set; }
        public List<Plugin> Plugins { get; set; }

        public void Clone(Plugin plugin)
        {
            this.Title = plugin.Title;
            this.Description = plugin.Description;
            this.Parameters = plugin.Parameters;
            this.Plugins = plugin.Plugins;
        }

        public virtual void InitializeParameters()
        {
            if (Parameters != null && Parameters.Count > 0)
            {
                Parameters.ForEach(p =>
                {
                    var property = this.GetType().GetProperty(p.Key);
                    if (property != null)
                    {
                        if (property.PropertyType.IsEnum)
                            property.SetValue(this, Enum.Parse(property.PropertyType, p.Value));
                        else
                            property.SetValue(this, Convert.ChangeType(p.Value, property.PropertyType), null);
                    }
                });
            }
        }

        public T GetPlugin<T>() where T : Plugin
        {
            if (Plugins == null)
            {
                return default(T);
            }
            return Plugins.Where(p => p.PluginType == typeof(T).FullName).SingleOrDefault() as T;
        }

        public List<T> GetPlugins<T>() where T : Plugin
        {
            if (Plugins == null)
            {
                return null;
            }
            return Plugins.Where(p => p.PluginType == typeof(T).FullName).Select(p => (T)p).ToList();
        }
    }
}
