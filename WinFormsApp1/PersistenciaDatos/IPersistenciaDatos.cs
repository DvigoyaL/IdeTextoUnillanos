using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.PersistenciaDatos
{
    internal interface IPersistenciaDatos
    {
        (string, string) ReadFile(String fileName);
        string WriteFile(String fileName, String fileContent);
    }
}
