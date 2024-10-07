using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WinFormsApp1.ContratosInterfaces;
using WinFormsApp1.DTO;

namespace PluginListarPalabras
{
    public class ListarPalabrasPlugin : IPlugin
    {
        public string GetPluginName()
        {
            return "ListarPalabras";
        }

        public TextoDTO Execute(TextoDTO textoDTO)
        {
            // Verificar si el texto no es nulo ni vacío
            if (textoDTO == null || string.IsNullOrWhiteSpace(textoDTO.texto))
            {
                return new TextoDTO { texto = "El texto proporcionado está vacío." };
            }

            // Lista de palabras clave que no se deben listar (de C, C#, Java y SQL)
            var palabrasReservadas = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        // Palabras clave comunes de C, C#, Java, y SQL
        "if", "else", "int", "float", "double", "char", "class", "public", "private", "protected", "void",
        "main", "for", "while", "do", "switch", "case", "default", "return", "break", "continue", "null",
        "true", "false", "boolean", "string", "new", "try", "catch", "finally", "throws", "throw", "import",
        "package", "namespace", "static", "this", "super", "extends", "implements", "interface", "abstract",
        "final", "const", "goto", "enum", "struct", "union", "volatile", "synchronized", "transient", "instanceof",
        "assert", "catch", "finally", "throw", "throws", "SQLException", "ResultSet", "Connection", "Statement",
        "PreparedStatement", "commit", "rollback", "insert", "update", "delete", "select", "from", "where", "join",
        "on", "group", "by", "order", "having", "count", "sum", "avg", "min", "max"
    };

            // Usar una expresión regular para eliminar los signos de puntuación excepto los puntos
            string textoSinPuntuacion = Regex.Replace(textoDTO.texto, @"[^\w\s\.]", "");

            // Separar las palabras por espacios, saltos de línea, tabulaciones y puntos ('.')
            var palabrasUnicas = textoSinPuntuacion
                .Split(new[] { ' ', '\n', '\r', '\t', '.' }, StringSplitOptions.RemoveEmptyEntries) // Delimitar por espacio y punto
                .Select(p => p.ToLower()) // Convertir todas las palabras a minúsculas
                .Distinct()               // Eliminar palabras duplicadas
                .Where(p => !palabrasReservadas.Contains(p)) // Filtrar las palabras clave reservadas
                .ToList();

            // Concatenar las palabras en un formato procesado (una palabra por línea)
            string textoProcesado = string.Join(Environment.NewLine, palabrasUnicas);

            // Retornar un nuevo TextoDTO con las palabras únicas procesadas
            return new TextoDTO { texto = textoProcesado };
        }
    }
}
