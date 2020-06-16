using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OutlineForm_Example
{
    public partial class OutlineForm
    {
        #region OF_Constructor
        private void Destructor()
        {
            if (!Object.ReferenceEquals(null, panelUniversal))
            {
                for (int i = 0; i < panelCentro.Controls.Count; i++)
                {
                    myForm.Controls.Add(panelCentro.Controls[i]);
                    i--;
                }
                panelUniversal.Dispose();
                panelUniversal = null;
            }

            _colorSuperior = Color.Black;
            _colorInferior = Color.Black;
            _colorDerecho = Color.Black;
            _colorIzquierdo = Color.Black;
            _colorSupDer = Color.Black;
            _colorSupIzq = Color.Black;
            _colorInfDer = Color.Black;
            _colorInfIzq = Color.Black;

            if (!Object.ReferenceEquals(null, panelCentro)) { panelCentro.Dispose(); panelCentro = null; }
            if (!Object.ReferenceEquals(null, panelSuperior)) { panelSuperior.Dispose(); panelSuperior = null; }
            if (!Object.ReferenceEquals(null, panelIzquierdo)) { panelIzquierdo.Dispose(); panelIzquierdo = null; }
            if (!Object.ReferenceEquals(null, panelDerecho)) { panelDerecho.Dispose(); panelDerecho = null; }
            if (!Object.ReferenceEquals(null, panelInferior)) { panelInferior.Dispose(); panelInferior = null; }
            if (!Object.ReferenceEquals(null, panelDSupDer)) { panelDSupDer.Dispose(); panelDSupDer = null; }
            if (!Object.ReferenceEquals(null, panelDSupIzq)) { panelDSupIzq.Dispose(); panelDSupIzq = null; }
            if (!Object.ReferenceEquals(null, panelDInfDer)) { panelDInfDer.Dispose(); panelDInfDer = null; }
            if (!Object.ReferenceEquals(null, panelDInfIzq)) { panelDInfIzq.Dispose(); panelDInfIzq = null; }
            if (!Object.ReferenceEquals(null, panelOpciones)) { panelOpciones.Dispose(); panelOpciones = null; }
            if (!Object.ReferenceEquals(null, NombreVentana)) { NombreVentana.Dispose(); NombreVentana = null; }
            if (!Object.ReferenceEquals(null, BotonCerrar)) { BotonCerrar.Dispose(); BotonCerrar = null; }
            if (!Object.ReferenceEquals(null, BotonMinimizar)) { BotonMinimizar.Dispose(); BotonMinimizar = null; }
            if (!Object.ReferenceEquals(null, BotonOpciones)) { BotonOpciones.Dispose(); BotonOpciones = null; }
            if (!OriginalSizeWindow.IsEmpty) { myForm.Size = new Size(OriginalSizeWindow.Width, OriginalSizeWindow.Height); OriginalSizeWindow = Size.Empty; }
        }
        /// <summary>
        /// Crea un marco default alrededor del Form.
        /// </summary>
        /// <param name="formP">Form en el cual se le colocará el marco.</param>
        public OutlineForm(Form formP)
        {
            if (!listaForms.Contains(formP))
            {
                listaForms.Add(formP);
                myForm = formP;
                OriginalFormBorderStyle = myForm.FormBorderStyle;
                Set("", Color.Black, myForm.BackColor, Rect.Window, Rect.Zero, Rect.Zero, true, true, true);
            }
            else
                throw new ExceptionOutlineForm("No se puede instanciar el objeto con un Form anteriormente agregado");
        }
        public void Destroy(bool changeFormBorderStyle = false)
        {
            Point location = new Point(
                myForm.Location.X + padding.Width() + margin.Width() + border.Width(),
                myForm.Location.Y + padding.Height() + margin.Height() + border.Height()
                );

            if (changeFormBorderStyle)
                myForm.FormBorderStyle = OriginalFormBorderStyle;
            Destructor();
            listaForms.Remove(myForm);
            myForm.Location = location;
            myForm = null;
        }
        #endregion

        #region OF_MetodosPublicos
        /// <summary>
        /// Crea un marco con texto y botones alrededor del Form. En caso de existir uno, se eliminará y creará uno nuevo.
        /// </summary>
        /// <param name="nombreVentanaP"></param>
        /// <param name="colorPrimaryP"></param>
        /// <param name="colorSecundaryP"></param>
        /// <param name="borderP"></param>
        /// <param name="marginP"></param>
        /// <param name="paddingP"></param>
        /// <param name="botonMinimizarP"></param>
        /// <param name="botonCerrarP"></param>
        /// <param name="botonOpcionesP"></param>
        public void Set(string nombreVentanaP, Color colorPrimaryP, Color colorSecundaryP, Rect borderP, Rect marginP, Rect paddingP, bool botonMinimizarP, bool botonCerrarP, bool botonOpcionesP)
        {
            Destructor();
            border = new Rect(borderP);
            margin = new Rect(marginP);
            padding = new Rect(paddingP);
            colorPrimary = colorPrimaryP;
            colorSecundary = colorSecundaryP;
            nombre = nombreVentanaP;

            CrearMarco();
            CrearPanelOpcionesControles();

            if (!botonMinimizarP) BotonMinimizar.Visible = false;
            if (!botonCerrarP) BotonCerrar.Visible = false;
            if (!botonOpcionesP) BotonOpciones.Visible = false;
            AddElements();
        }
        public void SetBorderMarginPadding(Rect newBorderP, Rect newMarginP, Rect newPaddingP)
        {
            Point myPoint = myForm.Location;

            //Comprueba si existe un panel SUPERIOR
            //Luego verifica si los nuevos valores no son los mismos.
            //Caso contrario, desaparece y aparece el nuevo panel.
            if (TopPanelVisible)
            {
                if (border.Top != newBorderP.Top ||
                    margin.Top != newMarginP.Top ||
                    padding.Top != newPaddingP.Top
                    )
                {
                    TopPanelVisible = false;
                    border.Top = newBorderP.Top;
                    margin.Top = newMarginP.Top;
                    padding.Top = newPaddingP.Top;
                    TopPanelVisible = true;
                }
            }
            else
            {
                border.Top = newBorderP.Top;
                margin.Top = newMarginP.Top;
                padding.Top = newPaddingP.Top;
            }

            //Comprueba si existe un panel INFERIOR
            //Luego verifica si los nuevos valores no son los mismos.
            //Caso contrario, desaparece y aparece el nuevo panel.
            if (BottomPanelVisible)
            {
                if (border.Bottom != newBorderP.Bottom ||
                    margin.Bottom != newMarginP.Bottom ||
                    padding.Bottom != newPaddingP.Bottom
                    )
                {
                    BottomPanelVisible = false;
                    border.Bottom = newBorderP.Bottom;
                    margin.Bottom = newMarginP.Bottom;
                    padding.Bottom = newPaddingP.Bottom;
                    BottomPanelVisible = true;
                }
            }
            else
            {
                border.Bottom = newBorderP.Bottom;
                margin.Bottom = newMarginP.Bottom;
                padding.Bottom = newPaddingP.Bottom;
            }

            //Comprueba si existe un panel IZQUIERDO
            //Luego verifica si los nuevos valores no son los mismos.
            //Caso contrario, desaparece y aparece el nuevo panel.
            if (LeftPanelVisible)
            {
                if (border.Left != newBorderP.Left ||
                    margin.Left != newMarginP.Left ||
                    padding.Left != newPaddingP.Left
                    )
                {
                    LeftPanelVisible = false;
                    border.Left = newBorderP.Left;
                    margin.Left = newMarginP.Left;
                    padding.Left = newPaddingP.Left;
                    LeftPanelVisible = true;
                }
            }
            else
            {
                border.Left = newBorderP.Left;
                margin.Left = newMarginP.Left;
                padding.Left = newPaddingP.Left;
            }

            //Comprueba si existe un panel DERECHO
            //Luego verifica si los nuevos valores no son los mismos.
            //Caso contrario, desaparece y aparece el nuevo panel.
            if (RightPanelVisible)
            {
                if (border.Right != newBorderP.Right ||
                    margin.Right != newMarginP.Right ||
                    padding.Right != newPaddingP.Right
                    )
                {
                    RightPanelVisible = false;
                    border.Right = newBorderP.Right;
                    margin.Right = newMarginP.Right;
                    padding.Right = newPaddingP.Right;
                    RightPanelVisible = true;
                }
            }
            else
            {
                border.Right = newBorderP.Right;
                margin.Right = newMarginP.Right;
                padding.Right = newPaddingP.Right;
            }

            myForm.Location = myPoint;
        }
        public void SetBorder(Rect newBorderP)
        {
            SetBorderMarginPadding(newBorderP, margin, padding);
        }
        public void SetMargin(Rect newMarginP)
        {
            SetBorderMarginPadding(border, newMarginP, padding);
        }
        public void SetPadding(Rect newPadding)
        {
            SetBorderMarginPadding(border, margin, padding);
        }
        public void SetColorPanel(SelectedPanel panelP, Color colorP)
        {
            List<Panel> lista = SearchPanel(panelP);
            foreach (Panel miPanel in lista)
            {
                switch ((SelectedPanel)miPanel.Tag)
                {
                    case SelectedPanel.Superior:
                        TopColor = colorP;
                        break;
                    case SelectedPanel.Inferior:
                        BottomColor = colorP;
                        break;
                    case SelectedPanel.Izquierdo:
                        LeftColor = colorP;
                        break;
                    case SelectedPanel.Derecho:
                        RightColor = colorP;
                        break;
                    case SelectedPanel.EsquinaSuperiorIzquierdo:
                        TopLeftColor = colorP;
                        break;
                    case SelectedPanel.EsquinaSuperiorDerecho:
                        TopRightColor = colorP;
                        break;
                    case SelectedPanel.EsquinaInferiorIzquierdo:
                        BottomLeftColor = colorP;
                        break;                
                    case SelectedPanel.EsquinaInferiorDerecho:
                        BottomRightColor = colorP;
                        break;
                }
            }
        }
        public bool IsWindowOutsideScreen() => myForm.Location.X < 0 ||
                myForm.Location.X + myForm.Width > Screen.PrimaryScreen.WorkingArea.Width ||
                myForm.Location.Y < 0 ||
                myForm.Location.Y + myForm.Height > Screen.PrimaryScreen.WorkingArea.Height;
        public void SetWindowInScreen()
        {
            if (myForm.Location.X < 0)
                myForm.Location = new Point(0, myForm.Location.Y);
            else if (myForm.Location.X + myForm.Width > Screen.PrimaryScreen.WorkingArea.Width)
                myForm.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - myForm.Width, myForm.Location.Y);

            if (myForm.Location.Y < 0)
                myForm.Location = new Point(myForm.Location.X, 0);
            else if (myForm.Location.Y + myForm.Height > Screen.PrimaryScreen.WorkingArea.Height)
                myForm.Location = new Point(myForm.Location.X, Screen.PrimaryScreen.WorkingArea.Height - myForm.Height);
        }
        #endregion

        #region OF_MetodosPrivados
        private void CrearMarco()
        {
            //-------------------------------------------------------------
            //form details
            //-------------------------------------------------------------
            myForm.FormBorderStyle = FormBorderStyle.None;
            OriginalSizeWindow = new Size(myForm.Width, myForm.Height);

            //-------------------------------------------------------------
            //new panelUniversal
            //-------------------------------------------------------------
            panelUniversal = new Panel();
            panelUniversal.Name = "Outline - Universal";
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
            panelOpciones.Name = "Outline - Options";
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
            panelDSupIzq.Tag = SelectedPanel.EsquinaSuperiorIzquierdo;
            panelDSupIzq.Name = "Outline - TopLeft";
            panelDSupIzq.Left = panelIzquierdo == null ? -border.Left : margin.Left;
            panelDSupIzq.Top = panelSuperior == null ? -border.Top : margin.Top;
            panelDSupIzq.Size = new Size(border.Left, border.Top);
            panelDSupIzq.BackColor = _colorSupIzq;
            panelDSupIzq.TabStop = false;
            panelDSupIzq.SendToBack();

            //-------------------------------------------------------------
            //new panelDSupDer
            //-------------------------------------------------------------
            panelDSupDer = new Panel();
            panelUniversal.Controls.Add(panelDSupDer);
            panelDSupDer.Tag = SelectedPanel.EsquinaSuperiorDerecho;
            panelDSupDer.Name = "Outline - TopRight";
            panelDSupDer.Left = panelIzquierdo == null ? OriginalSizeWindow.Width + padding.Right : OriginalSizeWindow.Width + border.Left + margin.Left + padding.Width();
            panelDSupDer.Top = panelSuperior == null ? -border.Top : margin.Top;
            panelDSupDer.Size = new Size(border.Right, border.Top);
            panelDSupDer.BackColor = _colorSupDer;
            panelDSupDer.TabStop = false;
            panelDSupDer.SendToBack();

            //-------------------------------------------------------------
            //new panelDInfIzq
            //-------------------------------------------------------------
            panelDInfIzq = new Panel();
            panelUniversal.Controls.Add(panelDInfIzq);
            panelDInfIzq.Tag = SelectedPanel.EsquinaInferiorIzquierdo;
            panelDInfIzq.Name = "Outline - BottomLeft";
            panelDInfIzq.Left = panelIzquierdo == null ? -border.Left : margin.Left;
            panelDInfIzq.Top = panelSuperior == null ? OriginalSizeWindow.Height + padding.Bottom : OriginalSizeWindow.Height + border.Top + margin.Top + padding.Height();
            panelDInfIzq.Size = new Size(border.Left, border.Bottom);
            panelDInfIzq.BackColor = _colorInfIzq;
            panelDInfIzq.TabStop = false;
            panelDInfIzq.SendToBack();

            //-------------------------------------------------------------
            //new panelDInfDer
            //-------------------------------------------------------------
            panelDInfDer = new Panel();
            panelUniversal.Controls.Add(panelDInfDer);
            panelDInfDer.Tag = SelectedPanel.EsquinaInferiorDerecho;
            panelDInfDer.Name = "Outline - BottomRight";
            panelDInfDer.Left = panelIzquierdo == null ? OriginalSizeWindow.Width + padding.Right : OriginalSizeWindow.Width + border.Left + margin.Left + padding.Width();
            panelDInfDer.Top = panelSuperior == null ? OriginalSizeWindow.Height + padding.Bottom : OriginalSizeWindow.Height + border.Top + margin.Top + padding.Height();
            panelDInfDer.Size = new Size(border.Right, border.Bottom);
            panelDInfDer.BackColor = _colorInfDer;
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
        private bool AddElement(Control controlP)
        {
            if (!Object.ReferenceEquals(null, controlP) && !panelCentro.Controls.Contains(controlP))
            {
                panelCentro.Controls.Add(controlP);
                return true;
            }
            return false;
        }
        private void AddElements()
        {
            for (int i=0; i<myForm.Controls.Count;i++)
            {
                if (myForm.Controls[i] != panelUniversal)
                {
                    if (AddElement(myForm.Controls[i]))
                        i--;
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

        #region OF_Eventos
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
            SetWindowInScreen();
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
