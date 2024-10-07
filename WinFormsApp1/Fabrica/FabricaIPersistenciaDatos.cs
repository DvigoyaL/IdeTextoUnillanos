using WinFormsApp1.PersistenciaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Fabricas
{
    internal class FabricaIPersistenciaDatos
    { 
        static public IPersistenciaDatos CreatePersistenciaDatos()
        {
            return new PersistenciaArchivosTexto();
        } 
    }
}
