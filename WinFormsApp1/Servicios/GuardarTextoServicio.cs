using WinFormsApp1.DTO;
using WinFormsApp1.Entidades;
using WinFormsApp1.Fabricas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Servicios
{
    internal class GuardarTextoServicio
    {
        public static void GuardarTexto(TextoDTO textoDTO)
        {
            Texto texto = FabricaTexto.CrearTexto(textoDTO.textoPath);
            texto.SetTexto(textoDTO.texto);
            texto.WriteTexto();
        }
    }
}
