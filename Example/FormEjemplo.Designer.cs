namespace FormDecoration
{
    partial class FormEjemplo
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Inferior = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Destroy = new System.Windows.Forms.Button();
            this.l_Version = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gb_Medidas = new System.Windows.Forms.GroupBox();
            this.btn_Actualizar = new System.Windows.Forms.Button();
            this.margin = new System.Windows.Forms.GroupBox();
            this.txt_Margin_Inferior = new System.Windows.Forms.TextBox();
            this.txt_Margin_Izquierdo = new System.Windows.Forms.TextBox();
            this.txt_Margin_Derecho = new System.Windows.Forms.TextBox();
            this.txt_Margin_Superior = new System.Windows.Forms.TextBox();
            this.padding = new System.Windows.Forms.GroupBox();
            this.txt_Padding_Inferior = new System.Windows.Forms.TextBox();
            this.txt_Padding_Izquierdo = new System.Windows.Forms.TextBox();
            this.txt_Padding_Derecho = new System.Windows.Forms.TextBox();
            this.txt_Padding_Superior = new System.Windows.Forms.TextBox();
            this.border = new System.Windows.Forms.GroupBox();
            this.txt_Border_Derecho = new System.Windows.Forms.TextBox();
            this.txt_Border_Izquierdo = new System.Windows.Forms.TextBox();
            this.txt_Border_Inferior = new System.Windows.Forms.TextBox();
            this.txt_Border_Superior = new System.Windows.Forms.TextBox();
            this.gb_Titulo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Titulo = new System.Windows.Forms.TextBox();
            this.gb_OpcionesContorno = new System.Windows.Forms.GroupBox();
            this.pb_ColorInfDer = new System.Windows.Forms.PictureBox();
            this.pb_ColorDer = new System.Windows.Forms.PictureBox();
            this.pb_ColorSupDer = new System.Windows.Forms.PictureBox();
            this.pb_ColorInf = new System.Windows.Forms.PictureBox();
            this.pb_ColorSup = new System.Windows.Forms.PictureBox();
            this.pb_ColorInfIzq = new System.Windows.Forms.PictureBox();
            this.pb_ColorIzq = new System.Windows.Forms.PictureBox();
            this.pb_ColorSupIzq = new System.Windows.Forms.PictureBox();
            this.btn_Superior = new System.Windows.Forms.Button();
            this.btn_Derecho = new System.Windows.Forms.Button();
            this.btn_Izquierdo = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.colorDialog_Outline = new System.Windows.Forms.ColorDialog();
            this.panel1.SuspendLayout();
            this.gb_Medidas.SuspendLayout();
            this.margin.SuspendLayout();
            this.padding.SuspendLayout();
            this.border.SuspendLayout();
            this.gb_Titulo.SuspendLayout();
            this.gb_OpcionesContorno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ColorInfDer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ColorDer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ColorSupDer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ColorInf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ColorSup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ColorInfIzq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ColorIzq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ColorSupIzq)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Inferior
            // 
            this.btn_Inferior.Location = new System.Drawing.Point(116, 166);
            this.btn_Inferior.Name = "btn_Inferior";
            this.btn_Inferior.Size = new System.Drawing.Size(102, 28);
            this.btn_Inferior.TabIndex = 3;
            this.btn_Inferior.Text = "Inferior";
            this.btn_Inferior.UseVisualStyleBackColor = true;
            this.btn_Inferior.Click += new System.EventHandler(this.Btn_Visible_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btn_Destroy);
            this.panel1.Controls.Add(this.l_Version);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.gb_Medidas);
            this.panel1.Controls.Add(this.gb_Titulo);
            this.panel1.Controls.Add(this.gb_OpcionesContorno);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(6, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 552);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(8, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(663, 12);
            this.panel3.TabIndex = 14;
            // 
            // btn_Destroy
            // 
            this.btn_Destroy.BackColor = System.Drawing.Color.DarkRed;
            this.btn_Destroy.Location = new System.Drawing.Point(565, 483);
            this.btn_Destroy.Name = "btn_Destroy";
            this.btn_Destroy.Size = new System.Drawing.Size(106, 58);
            this.btn_Destroy.TabIndex = 13;
            this.btn_Destroy.Tag = "1";
            this.btn_Destroy.Text = "Destruir OutlineForm";
            this.btn_Destroy.UseVisualStyleBackColor = false;
            this.btn_Destroy.Click += new System.EventHandler(this.Btn_Destroy_Click);
            // 
            // l_Version
            // 
            this.l_Version.AutoSize = true;
            this.l_Version.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Version.Location = new System.Drawing.Point(555, 39);
            this.l_Version.Name = "l_Version";
            this.l_Version.Size = new System.Drawing.Size(116, 22);
            this.l_Version.TabIndex = 12;
            this.l_Version.Text = "Version 0.2.3";
            this.l_Version.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(371, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(304, 31);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ejemplo de OutlineForm";
            // 
            // gb_Medidas
            // 
            this.gb_Medidas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gb_Medidas.Controls.Add(this.btn_Actualizar);
            this.gb_Medidas.Controls.Add(this.margin);
            this.gb_Medidas.Controls.Add(this.padding);
            this.gb_Medidas.Controls.Add(this.border);
            this.gb_Medidas.Location = new System.Drawing.Point(5, 85);
            this.gb_Medidas.Name = "gb_Medidas";
            this.gb_Medidas.Size = new System.Drawing.Size(207, 431);
            this.gb_Medidas.TabIndex = 11;
            this.gb_Medidas.TabStop = false;
            this.gb_Medidas.Text = "Medidas de la ventana";
            // 
            // btn_Actualizar
            // 
            this.btn_Actualizar.Location = new System.Drawing.Point(51, 398);
            this.btn_Actualizar.Name = "btn_Actualizar";
            this.btn_Actualizar.Size = new System.Drawing.Size(95, 30);
            this.btn_Actualizar.TabIndex = 0;
            this.btn_Actualizar.Text = "Actualizar";
            this.btn_Actualizar.UseVisualStyleBackColor = true;
            this.btn_Actualizar.Click += new System.EventHandler(this.Btn_Actualizar_Click);
            // 
            // margin
            // 
            this.margin.Controls.Add(this.txt_Margin_Inferior);
            this.margin.Controls.Add(this.txt_Margin_Izquierdo);
            this.margin.Controls.Add(this.txt_Margin_Derecho);
            this.margin.Controls.Add(this.txt_Margin_Superior);
            this.margin.Location = new System.Drawing.Point(3, 273);
            this.margin.Name = "margin";
            this.margin.Size = new System.Drawing.Size(195, 119);
            this.margin.TabIndex = 2;
            this.margin.TabStop = false;
            this.margin.Text = "Margin";
            // 
            // txt_Margin_Inferior
            // 
            this.txt_Margin_Inferior.Location = new System.Drawing.Point(65, 87);
            this.txt_Margin_Inferior.Name = "txt_Margin_Inferior";
            this.txt_Margin_Inferior.Size = new System.Drawing.Size(53, 26);
            this.txt_Margin_Inferior.TabIndex = 3;
            // 
            // txt_Margin_Izquierdo
            // 
            this.txt_Margin_Izquierdo.Location = new System.Drawing.Point(15, 57);
            this.txt_Margin_Izquierdo.Name = "txt_Margin_Izquierdo";
            this.txt_Margin_Izquierdo.Size = new System.Drawing.Size(53, 26);
            this.txt_Margin_Izquierdo.TabIndex = 1;
            // 
            // txt_Margin_Derecho
            // 
            this.txt_Margin_Derecho.Location = new System.Drawing.Point(117, 57);
            this.txt_Margin_Derecho.Name = "txt_Margin_Derecho";
            this.txt_Margin_Derecho.Size = new System.Drawing.Size(53, 26);
            this.txt_Margin_Derecho.TabIndex = 2;
            // 
            // txt_Margin_Superior
            // 
            this.txt_Margin_Superior.Location = new System.Drawing.Point(65, 25);
            this.txt_Margin_Superior.Name = "txt_Margin_Superior";
            this.txt_Margin_Superior.Size = new System.Drawing.Size(53, 26);
            this.txt_Margin_Superior.TabIndex = 0;
            // 
            // padding
            // 
            this.padding.Controls.Add(this.txt_Padding_Inferior);
            this.padding.Controls.Add(this.txt_Padding_Izquierdo);
            this.padding.Controls.Add(this.txt_Padding_Derecho);
            this.padding.Controls.Add(this.txt_Padding_Superior);
            this.padding.Location = new System.Drawing.Point(3, 148);
            this.padding.Name = "padding";
            this.padding.Size = new System.Drawing.Size(195, 119);
            this.padding.TabIndex = 1;
            this.padding.TabStop = false;
            this.padding.Text = "Padding";
            // 
            // txt_Padding_Inferior
            // 
            this.txt_Padding_Inferior.Location = new System.Drawing.Point(65, 87);
            this.txt_Padding_Inferior.Name = "txt_Padding_Inferior";
            this.txt_Padding_Inferior.Size = new System.Drawing.Size(53, 26);
            this.txt_Padding_Inferior.TabIndex = 3;
            // 
            // txt_Padding_Izquierdo
            // 
            this.txt_Padding_Izquierdo.Location = new System.Drawing.Point(15, 57);
            this.txt_Padding_Izquierdo.Name = "txt_Padding_Izquierdo";
            this.txt_Padding_Izquierdo.Size = new System.Drawing.Size(53, 26);
            this.txt_Padding_Izquierdo.TabIndex = 1;
            // 
            // txt_Padding_Derecho
            // 
            this.txt_Padding_Derecho.Location = new System.Drawing.Point(117, 57);
            this.txt_Padding_Derecho.Name = "txt_Padding_Derecho";
            this.txt_Padding_Derecho.Size = new System.Drawing.Size(53, 26);
            this.txt_Padding_Derecho.TabIndex = 2;
            // 
            // txt_Padding_Superior
            // 
            this.txt_Padding_Superior.Location = new System.Drawing.Point(65, 25);
            this.txt_Padding_Superior.Name = "txt_Padding_Superior";
            this.txt_Padding_Superior.Size = new System.Drawing.Size(53, 26);
            this.txt_Padding_Superior.TabIndex = 0;
            // 
            // border
            // 
            this.border.Controls.Add(this.txt_Border_Derecho);
            this.border.Controls.Add(this.txt_Border_Izquierdo);
            this.border.Controls.Add(this.txt_Border_Inferior);
            this.border.Controls.Add(this.txt_Border_Superior);
            this.border.Location = new System.Drawing.Point(3, 23);
            this.border.Name = "border";
            this.border.Size = new System.Drawing.Size(195, 119);
            this.border.TabIndex = 0;
            this.border.TabStop = false;
            this.border.Text = "Border";
            // 
            // txt_Border_Derecho
            // 
            this.txt_Border_Derecho.Location = new System.Drawing.Point(117, 57);
            this.txt_Border_Derecho.Name = "txt_Border_Derecho";
            this.txt_Border_Derecho.Size = new System.Drawing.Size(53, 26);
            this.txt_Border_Derecho.TabIndex = 2;
            // 
            // txt_Border_Izquierdo
            // 
            this.txt_Border_Izquierdo.Location = new System.Drawing.Point(15, 57);
            this.txt_Border_Izquierdo.Name = "txt_Border_Izquierdo";
            this.txt_Border_Izquierdo.Size = new System.Drawing.Size(53, 26);
            this.txt_Border_Izquierdo.TabIndex = 1;
            // 
            // txt_Border_Inferior
            // 
            this.txt_Border_Inferior.Location = new System.Drawing.Point(65, 87);
            this.txt_Border_Inferior.Name = "txt_Border_Inferior";
            this.txt_Border_Inferior.Size = new System.Drawing.Size(53, 26);
            this.txt_Border_Inferior.TabIndex = 3;
            // 
            // txt_Border_Superior
            // 
            this.txt_Border_Superior.Location = new System.Drawing.Point(65, 25);
            this.txt_Border_Superior.Name = "txt_Border_Superior";
            this.txt_Border_Superior.Size = new System.Drawing.Size(53, 26);
            this.txt_Border_Superior.TabIndex = 0;
            // 
            // gb_Titulo
            // 
            this.gb_Titulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Titulo.Controls.Add(this.label1);
            this.gb_Titulo.Controls.Add(this.txt_Titulo);
            this.gb_Titulo.Location = new System.Drawing.Point(218, 85);
            this.gb_Titulo.Name = "gb_Titulo";
            this.gb_Titulo.Size = new System.Drawing.Size(328, 89);
            this.gb_Titulo.TabIndex = 10;
            this.gb_Titulo.TabStop = false;
            this.gb_Titulo.Text = "Opciones del Panel Superior";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre de la ventana";
            // 
            // txt_Titulo
            // 
            this.txt_Titulo.Location = new System.Drawing.Point(9, 48);
            this.txt_Titulo.Name = "txt_Titulo";
            this.txt_Titulo.Size = new System.Drawing.Size(313, 26);
            this.txt_Titulo.TabIndex = 0;
            this.txt_Titulo.Text = "Mi Ventana";
            this.txt_Titulo.TextChanged += new System.EventHandler(this.Txt_Titulo_TextChanged);
            // 
            // gb_OpcionesContorno
            // 
            this.gb_OpcionesContorno.Controls.Add(this.pb_ColorInfDer);
            this.gb_OpcionesContorno.Controls.Add(this.pb_ColorDer);
            this.gb_OpcionesContorno.Controls.Add(this.pb_ColorSupDer);
            this.gb_OpcionesContorno.Controls.Add(this.pb_ColorInf);
            this.gb_OpcionesContorno.Controls.Add(this.pb_ColorSup);
            this.gb_OpcionesContorno.Controls.Add(this.pb_ColorInfIzq);
            this.gb_OpcionesContorno.Controls.Add(this.pb_ColorIzq);
            this.gb_OpcionesContorno.Controls.Add(this.pb_ColorSupIzq);
            this.gb_OpcionesContorno.Controls.Add(this.btn_Superior);
            this.gb_OpcionesContorno.Controls.Add(this.btn_Inferior);
            this.gb_OpcionesContorno.Controls.Add(this.btn_Derecho);
            this.gb_OpcionesContorno.Controls.Add(this.btn_Izquierdo);
            this.gb_OpcionesContorno.Location = new System.Drawing.Point(218, 183);
            this.gb_OpcionesContorno.Name = "gb_OpcionesContorno";
            this.gb_OpcionesContorno.Size = new System.Drawing.Size(328, 203);
            this.gb_OpcionesContorno.TabIndex = 8;
            this.gb_OpcionesContorno.TabStop = false;
            this.gb_OpcionesContorno.Text = "Opciones del contorno";
            // 
            // pb_ColorInfDer
            // 
            this.pb_ColorInfDer.BackColor = System.Drawing.Color.Black;
            this.pb_ColorInfDer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_ColorInfDer.Location = new System.Drawing.Point(188, 130);
            this.pb_ColorInfDer.Name = "pb_ColorInfDer";
            this.pb_ColorInfDer.Size = new System.Drawing.Size(30, 30);
            this.pb_ColorInfDer.TabIndex = 4;
            this.pb_ColorInfDer.TabStop = false;
            this.pb_ColorInfDer.Tag = "InfDer";
            this.pb_ColorInfDer.Click += new System.EventHandler(this.Pb_Color_Click);
            // 
            // pb_ColorDer
            // 
            this.pb_ColorDer.BackColor = System.Drawing.Color.Black;
            this.pb_ColorDer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_ColorDer.Location = new System.Drawing.Point(188, 96);
            this.pb_ColorDer.Name = "pb_ColorDer";
            this.pb_ColorDer.Size = new System.Drawing.Size(30, 30);
            this.pb_ColorDer.TabIndex = 4;
            this.pb_ColorDer.TabStop = false;
            this.pb_ColorDer.Tag = "Der";
            this.pb_ColorDer.Click += new System.EventHandler(this.Pb_Color_Click);
            // 
            // pb_ColorSupDer
            // 
            this.pb_ColorSupDer.BackColor = System.Drawing.Color.Black;
            this.pb_ColorSupDer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_ColorSupDer.Location = new System.Drawing.Point(188, 60);
            this.pb_ColorSupDer.Name = "pb_ColorSupDer";
            this.pb_ColorSupDer.Size = new System.Drawing.Size(30, 30);
            this.pb_ColorSupDer.TabIndex = 4;
            this.pb_ColorSupDer.TabStop = false;
            this.pb_ColorSupDer.Tag = "SupDer";
            this.pb_ColorSupDer.Click += new System.EventHandler(this.Pb_Color_Click);
            // 
            // pb_ColorInf
            // 
            this.pb_ColorInf.BackColor = System.Drawing.Color.Black;
            this.pb_ColorInf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_ColorInf.Location = new System.Drawing.Point(152, 130);
            this.pb_ColorInf.Name = "pb_ColorInf";
            this.pb_ColorInf.Size = new System.Drawing.Size(30, 30);
            this.pb_ColorInf.TabIndex = 4;
            this.pb_ColorInf.TabStop = false;
            this.pb_ColorInf.Tag = "Inf";
            this.pb_ColorInf.Click += new System.EventHandler(this.Pb_Color_Click);
            // 
            // pb_ColorSup
            // 
            this.pb_ColorSup.BackColor = System.Drawing.Color.Black;
            this.pb_ColorSup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_ColorSup.Location = new System.Drawing.Point(152, 60);
            this.pb_ColorSup.Name = "pb_ColorSup";
            this.pb_ColorSup.Size = new System.Drawing.Size(30, 30);
            this.pb_ColorSup.TabIndex = 4;
            this.pb_ColorSup.TabStop = false;
            this.pb_ColorSup.Tag = "Sup";
            this.pb_ColorSup.Click += new System.EventHandler(this.Pb_Color_Click);
            // 
            // pb_ColorInfIzq
            // 
            this.pb_ColorInfIzq.BackColor = System.Drawing.Color.Black;
            this.pb_ColorInfIzq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_ColorInfIzq.Location = new System.Drawing.Point(116, 130);
            this.pb_ColorInfIzq.Name = "pb_ColorInfIzq";
            this.pb_ColorInfIzq.Size = new System.Drawing.Size(30, 30);
            this.pb_ColorInfIzq.TabIndex = 4;
            this.pb_ColorInfIzq.TabStop = false;
            this.pb_ColorInfIzq.Tag = "InfIzq";
            this.pb_ColorInfIzq.Click += new System.EventHandler(this.Pb_Color_Click);
            // 
            // pb_ColorIzq
            // 
            this.pb_ColorIzq.BackColor = System.Drawing.Color.Black;
            this.pb_ColorIzq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_ColorIzq.Location = new System.Drawing.Point(116, 96);
            this.pb_ColorIzq.Name = "pb_ColorIzq";
            this.pb_ColorIzq.Size = new System.Drawing.Size(30, 30);
            this.pb_ColorIzq.TabIndex = 4;
            this.pb_ColorIzq.TabStop = false;
            this.pb_ColorIzq.Tag = "Izq";
            this.pb_ColorIzq.Click += new System.EventHandler(this.Pb_Color_Click);
            // 
            // pb_ColorSupIzq
            // 
            this.pb_ColorSupIzq.BackColor = System.Drawing.Color.Black;
            this.pb_ColorSupIzq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_ColorSupIzq.Location = new System.Drawing.Point(116, 60);
            this.pb_ColorSupIzq.Name = "pb_ColorSupIzq";
            this.pb_ColorSupIzq.Size = new System.Drawing.Size(30, 30);
            this.pb_ColorSupIzq.TabIndex = 4;
            this.pb_ColorSupIzq.TabStop = false;
            this.pb_ColorSupIzq.Tag = "SupIzq";
            this.pb_ColorSupIzq.Click += new System.EventHandler(this.Pb_Color_Click);
            // 
            // btn_Superior
            // 
            this.btn_Superior.Location = new System.Drawing.Point(116, 25);
            this.btn_Superior.Name = "btn_Superior";
            this.btn_Superior.Size = new System.Drawing.Size(102, 28);
            this.btn_Superior.TabIndex = 0;
            this.btn_Superior.Text = "Superior";
            this.btn_Superior.UseVisualStyleBackColor = true;
            this.btn_Superior.Click += new System.EventHandler(this.Btn_Visible_Click);
            // 
            // btn_Derecho
            // 
            this.btn_Derecho.Location = new System.Drawing.Point(220, 98);
            this.btn_Derecho.Name = "btn_Derecho";
            this.btn_Derecho.Size = new System.Drawing.Size(102, 28);
            this.btn_Derecho.TabIndex = 2;
            this.btn_Derecho.Text = "Derecho";
            this.btn_Derecho.UseVisualStyleBackColor = true;
            this.btn_Derecho.Click += new System.EventHandler(this.Btn_Visible_Click);
            // 
            // btn_Izquierdo
            // 
            this.btn_Izquierdo.Location = new System.Drawing.Point(12, 98);
            this.btn_Izquierdo.Name = "btn_Izquierdo";
            this.btn_Izquierdo.Size = new System.Drawing.Size(102, 28);
            this.btn_Izquierdo.TabIndex = 1;
            this.btn_Izquierdo.Text = "Izquierdo";
            this.btn_Izquierdo.UseVisualStyleBackColor = true;
            this.btn_Izquierdo.Click += new System.EventHandler(this.Btn_Visible_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(6, 572);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(676, 26);
            this.panel2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(498, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Este panel es para comprobar que agregue a todos los componentes";
            // 
            // FormEjemplo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 610);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormEjemplo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gb_Medidas.ResumeLayout(false);
            this.margin.ResumeLayout(false);
            this.margin.PerformLayout();
            this.padding.ResumeLayout(false);
            this.padding.PerformLayout();
            this.border.ResumeLayout(false);
            this.border.PerformLayout();
            this.gb_Titulo.ResumeLayout(false);
            this.gb_Titulo.PerformLayout();
            this.gb_OpcionesContorno.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_ColorInfDer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ColorDer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ColorSupDer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ColorInf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ColorSup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ColorInfIzq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ColorIzq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ColorSupIzq)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Inferior;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Derecho;
        private System.Windows.Forms.Button btn_Izquierdo;
        private System.Windows.Forms.Button btn_Superior;
        private System.Windows.Forms.GroupBox gb_OpcionesContorno;
        private System.Windows.Forms.GroupBox gb_Titulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Titulo;
        private System.Windows.Forms.GroupBox gb_Medidas;
        private System.Windows.Forms.GroupBox margin;
        private System.Windows.Forms.TextBox txt_Margin_Inferior;
        private System.Windows.Forms.TextBox txt_Margin_Izquierdo;
        private System.Windows.Forms.TextBox txt_Margin_Derecho;
        private System.Windows.Forms.TextBox txt_Margin_Superior;
        private System.Windows.Forms.GroupBox padding;
        private System.Windows.Forms.TextBox txt_Padding_Inferior;
        private System.Windows.Forms.TextBox txt_Padding_Izquierdo;
        private System.Windows.Forms.TextBox txt_Padding_Derecho;
        private System.Windows.Forms.TextBox txt_Padding_Superior;
        private System.Windows.Forms.GroupBox border;
        private System.Windows.Forms.TextBox txt_Border_Derecho;
        private System.Windows.Forms.TextBox txt_Border_Izquierdo;
        private System.Windows.Forms.TextBox txt_Border_Inferior;
        private System.Windows.Forms.TextBox txt_Border_Superior;
        private System.Windows.Forms.Button btn_Actualizar;
        private System.Windows.Forms.Label l_Version;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Destroy;
        private System.Windows.Forms.ColorDialog colorDialog_Outline;
        private System.Windows.Forms.PictureBox pb_ColorInfDer;
        private System.Windows.Forms.PictureBox pb_ColorDer;
        private System.Windows.Forms.PictureBox pb_ColorSupDer;
        private System.Windows.Forms.PictureBox pb_ColorInf;
        private System.Windows.Forms.PictureBox pb_ColorSup;
        private System.Windows.Forms.PictureBox pb_ColorInfIzq;
        private System.Windows.Forms.PictureBox pb_ColorIzq;
        private System.Windows.Forms.PictureBox pb_ColorSupIzq;
        private System.Windows.Forms.Panel panel3;
    }
}

