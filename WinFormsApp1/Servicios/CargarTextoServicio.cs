using WinFormsApp1.DTO;
using WinFormsApp1.Fabricas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Servicios
{
    internal class CargarTextoServicio
    {
        public static TextoDTO CargarTexto(string textoPath)
        {
            Entidades.Texto texto = FabricaTexto.CrearTexto(textoPath);
            texto.LoadTexto();
            TextoDTO textoDTO = new TextoDTO();
            textoDTO.texto = texto.GetTexto();
            textoDTO.textoPath = textoPath;
            return textoDTO;
        }
    }
}
