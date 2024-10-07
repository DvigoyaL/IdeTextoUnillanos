using WinFormsApp1.DTO;
using WinFormsApp1.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.ContratosInterfaces;

namespace WinFormsApp1.Controladores
{
    internal class PluginsControlador
    {
        private TextoDTO _textoProcesado;
        private List<IPlugin> _plugins = new List<IPlugin>(); 

        public PluginsControlador() { }
        public void AddPlugin(string pluginDirection)
        {
            PluginLoader pluginLoader = new PluginLoader();
            _plugins.Add(pluginLoader.LoadPlugin(pluginDirection));
        }
        public List<IPlugin> GetPlugins()
        {
            return _plugins;
        }
        public void SaveTextoProcesado(TextoDTO textoProcesado)
        {
            _textoProcesado = textoProcesado;
            GuardarTextoServicio.GuardarTexto(textoProcesado);
        }
        public TextoDTO GetTextoProcesado()
        {
            return _textoProcesado;
        }
    }
}
