namespace OutlineForm_Example
{
    partial class Form1
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
            this.bottomEnable = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.medidasBoton = new System.Windows.Forms.Button();
            this.margin = new System.Windows.Forms.GroupBox();
            this.marginBottom = new System.Windows.Forms.TextBox();
            this.marginLeft = new System.Windows.Forms.TextBox();
            this.marginRight = new System.Windows.Forms.TextBox();
            this.marginTop = new System.Windows.Forms.TextBox();
            this.padding = new System.Windows.Forms.GroupBox();
            this.paddingBottom = new System.Windows.Forms.TextBox();
            this.paddingLeft = new System.Windows.Forms.TextBox();
            this.paddingRight = new System.Windows.Forms.TextBox();
            this.paddingTop = new System.Windows.Forms.TextBox();
            this.border = new System.Windows.Forms.GroupBox();
            this.borderRight = new System.Windows.Forms.TextBox();
            this.borderLeft = new System.Windows.Forms.TextBox();
            this.borderBottom = new System.Windows.Forms.TextBox();
            this.borderTop = new System.Windows.Forms.TextBox();
            this.superior = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.contorno = new System.Windows.Forms.GroupBox();
            this.topEnable = new System.Windows.Forms.Button();
            this.RightEnable = new System.Windows.Forms.Button();
            this.leftEnable = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.margin.SuspendLayout();
            this.padding.SuspendLayout();
            this.border.SuspendLayout();
            this.superior.SuspendLayout();
            this.contorno.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomEnable
            // 
            this.bottomEnable.Location = new System.Drawing.Point(68, 77);
            this.bottomEnable.Name = "bottomEnable";
            this.bottomEnable.Size = new System.Drawing.Size(75, 23);
            this.bottomEnable.TabIndex = 0;
            this.bottomEnable.Text = "Bottom";
            this.bottomEnable.UseVisualStyleBackColor = true;
            this.bottomEnable.Click += new System.EventHandler(this.Button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.superior);
            this.panel1.Controls.Add(this.contorno);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 389);
            this.panel1.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.medidasBoton);
            this.groupBox3.Controls.Add(this.margin);
            this.groupBox3.Controls.Add(this.padding);
            this.groupBox3.Controls.Add(this.border);
            this.groupBox3.Location = new System.Drawing.Point(3, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(154, 370);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Medidas de la ventana";
            // 
            // medidasBoton
            // 
            this.medidasBoton.Location = new System.Drawing.Point(40, 323);
            this.medidasBoton.Name = "medidasBoton";
            this.medidasBoton.Size = new System.Drawing.Size(75, 23);
            this.medidasBoton.TabIndex = 3;
            this.medidasBoton.Text = "Actualizar";
            this.medidasBoton.UseVisualStyleBackColor = true;
            this.medidasBoton.Click += new System.EventHandler(this.MedidasBoton_Click);
            // 
            // margin
            // 
            this.margin.Controls.Add(this.marginBottom);
            this.margin.Controls.Add(this.marginLeft);
            this.margin.Controls.Add(this.marginRight);
            this.margin.Controls.Add(this.marginTop);
            this.margin.Location = new System.Drawing.Point(16, 225);
            this.margin.Name = "margin";
            this.margin.Size = new System.Drawing.Size(126, 97);
            this.margin.TabIndex = 2;
            this.margin.TabStop = false;
            this.margin.Text = "Margin";
            // 
            // marginBottom
            // 
            this.marginBottom.Location = new System.Drawing.Point(33, 71);
            this.marginBottom.Name = "marginBottom";
            this.marginBottom.Size = new System.Drawing.Size(53, 20);
            this.marginBottom.TabIndex = 0;
            // 
            // marginLeft
            // 
            this.marginLeft.Location = new System.Drawing.Point(6, 45);
            this.marginLeft.Name = "marginLeft";
            this.marginLeft.Size = new System.Drawing.Size(53, 20);
            this.marginLeft.TabIndex = 0;
            // 
            // marginRight
            // 
            this.marginRight.Location = new System.Drawing.Point(65, 45);
            this.marginRight.Name = "marginRight";
            this.marginRight.Size = new System.Drawing.Size(53, 20);
            this.marginRight.TabIndex = 0;
            // 
            // marginTop
            // 
            this.marginTop.Location = new System.Drawing.Point(33, 19);
            this.marginTop.Name = "marginTop";
            this.marginTop.Size = new System.Drawing.Size(53, 20);
            this.marginTop.TabIndex = 0;
            // 
            // padding
            // 
            this.padding.Controls.Add(this.paddingBottom);
            this.padding.Controls.Add(this.paddingLeft);
            this.padding.Controls.Add(this.paddingRight);
            this.padding.Controls.Add(this.paddingTop);
            this.padding.Location = new System.Drawing.Point(16, 122);
            this.padding.Name = "padding";
            this.padding.Size = new System.Drawing.Size(126, 97);
            this.padding.TabIndex = 2;
            this.padding.TabStop = false;
            this.padding.Text = "Padding";
            // 
            // paddingBottom
            // 
            this.paddingBottom.Location = new System.Drawing.Point(33, 71);
            this.paddingBottom.Name = "paddingBottom";
            this.paddingBottom.Size = new System.Drawing.Size(53, 20);
            this.paddingBottom.TabIndex = 0;
            // 
            // paddingLeft
            // 
            this.paddingLeft.Location = new System.Drawing.Point(6, 45);
            this.paddingLeft.Name = "paddingLeft";
            this.paddingLeft.Size = new System.Drawing.Size(53, 20);
            this.paddingLeft.TabIndex = 0;
            // 
            // paddingRight
            // 
            this.paddingRight.Location = new System.Drawing.Point(65, 45);
            this.paddingRight.Name = "paddingRight";
            this.paddingRight.Size = new System.Drawing.Size(53, 20);
            this.paddingRight.TabIndex = 0;
            // 
            // paddingTop
            // 
            this.paddingTop.Location = new System.Drawing.Point(33, 19);
            this.paddingTop.Name = "paddingTop";
            this.paddingTop.Size = new System.Drawing.Size(53, 20);
            this.paddingTop.TabIndex = 0;
            // 
            // border
            // 
            this.border.Controls.Add(this.borderRight);
            this.border.Controls.Add(this.borderLeft);
            this.border.Controls.Add(this.borderBottom);
            this.border.Controls.Add(this.borderTop);
            this.border.Location = new System.Drawing.Point(16, 19);
            this.border.Name = "border";
            this.border.Size = new System.Drawing.Size(126, 97);
            this.border.TabIndex = 1;
            this.border.TabStop = false;
            this.border.Text = "Border";
            // 
            // borderRight
            // 
            this.borderRight.Location = new System.Drawing.Point(67, 45);
            this.borderRight.Name = "borderRight";
            this.borderRight.Size = new System.Drawing.Size(53, 20);
            this.borderRight.TabIndex = 0;
            // 
            // borderLeft
            // 
            this.borderLeft.Location = new System.Drawing.Point(6, 45);
            this.borderLeft.Name = "borderLeft";
            this.borderLeft.Size = new System.Drawing.Size(53, 20);
            this.borderLeft.TabIndex = 0;
            // 
            // borderBottom
            // 
            this.borderBottom.Location = new System.Drawing.Point(33, 71);
            this.borderBottom.Name = "borderBottom";
            this.borderBottom.Size = new System.Drawing.Size(53, 20);
            this.borderBottom.TabIndex = 0;
            // 
            // borderTop
            // 
            this.borderTop.Location = new System.Drawing.Point(33, 19);
            this.borderTop.Name = "borderTop";
            this.borderTop.Size = new System.Drawing.Size(53, 20);
            this.borderTop.TabIndex = 0;
            // 
            // superior
            // 
            this.superior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.superior.Controls.Add(this.label1);
            this.superior.Controls.Add(this.nameTextBox);
            this.superior.Location = new System.Drawing.Point(186, 201);
            this.superior.Name = "superior";
            this.superior.Size = new System.Drawing.Size(210, 69);
            this.superior.TabIndex = 10;
            this.superior.TabStop = false;
            this.superior.Text = "PanelSuperior";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre de la ventana";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(18, 35);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(172, 20);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // contorno
            // 
            this.contorno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.contorno.Controls.Add(this.topEnable);
            this.contorno.Controls.Add(this.bottomEnable);
            this.contorno.Controls.Add(this.RightEnable);
            this.contorno.Controls.Add(this.leftEnable);
            this.contorno.Location = new System.Drawing.Point(186, 276);
            this.contorno.Name = "contorno";
            this.contorno.Size = new System.Drawing.Size(210, 108);
            this.contorno.TabIndex = 8;
            this.contorno.TabStop = false;
            this.contorno.Text = "Mostrar contorno";
            // 
            // topEnable
            // 
            this.topEnable.Location = new System.Drawing.Point(68, 19);
            this.topEnable.Name = "topEnable";
            this.topEnable.Size = new System.Drawing.Size(75, 23);
            this.topEnable.TabIndex = 4;
            this.topEnable.Text = "Top";
            this.topEnable.UseVisualStyleBackColor = true;
            this.topEnable.Click += new System.EventHandler(this.Button2_Click);
            // 
            // RightEnable
            // 
            this.RightEnable.Location = new System.Drawing.Point(131, 48);
            this.RightEnable.Name = "RightEnable";
            this.RightEnable.Size = new System.Drawing.Size(75, 23);
            this.RightEnable.TabIndex = 6;
            this.RightEnable.Text = "Right";
            this.RightEnable.UseVisualStyleBackColor = true;
            this.RightEnable.Click += new System.EventHandler(this.Button4_Click);
            // 
            // leftEnable
            // 
            this.leftEnable.Location = new System.Drawing.Point(8, 48);
            this.leftEnable.Name = "leftEnable";
            this.leftEnable.Size = new System.Drawing.Size(75, 23);
            this.leftEnable.TabIndex = 5;
            this.leftEnable.Text = "Left";
            this.leftEnable.UseVisualStyleBackColor = true;
            this.leftEnable.Click += new System.EventHandler(this.Button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(190, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 22);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ejemplo de OutlineForm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(240, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 22);
            this.label3.TabIndex = 12;
            this.label3.Text = "Version 0.1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 389);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.margin.ResumeLayout(false);
            this.margin.PerformLayout();
            this.padding.ResumeLayout(false);
            this.padding.PerformLayout();
            this.border.ResumeLayout(false);
            this.border.PerformLayout();
            this.superior.ResumeLayout(false);
            this.superior.PerformLayout();
            this.contorno.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bottomEnable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button RightEnable;
        private System.Windows.Forms.Button leftEnable;
        private System.Windows.Forms.Button topEnable;
        private System.Windows.Forms.GroupBox contorno;
        private System.Windows.Forms.GroupBox superior;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox margin;
        private System.Windows.Forms.TextBox marginBottom;
        private System.Windows.Forms.TextBox marginLeft;
        private System.Windows.Forms.TextBox marginRight;
        private System.Windows.Forms.TextBox marginTop;
        private System.Windows.Forms.GroupBox padding;
        private System.Windows.Forms.TextBox paddingBottom;
        private System.Windows.Forms.TextBox paddingLeft;
        private System.Windows.Forms.TextBox paddingRight;
        private System.Windows.Forms.TextBox paddingTop;
        private System.Windows.Forms.GroupBox border;
        private System.Windows.Forms.TextBox borderRight;
        private System.Windows.Forms.TextBox borderLeft;
        private System.Windows.Forms.TextBox borderBottom;
        private System.Windows.Forms.TextBox borderTop;
        private System.Windows.Forms.Button medidasBoton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

