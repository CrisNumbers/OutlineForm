using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FormDecoration
{
    public partial class OutlineForm
    {
        #region OF_Constructor
        private void Destructor()
        {
            if (!Object.ReferenceEquals(null, _panelUniversal))
            {
                for (int i = 0; i < _panelCentro.Controls.Count; i++)
                {
                    myForm.Controls.Add(_panelCentro.Controls[i]);
                    i--;
                }
                _panelUniversal.Dispose();
                _panelUniversal = null;
            }

            _colorSuperior = Color.Black;
            _colorInferior = Color.Black;
            _colorDerecho = Color.Black;
            _colorIzquierdo = Color.Black;
            _colorSupDer = Color.Black;
            _colorSupIzq = Color.Black;
            _colorInfDer = Color.Black;
            _colorInfIzq = Color.Black;

            if (!Object.ReferenceEquals(null, _panelCentro)) { _panelCentro.Dispose(); _panelCentro = null; }
            if (!Object.ReferenceEquals(null, _panelSuperior)) { _panelSuperior.Dispose(); _panelSuperior = null; }
            if (!Object.ReferenceEquals(null, _panelIzquierdo)) { _panelIzquierdo.Dispose(); _panelIzquierdo = null; }
            if (!Object.ReferenceEquals(null, _panelDerecho)) { _panelDerecho.Dispose(); _panelDerecho = null; }
            if (!Object.ReferenceEquals(null, _panelInferior)) { _panelInferior.Dispose(); _panelInferior = null; }
            if (!Object.ReferenceEquals(null, _panelDSupDer)) { _panelDSupDer.Dispose(); _panelDSupDer = null; }
            if (!Object.ReferenceEquals(null, _panelDSupIzq)) { _panelDSupIzq.Dispose(); _panelDSupIzq = null; }
            if (!Object.ReferenceEquals(null, _panelDInfDer)) { _panelDInfDer.Dispose(); _panelDInfDer = null; }
            if (!Object.ReferenceEquals(null, _panelDInfIzq)) { _panelDInfIzq.Dispose(); _panelDInfIzq = null; }
            if (!Object.ReferenceEquals(null, _panelOpciones)) { _panelOpciones.Dispose(); _panelOpciones = null; }
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
                Set("", Color.Black, myForm.BackColor, Rect.Window, Rect.Zero, Rect.Zero, true, true, false);
            }
            else
                throw new ExceptionOutlineForm("No se puede instanciar el objeto con un Form anteriormente agregado");
        }
        /// <summary>
        /// Destruye el marco por completo.
        /// </summary>
        /// <param name="changeFormBorderStyle">Si es true, entonces volverá el estilo del borde que tenía antes.</param>
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
        /// Especifica el Border, Margin y Padding del marco. Si cada elemento es igual al actual, entonces no generará cambios en la ventana.
        /// <para>Sí el panel no existe en el marco, entonces no realizará cambio a dicho panel ni creará uno nuevo.</para>
        /// </summary>
        /// <param name="newBorderP">El nuevo Border que tendrá el marco.</param>
        /// <param name="newMarginP">El nuevo Margin (externo al Border) que tendrá el marco.</param>
        /// <param name="newPaddingP">El nuevo Padding (interno al Border) que tendrá el marco.</param>
        public void SetBorderMarginPadding(Rect newBorderP, Rect newMarginP, Rect newPaddingP)
        {
            Point myPoint = myForm.Location;
            bool isPadding;
            //Comprueba si existe un panel SUPERIOR
            //Luego verifica si los nuevos valores no son los mismos.
            //Caso contrario, desaparece y aparece el nuevo panel.
            isPadding = padding.Top != newPaddingP.Top || border.Top != newBorderP.Top;
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
                    if (isPadding)
                    {
                        RightPanelVisible = false;
                        RightPanelVisible = true;
                        LeftPanelVisible = false;
                        LeftPanelVisible = true;
                    }
                }
            }
            else
            {
                border.Top = newBorderP.Top;
                margin.Top = newMarginP.Top;
                padding.Top = newPaddingP.Top;
                if (isPadding)
                {
                    RightPanelVisible = false;
                    RightPanelVisible = true;
                    LeftPanelVisible = false;
                    LeftPanelVisible = true;
                }
            }


            //Comprueba si existe un panel IZQUIERDO
            //Luego verifica si los nuevos valores no son los mismos.
            //Caso contrario, desaparece y aparece el nuevo panel.
            isPadding = padding.Left != newPaddingP.Left || border.Left != newBorderP.Left;
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
                    if (isPadding)
                    {
                        TopPanelVisible = false;
                        TopPanelVisible = true;
                        BottomPanelVisible = false;
                        BottomPanelVisible = true;
                    }
                }
            }
            else
            {
                border.Left = newBorderP.Left;
                margin.Left = newMarginP.Left;
                padding.Left = newPaddingP.Left;
                if (isPadding)
                {
                    TopPanelVisible = false;
                    TopPanelVisible = true;
                    BottomPanelVisible = false;
                    BottomPanelVisible = true;
                }
            }

            //Comprueba si existe un panel INFERIOR
            //Luego verifica si los nuevos valores no son los mismos.
            //Caso contrario, desaparece y aparece el nuevo panel.
            isPadding = padding.Bottom != newPaddingP.Bottom || border.Bottom != newBorderP.Bottom;
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
                    if (isPadding)
                    {
                        RightPanelVisible = false;
                        RightPanelVisible = true;
                        LeftPanelVisible = false;
                        LeftPanelVisible = true;
                    }
                }
            }
            else
            {
                border.Bottom = newBorderP.Bottom;
                margin.Bottom = newMarginP.Bottom;
                padding.Bottom = newPaddingP.Bottom;
                if (isPadding)
                {
                    RightPanelVisible = false;
                    RightPanelVisible = true;
                    LeftPanelVisible = false;
                    LeftPanelVisible = true;
                }
            }

            //Comprueba si existe un panel DERECHO
            //Luego verifica si los nuevos valores no son los mismos.
            //Caso contrario, desaparece y aparece el nuevo panel.
            isPadding = padding.Right != newPaddingP.Right || border.Right != newBorderP.Right;
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
                    if (isPadding)
                    {
                        TopPanelVisible = false;
                        TopPanelVisible = true;
                        BottomPanelVisible = false;
                        BottomPanelVisible = true;
                    }
                }
            }
            else
            {
                border.Right = newBorderP.Right;
                margin.Right = newMarginP.Right;
                padding.Right = newPaddingP.Right;
                if (isPadding)
                {
                    TopPanelVisible = false;
                    TopPanelVisible = true;
                    BottomPanelVisible = false;
                    BottomPanelVisible = true;
                }
            }

            myForm.Location = myPoint;
        }
        /// <summary>
        /// Especifica el Border. Si el elemento es igual al actual, entonces no generará cambios en la ventana.
        /// <para>Sí el panel no existe en el marco, entonces no realizará cambio a dicho panel ni creará uno nuevo.</para>
        /// </summary>
        /// <param name="newBorderP">El nuevo Border que tendrá el marco.</param>
        public void SetBorder(Rect newBorderP)
        {
            SetBorderMarginPadding(newBorderP, margin, padding);
        }
        /// <summary>
        /// Especifica el Margin. Si el elemento es igual al actual, entonces no generará cambios en la ventana.
        /// <para>Sí el panel no existe en el marco, entonces no realizará cambio a dicho panel ni creará uno nuevo.</para>
        /// </summary>
        /// <param name="newMarginP">El nuevo Margin (externo al Border) que tendrá el marco.</param>
        public void SetMargin(Rect newMarginP)
        {
            SetBorderMarginPadding(border, newMarginP, padding);
        }
        /// <summary>
        /// Especifica el Padding. Si el elemento es igual al actual, entonces no generará cambios en la ventana.
        /// <para>Sí el panel no existe en el marco, entonces no realizará cambio a dicho panel ni creará uno nuevo.</para>
        /// </summary>
        /// <param name="newPadding">El nuevo Padding (interno al Border) que tendrá el marco.</param>
        public void SetPadding(Rect newPadding)
        {
            SetBorderMarginPadding(border, margin, padding);
        }
        /// <summary>
        /// Especifica un color a una serie de paneles establecidos.
        /// </summary>
        /// <param name="panelP">Enum que contiene las posibles combinaciones de paneles. Dicha selección serán los que cambiarán el color.</param>
        /// <param name="colorP">El nuevo color que se les asignará a cada panel.</param>
        public void SetColorPanel(SelectPanel panelP, Color colorP)
        {
            List<Panel> lista = SearchPanel(panelP);
            foreach (Panel miPanel in lista)
            {
                switch ((SelectPanel)miPanel.Tag)
                {
                    case SelectPanel.Top:
                        TopColor = colorP;
                        break;
                    case SelectPanel.Bottom:
                        BottomColor = colorP;
                        break;
                    case SelectPanel.Left:
                        LeftColor = colorP;
                        break;
                    case SelectPanel.Right:
                        RightColor = colorP;
                        break;
                    case SelectPanel.CornerTopLeft:
                        TopLeftColor = colorP;
                        break;
                    case SelectPanel.CornerTopRight:
                        TopRightColor = colorP;
                        break;
                    case SelectPanel.CornerBottomLeft:
                        BottomLeftColor = colorP;
                        break;                
                    case SelectPanel.CornerBottomRight:
                        BottomRightColor = colorP;
                        break;
                }
            }
        }
        /// <summary>
        /// Comprueba si el Form está afuera de los limites del Área de Trabajo.
        /// </summary>
        /// <returns>Retorna true si la ventana está fuera de los limites.</returns>
        public bool IsWindowOutsideScreen() => myForm.Location.X < 0 ||
                myForm.Location.X + myForm.Width > Screen.PrimaryScreen.WorkingArea.Width ||
                myForm.Location.Y < 0 ||
                myForm.Location.Y + myForm.Height > Screen.PrimaryScreen.WorkingArea.Height;
        /// <summary>
        /// Verifica si el Form está afuera de los limites del Área de Trabajo.
        /// En caso de ser verdadero, entonces posicionará el Form.
        /// </summary>
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
        private void Set(string nombreVentanaP, Color colorPrimaryP, Color colorSecundaryP, Rect borderP, Rect marginP, Rect paddingP, bool botonMinimizarP, bool botonCerrarP, bool botonOpcionesP)
        {
            Destructor();
            border = new Rect(borderP);
            margin = new Rect(marginP);
            padding = new Rect(paddingP);
            colorPrimary = colorPrimaryP;
            colorSecundary = colorSecundaryP;
            nombre = nombreVentanaP;
            _isBotonMinimizar = botonMinimizarP;
            _isBotonCerrar = botonCerrarP;
            _isBotonOpciones = botonOpcionesP;

            CrearMarco();
            CrearPanelOpcionesControles();
            AddElements();
        }
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
            _panelUniversal = new Panel();
            _panelUniversal.Name = "Outline - Universal";
            _panelUniversal.Left = 0;
            _panelUniversal.Top = 0;
            _panelUniversal.Size = new Size(myForm.Width, myForm.Height);
            _panelUniversal.TabStop = false;
            _panelUniversal.BackColor = Color.Transparent;
            _panelUniversal.SendToBack();
            myForm.Controls.Add(_panelUniversal);


            //-------------------------------------------------------------
            //new panelOpciones
            //-------------------------------------------------------------
            _panelOpciones = new Panel();
            _panelOpciones.Name = "Outline - Options";
            _panelOpciones.Left = 0;
            _panelOpciones.Top = 0;
            _panelOpciones.Size = new Size(myForm.Width, myForm.Height);
            // panelInferior.MouseMove += new MouseEventHandler(panel_MouseMove);
            // panelInferior.MouseDown += new MouseEventHandler(panel_MouseDown);
            // panelInferior.MouseUp += new MouseEventHandler(panel_MouseUp);
            _panelOpciones.BackColor = colorSecundary;
            _panelOpciones.TabStop = false;
            _panelOpciones.BringToFront();
            _panelOpciones.Visible = false;
            _panelUniversal.Controls.Add(_panelOpciones);


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
            _panelDSupIzq = new Panel();
            _panelUniversal.Controls.Add(_panelDSupIzq);
            _panelDSupIzq.Tag = SelectPanel.CornerTopLeft;
            _panelDSupIzq.Name = "Outline - TopLeft";
            _panelDSupIzq.Left = _panelIzquierdo == null ? -border.Left : margin.Left;
            _panelDSupIzq.Top = _panelSuperior == null ? -border.Top : margin.Top;
            _panelDSupIzq.Size = new Size(border.Left, border.Top);
            _panelDSupIzq.BackColor = _colorSupIzq;
            _panelDSupIzq.TabStop = false;
            _panelDSupIzq.SendToBack();

            //-------------------------------------------------------------
            //new panelDSupDer
            //-------------------------------------------------------------
            _panelDSupDer = new Panel();
            _panelUniversal.Controls.Add(_panelDSupDer);
            _panelDSupDer.Tag = SelectPanel.CornerTopRight;
            _panelDSupDer.Name = "Outline - TopRight";
            _panelDSupDer.Left = _panelIzquierdo == null ? OriginalSizeWindow.Width + padding.Right : OriginalSizeWindow.Width + border.Left + margin.Left + padding.Width();
            _panelDSupDer.Top = _panelSuperior == null ? -border.Top : margin.Top;
            _panelDSupDer.Size = new Size(border.Right, border.Top);
            _panelDSupDer.BackColor = _colorSupDer;
            _panelDSupDer.TabStop = false;
            _panelDSupDer.SendToBack();

            //-------------------------------------------------------------
            //new panelDInfIzq
            //-------------------------------------------------------------
            _panelDInfIzq = new Panel();
            _panelUniversal.Controls.Add(_panelDInfIzq);
            _panelDInfIzq.Tag = SelectPanel.CornerBottomLeft;
            _panelDInfIzq.Name = "Outline - BottomLeft";
            _panelDInfIzq.Left = _panelIzquierdo == null ? -border.Left : margin.Left;
            _panelDInfIzq.Top = _panelSuperior == null ? OriginalSizeWindow.Height + padding.Bottom : OriginalSizeWindow.Height + border.Top + margin.Top + padding.Height();
            _panelDInfIzq.Size = new Size(border.Left, border.Bottom);
            _panelDInfIzq.BackColor = _colorInfIzq;
            _panelDInfIzq.TabStop = false;
            _panelDInfIzq.SendToBack();

            //-------------------------------------------------------------
            //new panelDInfDer
            //-------------------------------------------------------------
            _panelDInfDer = new Panel();
            _panelUniversal.Controls.Add(_panelDInfDer);
            _panelDInfDer.Tag = SelectPanel.CornerBottomRight;
            _panelDInfDer.Name = "Outline - BottomRight";
            _panelDInfDer.Left = _panelIzquierdo == null ? OriginalSizeWindow.Width + padding.Right : OriginalSizeWindow.Width + border.Left + margin.Left + padding.Width();
            _panelDInfDer.Top = _panelSuperior == null ? OriginalSizeWindow.Height + padding.Bottom : OriginalSizeWindow.Height + border.Top + margin.Top + padding.Height();
            _panelDInfDer.Size = new Size(border.Right, border.Bottom);
            _panelDInfDer.BackColor = _colorInfDer;
            _panelDInfDer.TabStop = false;
            _panelDInfDer.SendToBack();



            //-------------------------------------------------------------
            //final details
            //-------------------------------------------------------------
            _panelSuperior.BringToFront();
            _panelCentro.SendToBack();
            SetLocation();
        }
        private void CrearPanelOpcionesControles()
        {

        }
        private void CrearBotonCerrar()
        {
            if (_isBotonCerrar)
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
                BotonCerrar.Left = _panelDerecho != null ? _panelSuperior.Width - 40 : _panelSuperior.Width - 40 - padding.Right;
                BotonCerrar.Click += new EventHandler(cerrar_Click);
                BotonCerrar.BringToFront();
                BotonCerrar.TabStop = false;
                _panelSuperior.Controls.Add(BotonCerrar);
            }
        }
        private void CrearBotonMinimizar()
        {
            if (_isBotonMinimizar)
            {
                BotonMinimizar = new Button();
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(BotonMinimizar, "Minimiza la ventana");
                BotonMinimizar.Text = "-";
                BotonMinimizar.BackColor = Color.LightGray;
                BotonMinimizar.FlatStyle = FlatStyle.Flat;
                BotonMinimizar.Size = new Size(35, 25);
                BotonMinimizar.Top = 10;
                BotonMinimizar.Left = _panelDerecho != null ? _panelSuperior.Width - 80 : _panelSuperior.Width - 80 - padding.Right;
                BotonMinimizar.Click += new EventHandler(minimizar_Click);
                BotonMinimizar.BringToFront();
                BotonMinimizar.TabStop = false;
                _panelSuperior.Controls.Add(BotonMinimizar);
            }
        }
        private void CrearBotonOpciones()
        {
            if (_isBotonOpciones)
            {
                BotonOpciones = new Button();
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(BotonOpciones, "Opciones...");
                BotonOpciones.Text = "v";
                BotonOpciones.BackColor = Color.DarkGray;
                BotonOpciones.FlatStyle = FlatStyle.Flat;
                BotonOpciones.Size = new Size(35, 25);
                BotonOpciones.Top = 10;
                BotonOpciones.Left = _panelDerecho != null ? _panelSuperior.Width - 120 : _panelSuperior.Width - 120 - padding.Right;
                BotonOpciones.Click += new EventHandler(opciones_Click);
                BotonOpciones.BringToFront();
                BotonOpciones.TabStop = false;
                _panelSuperior.Controls.Add(BotonOpciones);
            }
        }
        private void CrearLabelTexto()
        {
            NombreVentana = new Label();
            _panelSuperior.Controls.Add(NombreVentana);
            NombreVentana.BackColor = colorSecundary;
            NombreVentana.Text = nombre;
            NombreVentana.AutoSize = true;
            NombreVentana.Font = new Font(FontFamily.GenericSerif, 25.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            NombreVentana.Top = _panelSuperior.Height - NombreVentana.Height;
            NombreVentana.Left = _panelIzquierdo != null ? 10 : 10 + padding.Left;
            NombreVentana.BringToFront();
        }
        private bool AddElement(Control controlP)
        {
            if (!Object.ReferenceEquals(null, controlP) && !_panelCentro.Controls.Contains(controlP))
            {
                _panelCentro.Controls.Add(controlP);
                return true;
            }
            return false;
        }
        private void AddElements()
        {
            for (int i=0; i<myForm.Controls.Count;i++)
            {
                if (myForm.Controls[i] != _panelUniversal)
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
            if (_panelDSupIzq != null)
            {
                _panelDSupIzq.Left = _panelIzquierdo == null ? -border.Left : margin.Left;
                _panelDSupIzq.Top = _panelSuperior == null ? -border.Top : margin.Top;
                _panelDSupIzq.Size = new Size(border.Left, border.Top);
            }
            if (_panelDSupDer != null)
            {
                _panelDSupDer.Left = _panelIzquierdo == null ? OriginalSizeWindow.Width + padding.Right : OriginalSizeWindow.Width + border.Left + margin.Left + padding.Width();
                _panelDSupDer.Top = _panelSuperior == null ? -border.Top : margin.Top;
                _panelDSupDer.Size = new Size(border.Right, border.Top);
            }
            if (_panelDInfDer != null)
            {
                _panelDInfDer.Left = _panelIzquierdo == null ? OriginalSizeWindow.Width + padding.Right : OriginalSizeWindow.Width + border.Left + margin.Left + padding.Width();
                _panelDInfDer.Top = _panelSuperior == null ? OriginalSizeWindow.Height + padding.Bottom : OriginalSizeWindow.Height + border.Top + margin.Top + padding.Height();
                _panelDInfDer.Size = new Size(border.Right, border.Bottom);
            }
            if (_panelDInfIzq != null)
            {
                _panelDInfIzq.Left = _panelIzquierdo == null ? -border.Left : margin.Left;
                _panelDInfIzq.Top = _panelSuperior == null ? OriginalSizeWindow.Height + padding.Bottom : OriginalSizeWindow.Height + border.Top + margin.Top + padding.Height();
                _panelDInfIzq.Size = new Size(border.Left, border.Bottom);
            }
        }
        private List<Panel> SearchPanel(SelectPanel panelP)
        {
            List<Panel> panelesRetorno = new List<Panel>();
            int numeroOpcion = (int)panelP;


            if (numeroOpcion >= 128) //EsquinaInferiorIzquierdo
            {
                panelesRetorno.Add(_panelDInfIzq);
                numeroOpcion -= 128;
            }
            if (numeroOpcion >= 64) //EsquinaInferiorDerecho
            {
                panelesRetorno.Add(_panelDInfDer);
                numeroOpcion -= 64;
            }
            if (numeroOpcion >= 32) //EsquinaSuperiorIzquierdo
            {
                panelesRetorno.Add(_panelDSupIzq);
                numeroOpcion -= 32;
            }
            if (numeroOpcion >= 16) //EsquinaSuperiorDerecho
            {
                panelesRetorno.Add(_panelDSupDer);
                numeroOpcion -= 16;
            }
            if (numeroOpcion >= 8) //Inferior
            {
                panelesRetorno.Add(_panelInferior);
                numeroOpcion -= 8;
            }
            if (numeroOpcion >= 4) //Superior
            {
                panelesRetorno.Add(_panelSuperior);
                numeroOpcion -= 4;
            }
            if (numeroOpcion >= 2) //Derecho
            {
                panelesRetorno.Add(_panelDerecho);
                numeroOpcion -= 2;
            }
            if (numeroOpcion >= 1) //Izquierdo
            {
                panelesRetorno.Add(_panelIzquierdo);
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
            _panelOpciones.Location = new Point(0, -myForm.Height);
            _panelOpciones.BringToFront();
            _panelOpciones.Visible = true;
            timerPanelOpciones.Enabled = true;
        }
        private void timerPanelCompleto_Tick(object sender, EventArgs e)
        {
            _panelOpciones.Location = new Point(0, _panelOpciones.Location.Y + velocidadAnimacion);
            if (_panelOpciones.Location.Y + _panelOpciones.Height > myForm.Height - velocidadAnimacion)
            {
                _panelOpciones.Location = new Point(0, 0);
                timerPanelOpciones.Enabled = false;
            }
        }
        #endregion
    }
}
