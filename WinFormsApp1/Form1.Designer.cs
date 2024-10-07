namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblCargarComponente = new Label();
            btnCargarArchivo1 = new Button();
            lblComponentesCargados = new Label();
            lstComponentesCargados = new ListBox();
            lblArchivoInicial = new Label();
            txtArchivoInicial = new TextBox();
            btnCargarArchivo2 = new Button();
            lblArchivoProcesado = new Label();
            txtArchivoProcesado = new TextBox();
            btnEjecutarComponente = new Button();
            txtSalidaMensajes = new TextBox();
            SuspendLayout();
            // 
            // lblCargarComponente
            // 
            lblCargarComponente.Location = new Point(20, 20);
            lblCargarComponente.Name = "lblCargarComponente";
            lblCargarComponente.Size = new Size(150, 20);
            lblCargarComponente.TabIndex = 0;
            lblCargarComponente.Text = "Cargar componente";
            // 
            // btnCargarArchivo1
            // 
            btnCargarArchivo1.Location = new Point(20, 45);
            btnCargarArchivo1.Name = "btnCargarArchivo1";
            btnCargarArchivo1.Size = new Size(100, 25);
            btnCargarArchivo1.TabIndex = 1;
            btnCargarArchivo1.Text = "Cargar Archivo";
            btnCargarArchivo1.Click += btnCargarArchivo1_Click;
            // 
            // lblComponentesCargados
            // 
            lblComponentesCargados.Location = new Point(20, 80);
            lblComponentesCargados.Name = "lblComponentesCargados";
            lblComponentesCargados.Size = new Size(150, 20);
            lblComponentesCargados.TabIndex = 2;
            lblComponentesCargados.Text = "Componentes cargados";
            // 
            // lstComponentesCargados
            // 
            lstComponentesCargados.ItemHeight = 15;
            lstComponentesCargados.Location = new Point(20, 105);
            lstComponentesCargados.Name = "lstComponentesCargados";
            lstComponentesCargados.Size = new Size(194, 139);
            lstComponentesCargados.TabIndex = 3;
            // 
            // lblArchivoInicial
            // 
            lblArchivoInicial.Location = new Point(233, 20);
            lblArchivoInicial.Name = "lblArchivoInicial";
            lblArchivoInicial.Size = new Size(100, 20);
            lblArchivoInicial.TabIndex = 4;
            lblArchivoInicial.Text = "Archivo Inicial";
            // 
            // txtArchivoInicial
            // 
            txtArchivoInicial.Location = new Point(233, 45);
            txtArchivoInicial.Multiline = true;
            txtArchivoInicial.Name = "txtArchivoInicial";
            txtArchivoInicial.Size = new Size(437, 122);
            txtArchivoInicial.TabIndex = 5;
            // 
            // btnCargarArchivo2
            // 
            btnCargarArchivo2.Location = new Point(676, 45);
            btnCargarArchivo2.Name = "btnCargarArchivo2";
            btnCargarArchivo2.Size = new Size(100, 25);
            btnCargarArchivo2.TabIndex = 6;
            btnCargarArchivo2.Text = "Cargar Archivo";
            btnCargarArchivo2.Click += btnCargarArchivo2_Click;
            // 
            // lblArchivoProcesado
            // 
            lblArchivoProcesado.Location = new Point(233, 170);
            lblArchivoProcesado.Name = "lblArchivoProcesado";
            lblArchivoProcesado.Size = new Size(150, 20);
            lblArchivoProcesado.TabIndex = 7;
            lblArchivoProcesado.Text = "Archivo procesado";
            // 
            // txtArchivoProcesado
            // 
            txtArchivoProcesado.Location = new Point(233, 195);
            txtArchivoProcesado.Multiline = true;
            txtArchivoProcesado.Name = "txtArchivoProcesado";
            txtArchivoProcesado.Size = new Size(543, 193);
            txtArchivoProcesado.TabIndex = 8;
            // 
            // btnEjecutarComponente
            // 
            btnEjecutarComponente.Location = new Point(20, 279);
            btnEjecutarComponente.Name = "btnEjecutarComponente";
            btnEjecutarComponente.Size = new Size(150, 25);
            btnEjecutarComponente.TabIndex = 9;
            btnEjecutarComponente.Text = "Ejecutar componente";
            btnEjecutarComponente.Click += btnEjecutarComponente_Click;
            // 
            // txtSalidaMensajes
            // 
            txtSalidaMensajes.Location = new Point(20, 394);
            txtSalidaMensajes.Name = "txtSalidaMensajes";
            txtSalidaMensajes.Size = new Size(756, 23);
            txtSalidaMensajes.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblCargarComponente);
            Controls.Add(btnCargarArchivo1);
            Controls.Add(lblComponentesCargados);
            Controls.Add(lstComponentesCargados);
            Controls.Add(lblArchivoInicial);
            Controls.Add(txtArchivoInicial);
            Controls.Add(btnCargarArchivo2);
            Controls.Add(lblArchivoProcesado);
            Controls.Add(txtArchivoProcesado);
            Controls.Add(btnEjecutarComponente);
            Controls.Add(txtSalidaMensajes);
            Name = "Form1";
            Text = "Editor de Texto - Unillanos V1.0";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCargarComponente;
        private Button btnCargarArchivo1;
        private Label lblComponentesCargados;
        private ListBox lstComponentesCargados;
        private Label lblArchivoInicial;
        private TextBox txtArchivoInicial;
        private Button btnCargarArchivo2;
        private Label lblArchivoProcesado;
        private TextBox txtArchivoProcesado;
        private Button btnEjecutarComponente;
        private TextBox txtSalidaMensajes;
    }
}
