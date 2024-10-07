using WinFormsApp1.ContratosInterfaces;
using WinFormsApp1.DTO;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

public class BuscarTexto : IPlugin
{
    // Devuelve el nombre del plugin
    public string GetPluginName()
    {
        return "BuscarTexto";
    }

    // Ejecuta la lógica de búsqueda de texto en el TextoDTO proporcionado
    public TextoDTO Execute(TextoDTO textoDTO)
    {
        // Verificar si el texto no es nulo ni vacío
        if (textoDTO == null || string.IsNullOrWhiteSpace(textoDTO.texto))
        {
            return new TextoDTO { texto = "El texto proporcionado está vacío." };
        }

        // Solicitar la palabra a buscar al usuario mediante una ventana de entrada
        string palabraABuscar = InputBox("Buscar Palabra", "Ingrese la palabra a buscar:");

        // Verificar que la palabra a buscar no sea nula ni vacía
        if (string.IsNullOrWhiteSpace(palabraABuscar))
        {
            return new TextoDTO { texto = "No se especificó la palabra a buscar." };
        }

        // Convertir el texto y la palabra a buscar a minúsculas para hacer una búsqueda insensible a mayúsculas y minúsculas
        string texto = textoDTO.texto.ToLower();
        palabraABuscar = palabraABuscar.ToLower();

        // Usar una expresión regular para eliminar los signos de puntuación de las palabras
        string textoSinPuntuacion = Regex.Replace(texto, @"[^\w\s]", "");

        // Dividir el texto en líneas para analizar las filas
        var lineas = textoSinPuntuacion.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        // Listado para almacenar las ocurrencias
        List<string> ocurrencias = new List<string>();
        int totalOcurrencias = 0;

        // Analizar cada línea para encontrar la palabra
        for (int fila = 0; fila < lineas.Length; fila++)
        {
            string linea = lineas[fila];
            var palabras = linea.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            // Recorrer las palabras de la línea
            int columna = 0;
            for (int i = 0; i < palabras.Length; i++)
            {
                if (palabras[i] == palabraABuscar)
                {
                    // Calcular la posición (columna) real en el texto original
                    int posicionEnLinea = linea.IndexOf(palabraABuscar, columna);
                    ocurrencias.Add($"Fila {fila + 1}, Columna {posicionEnLinea + 1}{Environment.NewLine}");
                    totalOcurrencias++;
                }
                columna += palabras[i].Length + 1; // Avanzar columna considerando la palabra y el espacio
            }
        }

        // Crear el texto de salida con el número de ocurrencias y sus posiciones
        string textoProcesado = $"La palabra '{palabraABuscar}' aparece {totalOcurrencias} veces en el texto.{Environment.NewLine}";
        textoProcesado += string.Join("\n", ocurrencias);

        // Retornar un nuevo TextoDTO con el resultado
        return new TextoDTO { texto = textoProcesado };
    }

    // Función para crear una ventana emergente que pide al usuario ingresar un valor
    private string InputBox(string title, string promptText)
    {
        Form form = new Form();
        Label label = new Label();
        TextBox textBox = new TextBox();
        Button buttonOk = new Button();
        Button buttonCancel = new Button();

        form.Text = title;
        label.Text = promptText;
        textBox.Text = "";

        buttonOk.Text = "OK";
        buttonCancel.Text = "Cancel";
        buttonOk.DialogResult = DialogResult.OK;
        buttonCancel.DialogResult = DialogResult.Cancel;

        label.SetBounds(9, 20, 372, 13);
        textBox.SetBounds(12, 36, 372, 20);
        buttonOk.SetBounds(228, 72, 75, 23);
        buttonCancel.SetBounds(309, 72, 75, 23);

        label.AutoSize = true;
        textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
        buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

        form.ClientSize = new System.Drawing.Size(396, 107);
        form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
        form.ClientSize = new System.Drawing.Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
        form.FormBorderStyle = FormBorderStyle.FixedDialog;
        form.StartPosition = FormStartPosition.CenterScreen;
        form.MinimizeBox = false;
        form.MaximizeBox = false;
        form.AcceptButton = buttonOk;
        form.CancelButton = buttonCancel;

        DialogResult dialogResult = form.ShowDialog();
        return textBox.Text;
    }
}
