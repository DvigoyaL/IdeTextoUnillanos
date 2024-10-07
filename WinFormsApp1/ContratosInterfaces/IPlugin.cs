using WinFormsApp1.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.ContratosInterfaces
{
    public interface IPlugin
    {
        string GetPluginName();
        TextoDTO Execute(TextoDTO textoDTO);
    }
}
