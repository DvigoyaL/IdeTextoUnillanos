using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.ContratosInterfaces
{
    internal class PluginLoader
    {
        public IPlugin LoadPlugin(string pluginPath)
        {
            var assembly = Assembly.LoadFrom(pluginPath);
            var pluginType = assembly.GetTypes().FirstOrDefault(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface);
            if (pluginType != null)
            {
                // Crear una instancia del plugin
                var pluginInstance = (IPlugin)Activator.CreateInstance(pluginType);

                // Ejecutar el plugin
                return pluginInstance;
            }
            else
            {
                return null;
            }
        }
    }
}
