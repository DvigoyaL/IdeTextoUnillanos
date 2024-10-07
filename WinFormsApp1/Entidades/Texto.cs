using WinFormsApp1.Fabricas;
using WinFormsApp1.PersistenciaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Entidades
{
    internal class Texto
    {
        private string _texto;
        private string _textoPath;
        private IPersistenciaDatos _persistenciaDatos;
        public string error = null;
        public Texto(string textoPath) {
            _textoPath = textoPath;
            _persistenciaDatos = FabricaIPersistenciaDatos.CreatePersistenciaDatos();
        }
        public void LoadTexto()
        {
            (_texto, error) = _persistenciaDatos.ReadFile(_textoPath);
        }
        public void WriteTexto() 
        {
            error = _persistenciaDatos.WriteFile(_textoPath, _texto);
        }
        public void SetTexto(string texto)
        {
            _texto = texto;
        }
        public string GetTexto()
        {
            return _texto;
        }
        public string GettextoPath()
        {
            return _textoPath;
        }

        public void SettextoPath(string textoPath)
        {
            _textoPath = textoPath;
        }
    }
}
