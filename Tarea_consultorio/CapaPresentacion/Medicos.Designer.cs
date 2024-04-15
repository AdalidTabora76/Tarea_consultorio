namespace Tarea_consultorio.CapaPresentacion
{
    partial class Medicos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtmedicos = new TextBox();
            label1 = new Label();
            btnagregar = new Button();
            btnborrar = new Button();
            btnactualizar = new Button();
            btnbuscar = new Button();
            txtnombres = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtapellido = new TextBox();
            dtpfecha = new DateTimePicker();
            label5 = new Label();
            chkestado = new CheckBox();
            SuspendLayout();
            // 
            // txtmedicos
            // 
            txtmedicos.Location = new Point(153, 38);
            txtmedicos.Name = "txtmedicos";
            txtmedicos.Size = new Size(100, 23);
            txtmedicos.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(66, 40);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 1;
            label1.Text = "Id medicos";
            // 
            // btnagregar
            // 
            btnagregar.Location = new Point(708, 356);
            btnagregar.Name = "btnagregar";
            btnagregar.Size = new Size(75, 23);
            btnagregar.TabIndex = 2;
            btnagregar.Text = "Agregar";
            btnagregar.UseVisualStyleBackColor = true;
            btnagregar.Click += btnagregar_Click;
            // 
            // btnborrar
            // 
            btnborrar.Location = new Point(799, 356);
            btnborrar.Name = "btnborrar";
            btnborrar.Size = new Size(75, 23);
            btnborrar.TabIndex = 3;
            btnborrar.Text = "Borrar";
            btnborrar.UseVisualStyleBackColor = true;
            // 
            // btnactualizar
            // 
            btnactualizar.Location = new Point(880, 356);
            btnactualizar.Name = "btnactualizar";
            btnactualizar.Size = new Size(75, 23);
            btnactualizar.TabIndex = 4;
            btnactualizar.Text = "Actualizar";
            btnactualizar.UseVisualStyleBackColor = true;
            // 
            // btnbuscar
            // 
            btnbuscar.Location = new Point(961, 356);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(75, 23);
            btnbuscar.TabIndex = 5;
            btnbuscar.Text = "buscar";
            btnbuscar.UseVisualStyleBackColor = true;
            // 
            // txtnombres
            // 
            txtnombres.Location = new Point(153, 82);
            txtnombres.Name = "txtnombres";
            txtnombres.Size = new Size(100, 23);
            txtnombres.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(66, 90);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 7;
            label2.Text = "Nombres";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(66, 142);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 8;
            label3.Text = "Apellido";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 194);
            label4.Name = "label4";
            label4.Size = new Size(97, 15);
            label4.TabIndex = 9;
            label4.Text = "Fecha De Ingreso";
            // 
            // txtapellido
            // 
            txtapellido.Location = new Point(153, 142);
            txtapellido.Name = "txtapellido";
            txtapellido.Size = new Size(100, 23);
            txtapellido.TabIndex = 10;
            // 
            // dtpfecha
            // 
            dtpfecha.Location = new Point(153, 194);
            dtpfecha.Name = "dtpfecha";
            dtpfecha.Size = new Size(200, 23);
            dtpfecha.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(34, 242);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 12;
            label5.Text = "estado";
            // 
            // chkestado
            // 
            chkestado.AutoSize = true;
            chkestado.Location = new Point(161, 241);
            chkestado.Name = "chkestado";
            chkestado.Size = new Size(60, 19);
            chkestado.TabIndex = 13;
            chkestado.Text = "Activo";
            chkestado.UseVisualStyleBackColor = true;
            // 
            // Medicos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1233, 616);
            Controls.Add(chkestado);
            Controls.Add(label5);
            Controls.Add(dtpfecha);
            Controls.Add(txtapellido);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtnombres);
            Controls.Add(btnbuscar);
            Controls.Add(btnactualizar);
            Controls.Add(btnborrar);
            Controls.Add(btnagregar);
            Controls.Add(label1);
            Controls.Add(txtmedicos);
            Name = "Medicos";
            Text = "Medicos";
            Load += Medicos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtmedicos;
        private Label label1;
        private Button btnagregar;
        private Button btnborrar;
        private Button btnactualizar;
        private Button btnbuscar;
        private TextBox txtnombres;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtapellido;
        private DateTimePicker dtpfecha;
        private Label label5;
        private CheckBox chkestado;
    }
}