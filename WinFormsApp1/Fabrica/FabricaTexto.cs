using WinFormsApp1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Fabricas
{
    internal class FabricaTexto
    {
        public static Texto CrearTexto(string textoPath){
            return new Texto(textoPath);
        }
    }
}
