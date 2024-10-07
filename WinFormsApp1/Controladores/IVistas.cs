using WinFormsApp1.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Controladores
{
    internal interface IVistas
    {
        void CargarArchivoInicial();
        void MostrarArchivoInicial();
        void MostrarPlugins();
        void CargarPlugin();
        void EjecutarPlugin(int indice);
        void MostrarTextoProcesado(TextoDTO textoDTO);
        void MostrarError(string msg);

    }
}
