using WinFormsApp1.ContratosInterfaces;
using WinFormsApp1.Controladores;
using WinFormsApp1.DTO;

namespace WinFormsApp1
{
    public partial class Form1 : Form, IVistas
    {
        // Crear una instancia del controlador IdeControlador
        IdeControlador ideControlador = new IdeControlador();
        // Crear una instancia del PluginsControlador
        PluginsControlador pluginsControlador = new PluginsControlador();

        public Form1()
        {
            InitializeComponent();
        }

        public void CargarArchivoInicial()
        {
            // Crear y configurar el OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt";  // Filtro para mostrar solo archivos .txt
            openFileDialog.Title = "Seleccione un archivo de texto";

            // Mostrar el diálogo y verificar si el usuario seleccionó un archivo
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtener la ruta del archivo seleccionado
                string rutaArchivo = openFileDialog.FileName;

                // Pasar la ruta del archivo a la función LoadTextoInicial del controlador
                ideControlador.LoadTextoinicial(rutaArchivo);
            }
        }

        public void CargarPlugin()
        {
            try
            {
                // Crear y configurar el OpenFileDialog para seleccionar archivos DLL
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Archivos DLL (*.dll)|*.dll";  // Filtro para mostrar solo archivos .dll
                openFileDialog.Title = "Seleccione un archivo de plugin (.dll)";

                // Mostrar el diálogo y verificar si el usuario seleccionó un archivo
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtener la ruta del archivo DLL seleccionado
                    string pluginPath = openFileDialog.FileName;

                    // Llamar al método AddPlugin del PluginsControlador para agregar el plugin
                    pluginsControlador.AddPlugin(pluginPath);

                    // Mostrar los plugins cargados en la interfaz
                    MostrarPlugins();
                }

            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error en caso de fallo
                MostrarError($"Error al cargar el plugin: {ex.Message}");
            }
        }

        public void EjecutarPlugin(int indice)
        {
            try
            {               
                // Obtener la lista de plugins
                List<IPlugin> plugins = pluginsControlador.GetPlugins();

                // Verificar que el índice sea válido
                if (indice >= 0 && indice < plugins.Count)
                {
                    // Ejecutar el plugin correspondiente
                    pluginsControlador.SaveTextoProcesado(plugins[indice].Execute(ideControlador.GetTextoInicial()));
                }
                else
                {
                    // Si el índice no es válido, mostrar un error
                    MostrarError("Índice de plugin no válido.");
                }
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error en caso de fallo
                MostrarError($"Error al ejecutar el plugin: {ex.Message}");
            }
        }

        public void MostrarArchivoInicial()
        {
            try
            {
                // Obtener el texto inicial cargado desde el IdeControlador
                TextoDTO textoInicial = ideControlador.GetTextoInicial();

                // Verificar que el texto no sea nulo
                if (textoInicial != null && !string.IsNullOrWhiteSpace(textoInicial.texto))
                {
                    // Mostrar el texto inicial en el componente de interfaz (ej. un TextBox)
                    txtArchivoInicial.Text = textoInicial.texto;
                }
                else
                {
                    // Si no hay texto, mostrar un error
                    MostrarError("No se pudo cargar el archivo inicial o está vacío.");
                }
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error en caso de fallo
                MostrarError($"Error al mostrar el archivo inicial: {ex.Message}");
            }
        }

        public void MostrarError(string msg)
        {
            // Verificar si el control txtSalidaMensajes no es nulo
            if (txtSalidaMensajes != null)
            {
                // Mostrar el mensaje de error en el TextBox txtSalidaMensajes
                txtSalidaMensajes.Text = $"Error: {msg}";
            }
            else
            {
                // Como respaldo, si txtSalidaMensajes es nulo, usar MessageBox
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void MostrarPlugins()
        {
            try
            {
                // Obtener la lista de plugins
                List<IPlugin> plugins = pluginsControlador.GetPlugins();

                // Limpiar la lista de la interfaz antes de mostrar los plugins
                lstComponentesCargados.Items.Clear();

                // Mostrar cada plugin en la interfaz y construir el mensaje de información
                foreach (var plugin in plugins)
                {
                    string pluginName = plugin.GetPluginName(); // Asumiendo que IPlugin tiene un método GetPluginName
                    lstComponentesCargados.Items.Add(pluginName);

                }

            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error en caso de fallo
                MostrarError($"Error al mostrar los plugins: {ex.Message}");
            }
        }


        private void btnCargarArchivo2_Click(object sender, EventArgs e)
        {
            CargarArchivoInicial();
            MostrarArchivoInicial();
            txtSalidaMensajes.Clear();
        }

        private void btnCargarArchivo1_Click(object sender, EventArgs e)
        {
            CargarPlugin();
            txtSalidaMensajes.Clear();

        }

        public void MostrarTextoProcesado(TextoDTO textoDTO)
        {
            try
            {
                // Verificar que el objeto textoDTO no sea nulo
                if (textoDTO != null && !string.IsNullOrWhiteSpace(textoDTO.texto))
                {
                    // Mostrar el texto procesado en el TextBox txtArchivoProcesado
                    txtArchivoProcesado.Text = textoDTO.texto;
                }
                else
                {
                    // Si el objeto es nulo o el texto está vacío, mostrar un mensaje de error
                    MostrarError("El texto procesado está vacío o es nulo.");
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción y mostrar un mensaje de error
                MostrarError($"Error al mostrar el texto procesado: {ex.Message}");
            }
        }

        private void btnEjecutarComponente_Click(object sender, EventArgs e)
        {
            // Obtener el índice del elemento seleccionado en el ListBox
            int indiceSeleccionado = lstComponentesCargados.SelectedIndex;

            // Verificar si se seleccionó algún elemento (el índice será -1 si no hay selección)
            if (indiceSeleccionado != -1)
            {
                // Llamar a EjecutarPlugin con el índice seleccionado
                EjecutarPlugin(indiceSeleccionado);
                MostrarTextoProcesado(pluginsControlador.GetTextoProcesado());
                txtSalidaMensajes.Clear();
            }
            else
            {
                // Si no se seleccionó nada, mostrar un mensaje de error
                MostrarError("Debe seleccionar un componente para ejecutar.");
            }
        }
    }
}
