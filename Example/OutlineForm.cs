using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FormDecoration
{
    /// <summary>
    /// Crea un contorno dinamico de manera automatica alrededor del Form.
    /// </summary>
    public partial class OutlineForm 
    {
        #region OF_Extra
        [Serializable]
        public class ExceptionOutlineForm : Exception
        {
            public ExceptionOutlineForm(string exceptionMode)
            : base(String.Format("Se produjo una excepcion: {0}", exceptionMode))
            {

            }
        }
        public enum SelectedPanel {
            /// <summary>
            /// Panel izquierdo.
            /// </summary>
            Izquierdo = 1,
            /// <summary>
            /// Panel derecho.
            /// </summary>
            Derecho = 2,
            /// <summary>
            /// Panel superior.
            /// </summary>
            Superior = 4,
            /// <summary>
            /// Panel inferior.
            /// </summary>
            Inferior = 8,
            /// <summary>
            /// Panel superior y panel derecho. No incluye esquinas.
            /// </summary>
            EsquinaSuperiorDerecho = 16,
            /// <summary>
            /// Panel superior y panel izquierdo. No incluye esquinas.
            /// </summary>
            EsquinaSuperiorIzquierdo = 32,
            /// <summary>
            /// Panel inferior y panel derecho. No incluye esquinas.
            /// </summary>
            EsquinaInferiorDerecho = 64,
            /// <summary>
            /// Panel inferior y panel izquierdo. No incluye esquinas.
            /// </summary>
            EsquinaInferiorIzquierdo = 128,

            SuperiorDerecho = 6,
            SuperiorIzquierdo = 5,
            InferiorDerecho = 10,
            InferiorIzquierdo = 9,
            LadosHorizontales = 12,
            LadosVerticales = 3,
            Todos = 15,
            TodosExceptoDerecho = 13,
            TodosExceptoIzquierdo = 14,
            TodosExceptoSuperior = 11,
            TodosExceptoInferior = 7,


            Izquierdo_ConEsquinas = 161,
            Derecho_ConEsquinas = 82,
            Superior_ConEsquinas = 52,
            Inferior_ConEsquinas = 200,
            SuperiorDerecho_ConEsquinas = 22,
            SuperiorIzquierdo_ConEsquinas = 37,
            InferiorDerecho_ConEsquinas = 74,
            InferiorIzquierdo_ConEsquinas = 137,
            SoloEsquinas = 240,
            LadosHorizontales_ConEsquinas = 252,
            LadosVerticales_ConEsquinas = 243,

            Todos_ConEsquinas = 255,
            TodosExceptoDerecho_ConEsquinas = 253,
            TodosExceptoIzquierdo_ConEsquinas = 254,
            TodosExpectoSuperior_ConEsquinas = 251,
            TodosExceptoInferior_ConEsquinas = 247
        };
        #endregion

        #region OF_Variables
        public static readonly string version = "0.2.4";
        static List<Form> listaForms = new List<Form>();
        Size OriginalSizeWindow = Size.Empty;
        FormBorderStyle OriginalFormBorderStyle;

        Rect border; //Define el tamaño del contorno.
        Rect margin; //Define el margin del contorno.
        Rect padding; //Define el padding del contorno.

        Color colorPrimary; //Color del border.
        

        Color _colorIzquierdo = Color.Black;
        Color _colorDerecho = Color.Black;
        Color _colorSuperior = Color.Black;
        Color _colorInferior = Color.Black;
        Color _colorSupDer = Color.Black;
        Color _colorSupIzq = Color.Black;
        Color _colorInfDer = Color.Black;
        Color _colorInfIzq = Color.Black;
        Color colorSecundary; //Color del contenido del border.

        string nombre; //Nombre actual de la ventana.
        bool _isPanelIzquierdo = true; //Verifica si existe el panel izquierdo.
        bool _isPanelDerecho = true; //Verifica si existe el panel derecho.
        bool _isPanelSuperior = true; //Verifica si existe el panel superior.
        bool _isPanelInferior = true; //Verifica si existe el panel inferior.
        bool _isBotonCerrar = true;
        bool _isBotonMinimizar = true;
        bool _isBotonOpciones = true;

        bool isSosteniendo; //Variable para controlar el movimiento del mouse.
        int movX; //Posicion en X del mouse.
        int movY; //Posicion en Y del mouse.
        int velocidadAnimacion = 30; //Velocidad de la animacion del Panel Completo.
        int dirAnimacion = 0; //Direccion de la animacion del Panel Completo.
       
        Form myForm; //Form a controlar.
        public Button BotonCerrar; //Boton de cerrar. Es pública en caso de agregar mas eventos.
        public Button BotonMinimizar; //Boton de minimizar. Es pública en caso de agregar mas eventos.
        public Button BotonOpciones; //Boton que muestra las opciones. Es pública en caso de agregar mas eventos.
        Label NombreVentana; //Label con el nombre de la ventana.

        Panel _panelUniversal; //Panel que contiene a todos los paneles. Esto es por seguridad en caso de hacer un foreach con los controles del myForm.
        Panel _panelSuperior; //Panel superior, mas grande que el resto de paneles.
        Panel _panelIzquierdo; //Panel izquierdo.
        Panel _panelDerecho; //Panel derecho.
        Panel _panelInferior; //Panel inferior.
        Panel _panelDSupDer; //Panel diagonal superior derecho.
        Panel _panelDSupIzq; //Panel diagonal superior izquierdo.
        Panel _panelDInfDer; //Panel diagonal inferior derecho.
        Panel _panelDInfIzq; //Panel diagonal inferior izquierdo.
        Panel _panelOpciones; //Panel que cubre todo el Form.
        Panel _panelCentro; //Panel que cubre el centro de los demas paneles. Sirve para adaptar el contenido
        Timer timerPanelOpciones; //Timer que servirá para hacer una animación de aparición del Panel Completo.
        #endregion

        #region OF_Propiedades
        /// <summary>
        /// Cambia la cantidad de pixeles que se moverá el panelSuperior de transición al presionar el boton de opciones.
        /// </summary>
        public int TransitionSpeed
        {
            set
            {
                velocidadAnimacion = 0;
                if (value > 0)
                    velocidadAnimacion = value;
                if (value > 300)
                    velocidadAnimacion = 300;
            }
        }
        /// <summary>
        /// Obtiene o declara el nombre de la ventana.
        /// </summary>
        public string Title
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
                NombreVentana.Text = value;
            }
        }
        /// <summary>
        /// Obtiene o declara las medidas internas del contorno.
        /// </summary>
        public Rect Padding
        {
            get
            {
                return padding;
            }
        }
        /// <summary>
        /// Obtiene o declara las medidas externas del contorno.
        /// </summary>
        public Rect Margin
        {
            get
            {
                return margin;
            }
        }
        /// <summary>
        /// Obtiene o declara las medidas del contorno.
        /// </summary>
        public Rect Border
        {
            get
            {
                return border;
            }
        }

        #region B_P_Paneles
        /// <summary>
        /// Define la creación del panel izquierdo por completo.
        /// </summary>
        public bool LeftPanelVisible
        {
            get
            {
                return _isPanelIzquierdo;
            }
            set
            {
                _isPanelIzquierdo = value;
                if (value)
                {
                    if (_panelIzquierdo == null)
                    {
                        myForm.Size = new Size(myForm.Width + border.Left + margin.Left + padding.Left, myForm.Height);
                        myForm.Location = new Point(myForm.Location.X - border.Left - margin.Left - padding.Left, myForm.Location.Y);
                        _panelUniversal.Size = new Size(myForm.Width, myForm.Height); 
                        _panelOpciones.Size = new Size(myForm.Width, myForm.Height);
                        if (_panelDerecho != null)
                            _panelDerecho.Location = new Point(_panelDerecho.Location.X + border.Left + margin.Left + padding.Left,_panelDerecho.Location.Y);
                        if (_panelSuperior != null)
                            _panelSuperior.Location = new Point(_panelSuperior.Location.X + border.Left + margin.Left + padding.Left, _panelSuperior.Location.Y);
                        if (_panelInferior != null)                                                                 
                            _panelInferior.Location = new Point(_panelInferior.Location.X + border.Left + margin.Left + padding.Left, _panelInferior.Location.Y);
                        if (_panelCentro != null)
                            _panelCentro.Location = new Point(border.Left + margin.Left + padding.Left, _panelCentro.Location.Y);

                        _panelIzquierdo = new Panel();
                        _panelUniversal.Controls.Add(_panelIzquierdo);
                        _panelIzquierdo.Tag = SelectedPanel.Izquierdo;
                        _panelIzquierdo.Name = "Outline - Left";
                        _panelIzquierdo.Left = margin.Left;
                        _panelIzquierdo.Top = _panelSuperior == null ? -padding.Top : border.Top + margin.Top;
                        _panelIzquierdo.Size = new Size(border.Left, OriginalSizeWindow.Height + padding.Height());
                        // panelIzquierdo.MouseMove += new MouseEventHandler(panel_MouseMove);
                        // panelIzquierdo.MouseDown += new MouseEventHandler(panel_MouseDown);
                        // panelIzquierdo.MouseUp += new MouseEventHandler(panel_MouseUp);
                        _panelIzquierdo.BackColor = _colorIzquierdo;
                        _panelIzquierdo.TabStop = false;
                        _panelIzquierdo.SendToBack();
                        //panelIzquierdo.Visible = false;

                        if (NombreVentana != null)
                        {
                            NombreVentana.Left = 10;
                        }
                    }
                }
                else
                {
                    if (_panelIzquierdo != null)
                    {
                        _panelIzquierdo.Dispose();
                        _panelIzquierdo = null;
                        myForm.Size = new Size(_panelDerecho == null ? OriginalSizeWindow.Width : OriginalSizeWindow.Width + padding.Right + margin.Right + border.Right, myForm.Height);
                        myForm.Location = new Point(myForm.Location.X + border.Left + margin.Left + padding.Left, myForm.Location.Y);
                        _panelUniversal.Size = new Size(myForm.Width, myForm.Height);
                        _panelOpciones.Size = new Size(myForm.Width, myForm.Height);

                        if (_panelDerecho != null)
                            _panelDerecho.Location = new Point(_panelDerecho.Location.X - border.Left - margin.Left - padding.Left, _panelDerecho.Location.Y);
                        if (_panelSuperior != null)
                            _panelSuperior.Location = new Point(_panelSuperior.Location.X - border.Left - margin.Left - padding.Left, _panelSuperior.Location.Y);
                        if (_panelInferior != null)                                                                
                            _panelInferior.Location = new Point(_panelInferior.Location.X - border.Left - margin.Left - padding.Left, _panelInferior.Location.Y);
                        _panelCentro.Location = new Point(0, _panelCentro.Location.Y);

                        if (NombreVentana != null)
                        {
                            NombreVentana.Left += padding.Left;
                        }
                    }
                }
                AcomodarEsquinas();
            }
        }
        /// <summary>
        /// Define la creación del panel derecho por completo.
        /// </summary>
        public bool RightPanelVisible
        {
            get
            {
                return _isPanelDerecho;
            }
            set
            {
                _isPanelDerecho = value;
                if (value)
                {
                    if (_panelDerecho == null)
                    {
                        myForm.Size = new Size(myForm.Width + border.Right + margin.Right + padding.Right, myForm.Height);
                        _panelUniversal.Size = new Size(myForm.Width, myForm.Height);
                        _panelOpciones.Size = new Size(myForm.Width, myForm.Height);

                        _panelDerecho = new Panel();
                        _panelUniversal.Controls.Add(_panelDerecho);
                        _panelDerecho.Tag = SelectedPanel.Derecho;
                        _panelDerecho.Name = "Outline - Right";
                        _panelDerecho.Left = _panelIzquierdo == null ? OriginalSizeWindow.Width + padding.Right : OriginalSizeWindow.Width + padding.Width() + border.Left + margin.Left;
                        _panelDerecho.Top = _panelSuperior == null ? -padding.Top : border.Top + margin.Top;
                        _panelDerecho.Size = new Size(border.Right, OriginalSizeWindow.Height + padding.Height());
                        _panelDerecho.MouseHover += new EventHandler(panel_Resize_MouseHover);
                        _panelDerecho.MouseLeave += new EventHandler(panel_Resize_MouseLeave);
                        // panelDerecho.MouseMove += new MouseEventHandler(panel_MouseMove);
                        // panelDerecho.MouseDown += new MouseEventHandler(panel_MouseDown);
                        // panelDerecho.MouseUp += new MouseEventHandler(panel_MouseUp);
                        _panelDerecho.BackColor = _colorDerecho;
                        _panelDerecho.TabStop = false;
                        _panelDerecho.SendToBack();
                        //panelDerecho.Visible = false;

                        if (BotonCerrar != null)
                        {
                            BotonCerrar.Left = _panelSuperior.Width - 40;
                        }
                        if (BotonMinimizar != null)
                        {
                            BotonMinimizar.Left = _panelSuperior.Width - 80;
                        }
                        if (BotonOpciones != null)
                        {
                            BotonOpciones.Left = _panelSuperior.Width - 120;
                        }
                    }
                }
                else
                {
                    if (_panelDerecho != null)
                    {
                        _panelDerecho.Dispose();
                        _panelDerecho = null;
                        myForm.Size = new Size(myForm.Width - border.Right - margin.Right - padding.Right, myForm.Height);
                        _panelUniversal.Size = new Size(myForm.Width, myForm.Height);
                        _panelOpciones.Size = new Size(myForm.Width, myForm.Height);

                        if (BotonCerrar != null)
                        {
                            BotonCerrar.Left -= padding.Right;
                        }
                        if (BotonMinimizar != null)
                        {
                            BotonMinimizar.Left -= padding.Right;
                        }
                        if (BotonOpciones != null)
                        {        
                            BotonOpciones.Left -= padding.Right;
                        }
                    }
                }
                AcomodarEsquinas();
            }
        }
        /// <summary>
        /// Define la creación del panel inferior por completo.
        /// </summary>
        public bool BottomPanelVisible
        {
            get
            {
                return _isPanelInferior;
            }
            set
            {
                _isPanelInferior = value;
                if (value)
                {
                    if (_panelInferior == null)
                    {
                        myForm.Size = new Size(myForm.Width, myForm.Height + border.Bottom + margin.Bottom + padding.Bottom);
                        _panelUniversal.Size = new Size(myForm.Width, myForm.Height);
                        _panelOpciones.Size = new Size(myForm.Width, myForm.Height);

                        _panelInferior = new Panel();
                        _panelUniversal.Controls.Add(_panelInferior);
                        _panelInferior.Tag = SelectedPanel.Inferior;
                        _panelInferior.Name = "Outline - Bottom";
                        _panelInferior.Left = _panelIzquierdo == null ? -padding.Left : border.Left + margin.Left;
                        _panelInferior.Top = _panelSuperior == null ? OriginalSizeWindow.Height + padding.Bottom : OriginalSizeWindow.Height + padding.Height() + border.Top + margin.Top;
                        _panelInferior.Size = new Size(OriginalSizeWindow.Width + padding.Width(), border.Bottom);
                        // panelInferior.MouseMove += new MouseEventHandler(panel_MouseMove);
                        // panelInferior.MouseDown += new MouseEventHandler(panel_MouseDown);
                        // panelInferior.MouseUp += new MouseEventHandler(panel_MouseUp);
                        _panelInferior.BackColor = _colorInferior;
                        _panelInferior.TabStop = false;
                        _panelInferior.SendToBack();
                        //panelInferior.Visible = false;
                    }
                }
                else
                {
                    if (_panelInferior != null)
                    {
                        _panelInferior.Dispose();
                        _panelInferior = null;
                        myForm.Size = new Size(myForm.Width, myForm.Height - border.Bottom - margin.Bottom - padding.Bottom);
                        _panelUniversal.Size = new Size(myForm.Width, myForm.Height);
                        _panelOpciones.Size = new Size(myForm.Width, myForm.Height);

                        if (_panelDerecho != null)
                        {
                            //panelDerecho.Size = new Size(panelDerecho.Width, panelDerecho.Height - border.Bottom );
                        }
                        if (_panelIzquierdo != null)
                        {
                            //panelIzquierdo.Size = new Size(panelIzquierdo.Width, panelIzquierdo.Height - border.Bottom);
                        }
                    }
                }
                AcomodarEsquinas();
            }
        }
        /// <summary>
        /// Define la creación del panel superior por completo.
        /// </summary>
        public bool TopPanelVisible
        {
            get
            {
                return _isPanelSuperior;
            }
            set
            {
                _isPanelSuperior = value;
                if (value)
                {
                    if (_panelSuperior == null)
                    {
                        myForm.Size = new Size(myForm.Width, myForm.Height + border.Top + margin.Top + padding.Top);
                        myForm.Location = new Point(myForm.Location.X, myForm.Location.Y - border.Top - margin.Top - padding.Top);
                        _panelUniversal.Size = new Size(myForm.Width, myForm.Height);
                        _panelOpciones.Size = new Size(myForm.Width, myForm.Height);
                        if (_panelInferior != null)
                            _panelInferior.Location = new Point(_panelInferior.Location.X , _panelInferior.Location.Y + border.Top + margin.Top + padding.Top);
                        if (_panelDerecho != null)
                            _panelDerecho.Location = new Point(_panelDerecho.Location.X, _panelDerecho.Location.Y + border.Top + margin.Top + padding.Top);
                        if (_panelIzquierdo != null)
                            _panelIzquierdo.Location = new Point(_panelIzquierdo.Location.X, _panelIzquierdo.Location.Y + border.Top + margin.Top + padding.Top);
                        if (_panelCentro != null)
                            _panelCentro.Location = new Point(_panelCentro.Location.X, _panelCentro.Location.Y + border.Top + margin.Top + padding.Top);


                        _panelSuperior = new Panel();
                        _panelUniversal.Controls.Add(_panelSuperior);
                        _panelSuperior.Tag = SelectedPanel.Superior;
                        _panelSuperior.Name = "Outline - Top";
                        _panelSuperior.Left = _panelIzquierdo == null ? -padding.Left : border.Left + margin.Left;
                        _panelSuperior.Top = margin.Top;
                        _panelSuperior.Size = new Size(OriginalSizeWindow.Width + padding.Width(), border.Top);
                        _panelSuperior.MouseMove += new MouseEventHandler(panel_MouseMove);
                        _panelSuperior.MouseDown += new MouseEventHandler(panel_MouseDown);
                        _panelSuperior.MouseUp += new MouseEventHandler(panel_MouseUp);
                        _panelSuperior.BackColor = _colorSuperior;
                        _panelSuperior.TabStop = false;
                        _panelSuperior.SendToBack();
                        //panelSuperior.Visible = false;

                        CrearBotonMinimizar();
                        CrearBotonCerrar();
                        CrearBotonOpciones();
                        CrearLabelTexto();
                    }
                }
                else
                {
                    if (_panelSuperior != null)
                    {
                        _panelSuperior.Dispose();
                        _panelSuperior = null;
                        myForm.Size = new Size(myForm.Width, _panelInferior == null ? OriginalSizeWindow.Height : OriginalSizeWindow.Height + padding.Bottom + margin.Bottom + border.Bottom  );
                        myForm.Location = new Point(myForm.Location.X, myForm.Location.Y + border.Top + margin.Top + padding.Top);
                        _panelUniversal.Size = new Size(myForm.Width, myForm.Height);
                        _panelOpciones.Size = new Size(myForm.Width, myForm.Height);

                        if (_panelInferior != null)
                            _panelInferior.Location = new Point(_panelInferior.Location.X, _panelInferior.Location.Y - border.Top - margin.Top - padding.Top);
                        if (_panelDerecho != null)
                            _panelDerecho.Location = new Point(_panelDerecho.Location.X, _panelDerecho.Location.Y - border.Top - margin.Top - padding.Top);
                        if (_panelIzquierdo != null)
                            _panelIzquierdo.Location = new Point(_panelIzquierdo.Location.X, _panelIzquierdo.Location.Y - border.Top - margin.Top - padding.Top);
                        _panelCentro.Location = new Point(_panelCentro.Location.X, 0);
                    }
                }
                AcomodarEsquinas();
            }
        }      
        private bool CenterPanelVisible
        {
            set
            {
                _panelCentro = new Panel();
                _panelUniversal.Controls.Add(_panelCentro);
                _panelCentro.Name = "Outline - Center";
                _panelCentro.Left = _panelIzquierdo != null ? _panelIzquierdo.Right + padding.Left : 0;
                _panelCentro.Top = _panelSuperior != null ? _panelSuperior.Bottom + padding.Top : 0;
                _panelCentro.Size = new Size
                    (
                        OriginalSizeWindow.Width,
                        OriginalSizeWindow.Height
                    );
                _panelCentro.BackColor = colorSecundary;
                _panelCentro.TabStop = false;
                _panelCentro.SendToBack();

            }
        }

        public Color LeftColor
        {
            get => _colorIzquierdo;
            private set => _colorIzquierdo = _panelIzquierdo.BackColor = value;
        }
        public Color RightColor
        {
            get => _colorDerecho;
            private set => _colorDerecho = _panelDerecho.BackColor = value;
        }
        public Color TopColor
        {
            get => _colorSuperior;
            private set => _colorSuperior = _panelSuperior.BackColor = value;
        }
        public Color BottomColor
        {
            get => _colorInferior;
            private set => _colorInferior = _panelInferior.BackColor = value;
        }
        public Color TopLeftColor
        {
            get => _colorSupIzq;
            private set => _colorSupIzq = _panelDSupIzq.BackColor = value;
        }
        public Color TopRightColor
        {
            get => _colorSupDer;
            private set => _colorSupDer = _panelDSupDer.BackColor = value;
        }
        public Color BottomLeftColor
        {
            get => _colorInfIzq;
            private set => _colorInfIzq = _panelDInfIzq.BackColor = value;
        }
        public Color BottomRightColor
        {
            get => _colorInfDer;
            private set => _colorInfDer = _panelDInfDer.BackColor = value;
        }
        #endregion
        #endregion
    }
}
