using System.Text.RegularExpressions;
using WinFormsApp1.ContratosInterfaces;
using WinFormsApp1.DTO;

public class ContadorPalabras : IPlugin
{
    // Implementación del método para devolver el nombre del plugin
    public string GetPluginName()
    {
        return "Contador de Palabras";
    }

    // Implementación del método Execute para contar palabras y devolver un TextoDTO con el resultado
    public TextoDTO Execute(TextoDTO textoDTO)
    {
        // Verificar si el texto no es nulo ni vacío
        if (textoDTO == null || string.IsNullOrWhiteSpace(textoDTO.texto))
        {
            return new TextoDTO { texto = "El texto proporcionado está vacío." };
        }

        // Declarar las palabras reservadas de C, C#, Java y SQL
        var palabrasReservadas = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        "if", "else", "int", "float", "double", "char", "class", "public", "private", "protected", "void",
        "main", "for", "while", "do", "switch", "case", "default", "return", "break", "continue", "null",
        "true", "false", "boolean", "string", "new", "try", "catch", "finally", "throws", "throw", "import",
        "package", "namespace", "static", "this", "super", "extends", "implements", "interface", "abstract",
        "final", "const", "goto", "enum", "struct", "union", "volatile", "synchronized", "transient", "instanceof",
        "assert", "SQLException", "ResultSet", "Connection", "Statement", "PreparedStatement", "commit", "rollback",
        "insert", "update", "delete", "select", "from", "where", "join", "on", "group", "by", "order", "having",
        "count", "sum", "avg", "min", "max"
    };

        // Usar una expresión regular para eliminar signos de puntuación que no sean puntos
        string textoSinPuntuacion = Regex.Replace(textoDTO.texto, @"[^\w\s\.]", "");

        // Separar las palabras por espacios, saltos de línea, tabulaciones, y puntos ('.')
        var palabrasUnicas = textoSinPuntuacion
            .Split(new[] { ' ', '\n', '\r', '\t', '.' }, StringSplitOptions.RemoveEmptyEntries) // Delimitar por espacio y punto
            .Select(p => p.ToLower()) // Convertir todas las palabras a minúsculas
            .Distinct()               // Eliminar palabras repetidas
            .Where(p => !palabrasReservadas.Contains(p)) // Excluir palabras reservadas
            .ToList();

        // Contar el número de palabras únicas que no sean reservadas
        int numeroPalabras = palabrasUnicas.Count;

        // Crear el texto de salida que indica cuántas palabras únicas hay
        string textoProcesado = $"El texto contiene {numeroPalabras} palabras únicas (excluyendo palabras reservadas).";

        // Retornar un nuevo TextoDTO con el texto procesado
        return new TextoDTO { texto = textoProcesado };
    }
}
