using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OutlineForm_Example
{
    public partial class OutlineForm
    {
        #region MetodosPrivados
        private void CrearMarco()
        {
            //-------------------------------------------------------------
            //form details
            //-------------------------------------------------------------
            myForm.FormBorderStyle = FormBorderStyle.None;
            OriginalSizeWindow = new Size(myForm.Width, myForm.Height);
            OriginalLocationWindow = new Point(myForm.Location.X, myForm.Location.Y);

            //-------------------------------------------------------------
            //new panelUniversal
            //-------------------------------------------------------------
            panelUniversal = new Panel();
            panelUniversal.Name = "BarraDeTitulo";
            panelUniversal.Left = 0;
            panelUniversal.Top = 0;
            panelUniversal.Size = new Size(myForm.Width, myForm.Height);
            panelUniversal.TabStop = false;
            panelUniversal.BackColor = Color.Transparent;
            panelUniversal.SendToBack();
            myForm.Controls.Add(panelUniversal);


            //-------------------------------------------------------------
            //new panelOpciones
            //-------------------------------------------------------------
            panelOpciones = new Panel();
            panelOpciones.Name = "BarraDeTitulo - panelOpciones";
            panelOpciones.Left = 0;
            panelOpciones.Top = 0;
            panelOpciones.Size = new Size(myForm.Width, myForm.Height);
            // panelInferior.MouseMove += new MouseEventHandler(panel_MouseMove);
            // panelInferior.MouseDown += new MouseEventHandler(panel_MouseDown);
            // panelInferior.MouseUp += new MouseEventHandler(panel_MouseUp);
            panelOpciones.BackColor = colorSecundary;
            panelOpciones.TabStop = false;
            panelOpciones.BringToFront();
            panelOpciones.Visible = false;
            panelUniversal.Controls.Add(panelOpciones);


            //-------------------------------------------------------------
            //new timerpanelOpciones
            //-------------------------------------------------------------
            timerPanelOpciones = new Timer();
            timerPanelOpciones.Enabled = false;
            timerPanelOpciones.Interval = 10;
            timerPanelOpciones.Tick += new EventHandler(timerPanelCompleto_Tick);



            //*************************************************************
            //new Marco
            //*************************************************************
            //-------------------------------------------------------------
            //new panelInferior
            //-------------------------------------------------------------
            BottomPanelVisible = _isPanelInferior;

            //-------------------------------------------------------------
            //new panelSuperior
            //-------------------------------------------------------------
            TopPanelVisible = _isPanelSuperior;

            //-------------------------------------------------------------
            //new panelDerecho
            //-------------------------------------------------------------
            RightPanelVisible = _isPanelDerecho;

            //-------------------------------------------------------------
            //new panelIzquierdo
            //-------------------------------------------------------------
            LeftPanelVisible = _isPanelIzquierdo;

            //-------------------------------------------------------------
            //new panelCentro
            //-------------------------------------------------------------
            CenterPanelVisible = true;

            //-------------------------------------------------------------
            //new panelDSupIzq
            //-------------------------------------------------------------
            panelDSupIzq = new Panel();
            panelUniversal.Controls.Add(panelDSupIzq);
            panelDSupIzq.Name = "BarraDeTitulo - panelDSupIzq";
            panelDSupIzq.Left = panelIzquierdo == null ? -border.Left : margin.Left;
            panelDSupIzq.Top = panelSuperior == null ? -border.Top : margin.Top;
            panelDSupIzq.Size = new Size(border.Left, border.Top);
            panelDSupIzq.BackColor = colorPrimary;
            panelDSupIzq.TabStop = false;
            panelDSupIzq.SendToBack();

            //-------------------------------------------------------------
            //new panelDSupDer
            //-------------------------------------------------------------
            panelDSupDer = new Panel();
            panelUniversal.Controls.Add(panelDSupDer);
            panelDSupDer.Name = "BarraDeTitulo - panelDSupDer";
            panelDSupDer.Left = panelIzquierdo == null ? OriginalSizeWindow.Width + padding.Right : OriginalSizeWindow.Width + border.Left + margin.Left + padding.Width();
            panelDSupDer.Top = panelSuperior == null ? -border.Top : margin.Top;
            panelDSupDer.Size = new Size(border.Right, border.Top);
            panelDSupDer.BackColor = colorPrimary;
            panelDSupDer.TabStop = false;
            panelDSupDer.SendToBack();

            //-------------------------------------------------------------
            //new panelDInfIzq
            //-------------------------------------------------------------
            panelDInfIzq = new Panel();
            panelUniversal.Controls.Add(panelDInfIzq);
            panelDInfIzq.Name = "BarraDeTitulo - panelDInfIzq";
            panelDInfIzq.Left = panelIzquierdo == null ? -border.Left : margin.Left;
            panelDInfIzq.Top = panelSuperior == null ? OriginalSizeWindow.Height + padding.Bottom : OriginalSizeWindow.Height + border.Top + margin.Top + padding.Height();
            panelDInfIzq.Size = new Size(border.Left, border.Bottom);
            panelDInfIzq.BackColor = colorPrimary;
            panelDInfIzq.TabStop = false;
            panelDInfIzq.SendToBack();

            //-------------------------------------------------------------
            //new panelDInfDer
            //-------------------------------------------------------------
            panelDInfDer = new Panel();
            panelUniversal.Controls.Add(panelDInfDer);
            panelDInfDer.Name = "BarraDeTitulo - panelDInfDer";
            panelDInfDer.Left = panelIzquierdo == null ? OriginalSizeWindow.Width + padding.Right : OriginalSizeWindow.Width + border.Left + margin.Left + padding.Width();
            panelDInfDer.Top = panelSuperior == null ? OriginalSizeWindow.Height + padding.Bottom : OriginalSizeWindow.Height + border.Top + margin.Top + padding.Height();
            panelDInfDer.Size = new Size(border.Right, border.Bottom);
            panelDInfDer.BackColor = colorPrimary;
            panelDInfDer.TabStop = false;
            panelDInfDer.SendToBack();



            //-------------------------------------------------------------
            //final details
            //-------------------------------------------------------------
            panelSuperior.BringToFront();
            panelCentro.SendToBack();
            SetLocation();
        }
        private void CrearPanelOpcionesControles()
        {

        }
        private void CrearBotonCerrar()
        {
            BotonCerrar = new Button();
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(BotonCerrar, "Cierra la ventana");
            BotonCerrar.Text = "X";
            BotonCerrar.Font = new Font(FontFamily.GenericSerif, 10.0f, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Pixel);
            BotonCerrar.ForeColor = Color.FromArgb(255, 255, 255);
            BotonCerrar.BackColor = Color.FromArgb(210, 0, 0);
            BotonCerrar.FlatStyle = FlatStyle.Popup;
            BotonCerrar.Size = new Size(35, 25);
            BotonCerrar.Top = 10;
            BotonCerrar.Left = panelSuperior.Width - 40;
            BotonCerrar.Click += new EventHandler(cerrar_Click);
            BotonCerrar.BringToFront();
            BotonCerrar.TabStop = false;
            panelSuperior.Controls.Add(BotonCerrar);


        }
        private void CrearBotonMinimizar()
        {
            BotonMinimizar = new Button();
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(BotonMinimizar, "Minimiza la ventana");
            BotonMinimizar.Text = "-";
            BotonMinimizar.BackColor = Color.LightGray;
            BotonMinimizar.FlatStyle = FlatStyle.Flat;
            BotonMinimizar.Size = new Size(35, 25);
            BotonMinimizar.Top = 10;
            BotonMinimizar.Left = panelSuperior.Width - 80;
            BotonMinimizar.Click += new EventHandler(minimizar_Click);
            BotonMinimizar.BringToFront();
            BotonMinimizar.TabStop = false;
            panelSuperior.Controls.Add(BotonMinimizar);

        }
        private void CrearBotonOpciones()
        {
            BotonOpciones = new Button();
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(BotonOpciones, "Opciones...");
            BotonOpciones.Text = "v";
            BotonOpciones.BackColor = Color.DarkGray;
            BotonOpciones.FlatStyle = FlatStyle.Flat;
            BotonOpciones.Size = new Size(35, 25);
            BotonOpciones.Top = 10;
            BotonOpciones.Left = panelSuperior.Width - 120;
            BotonOpciones.Click += new EventHandler(opciones_Click);
            BotonOpciones.BringToFront();
            BotonOpciones.TabStop = false;
            panelSuperior.Controls.Add(BotonOpciones);

        }
        private void CrearLabelTexto()
        {
            NombreVentana = new Label();
            panelSuperior.Controls.Add(NombreVentana);
            NombreVentana.BackColor = colorSecundary;
            NombreVentana.Text = nombre;
            NombreVentana.AutoSize = true;
            NombreVentana.Font = new Font(FontFamily.GenericSerif, 25.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            NombreVentana.Top = panelSuperior.Height - NombreVentana.Height;
            NombreVentana.Left = 10;
            NombreVentana.BringToFront();
        }
        private void AddElement(Control controlP)
        {
            if (!Object.ReferenceEquals(null, controlP) && !panelCentro.Controls.Contains(controlP))
            {
                panelCentro.Controls.Add(controlP);
            }
        }
        private void AddElements()
        {
            foreach (Control control in myForm.Controls)
            {
                if (control != panelUniversal)
                {
                    AddElement(control);
                }

            }
        }
        private void SetLocation()
        {
            //myForm.Location = new Point(
            //    OriginalLocationWindow.X + border.Left + margin.Left ,
            //    OriginalLocationWindow.Y + border.Top + margin.Top 
            //    );
        }
        private void AcomodarEsquinas()
        {
            if (panelDSupIzq != null)
            {
                panelDSupIzq.Left = panelIzquierdo == null ? -border.Left : margin.Left;
                panelDSupIzq.Top = panelSuperior == null ? -border.Top : margin.Top;
                panelDSupIzq.Size = new Size(border.Left, border.Top);
            }
            if (panelDSupDer != null)
            {
                panelDSupDer.Left = panelIzquierdo == null ? OriginalSizeWindow.Width + padding.Right : OriginalSizeWindow.Width + border.Left + margin.Left + padding.Width();
                panelDSupDer.Top = panelSuperior == null ? -border.Top : margin.Top;
                panelDSupDer.Size = new Size(border.Left, border.Top);
            }
            if (panelDInfDer != null)
            {
                panelDInfDer.Left = panelIzquierdo == null ? OriginalSizeWindow.Width + padding.Right : OriginalSizeWindow.Width + border.Left + margin.Left + padding.Width();
                panelDInfDer.Top = panelSuperior == null ? OriginalSizeWindow.Height + padding.Bottom : OriginalSizeWindow.Height + border.Top + margin.Top + padding.Height();
                panelDInfDer.Size = new Size(border.Right, border.Bottom);
            }
            if (panelDInfIzq != null)
            {
                panelDInfIzq.Left = panelIzquierdo == null ? -border.Left : margin.Left;
                panelDInfIzq.Top = panelSuperior == null ? OriginalSizeWindow.Height + padding.Bottom : OriginalSizeWindow.Height + border.Top + margin.Top + padding.Height();
                panelDInfIzq.Size = new Size(border.Left, border.Bottom);
            }
        }

        private List<Panel> SearchPanel(SelectedPanel panelP)
        {
            List<Panel> panelesRetorno = new List<Panel>();
            int numeroOpcion = (int)panelP;


            if (numeroOpcion >= 128) //EsquinaInferiorIzquierdo
            {
                panelesRetorno.Add(panelDInfIzq);
                numeroOpcion -= 128;
            }
            if (numeroOpcion >= 64) //EsquinaInferiorDerecho
            {
                panelesRetorno.Add(panelDInfDer);
                numeroOpcion -= 64;
            }
            if (numeroOpcion >= 32) //EsquinaSuperiorIzquierdo
            {
                panelesRetorno.Add(panelDSupIzq);
                numeroOpcion -= 32;
            }
            if (numeroOpcion >= 16) //EsquinaSuperiorDerecho
            {
                panelesRetorno.Add(panelDSupDer);
                numeroOpcion -= 16;
            }
            if (numeroOpcion >= 8) //Inferior
            {
                panelesRetorno.Add(panelInferior);
                numeroOpcion -= 8;
            }
            if (numeroOpcion >= 4) //Superior
            {
                panelesRetorno.Add(panelSuperior);
                numeroOpcion -= 4;
            }
            if (numeroOpcion >= 2) //Derecho
            {
                panelesRetorno.Add(panelDerecho);
                numeroOpcion -= 2;
            }
            if (numeroOpcion >= 1) //Izquierdo
            {
                panelesRetorno.Add(panelIzquierdo);
                numeroOpcion -= 1;
            }

            return panelesRetorno;
        }


        #endregion

        #region Eventos
        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            isSosteniendo = true;
            movX = e.X + margin.Width();
            movY = e.Y + margin.Height();
        }
        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isSosteniendo)
            {
                myForm.SetDesktopLocation(Control.MousePosition.X - movX, Control.MousePosition.Y - movY);
            }
        }
        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            isSosteniendo = false;
        }
        private void panel_Resize_MouseHover(object sender, EventArgs e)
        {
            myForm.Cursor = Cursors.SizeWE;
        }
        private void panel_Resize_MouseLeave(object sender, EventArgs e)
        {
            myForm.Cursor = Cursors.Default;
        }
        private void panel_Resize_MouseDown(object sender, MouseEventArgs e)
        {
            isSosteniendo = true;
            movX = e.X;
            movY = e.Y;
        }
        private void panel_Resize_MouseMove(object sender, MouseEventArgs e)
        {
            if (isSosteniendo)
            {
                myForm.SetDesktopLocation(Control.MousePosition.X - movX, Control.MousePosition.Y - movY);
            }
        }
        private void panel_Resize_MouseUp(object sender, MouseEventArgs e)
        {
            isSosteniendo = false;
        }
        private void cerrar_Click(object sender, EventArgs e)
        {
            myForm.Dispose();
        }
        private void minimizar_Click(object sender, EventArgs e)
        {
            myForm.WindowState = FormWindowState.Minimized;
        }
        private void opciones_Click(object sender, EventArgs e)
        {
            panelOpciones.Location = new Point(0, -myForm.Height);
            panelOpciones.BringToFront();
            panelOpciones.Visible = true;
            timerPanelOpciones.Enabled = true;
        }
        private void timerPanelCompleto_Tick(object sender, EventArgs e)
        {
            panelOpciones.Location = new Point(0, panelOpciones.Location.Y + velocidadAnimacion);
            if (panelOpciones.Location.Y + panelOpciones.Height > myForm.Height - velocidadAnimacion)
            {
                panelOpciones.Location = new Point(0, 0);
                timerPanelOpciones.Enabled = false;
            }
        }
        #endregion
    }
}
