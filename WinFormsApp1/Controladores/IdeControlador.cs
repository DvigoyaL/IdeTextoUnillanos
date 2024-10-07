using WinFormsApp1.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Controladores
{
    internal class IdeControlador
    {
        private TextoDTO _textoInicial;
        public IdeControlador() { }
        public void LoadTextoinicial(string textoPath)
        {
            _textoInicial = Servicios.CargarTextoServicio.CargarTexto(textoPath);
        }
        public TextoDTO GetTextoInicial() { return _textoInicial; }

    }
}
