using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.PersistenciaDatos
{
    internal class PersistenciaArchivosTexto : IPersistenciaDatos
    {
        public (string, string) ReadFile(string fileName)
        {
            try
            {
                string fileContent = File.ReadAllText(fileName);
                return (fileContent,null);
            }
            catch (FileNotFoundException)
            {
                return (null, "El archivo no fue encontrado en la ruta especificada.");
            }
            catch (UnauthorizedAccessException)
            {
                return (null, "No tienes permisos para acceder a este archivo.");
            }
            catch (Exception ex)
            {
                return (null, $"Ocurrió un error: {ex.Message}");
            }
        }

        public string WriteFile(string fileName, string fileContent)
        {
            try
            {
                File.WriteAllText(fileName, fileContent);
                return null;
            }
            catch (UnauthorizedAccessException)
            {
                return("No tienes permisos para crear o escribir en este archivo.");
            }
            catch (Exception ex)
            {
                return($"Ocurrió un error: {ex.Message}");
            }
        }
    }
}
