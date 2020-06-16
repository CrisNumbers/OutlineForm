using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OutlineForm_Example
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
        static List<Form> listaForms = new List<Form>();
        Size OriginalSizeWindow = Size.Empty;
        FormBorderStyle OriginalFormBorderStyle;

        Rect border; //Define el tamaño del contorno.
        Rect margin; //Define el margin del contorno.
        Rect padding; //Define el padding del contorno.

        Color colorPrimary; //Color del border.
        Color colorIzquierdo = Color.Black;
        Color colorDerecho = Color.Black;
        Color colorSuperior = Color.Black;
        Color colorInferior = Color.Black;
        Color colorSupDer = Color.Black;
        Color colorSupIzq = Color.Black;
        Color colorInfDer = Color.Black;
        Color colorInfIzq = Color.Black;
        Color colorSecundary; //Color del contenido del border.

        string nombre; //Nombre actual de la ventana.
        bool _isPanelIzquierdo = true; //Verifica si existe el panel izquierdo.
        bool _isPanelDerecho = true; //Verifica si existe el panel derecho.
        bool _isPanelSuperior = true; //Verifica si existe el panel superior.
        bool _isPanelInferior = true; //Verifica si existe el panel inferior.

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

        Panel panelUniversal; //Panel que contiene a todos los paneles. Esto es por seguridad en caso de hacer un foreach con los controles del myForm.
        Panel panelSuperior; //Panel superior, mas grande que el resto de paneles.
        Panel panelIzquierdo; //Panel izquierdo.
        Panel panelDerecho; //Panel derecho.
        Panel panelInferior; //Panel inferior.
        Panel panelDSupDer; //Panel diagonal superior derecho.
        Panel panelDSupIzq; //Panel diagonal superior izquierdo.
        Panel panelDInfDer; //Panel diagonal inferior derecho.
        Panel panelDInfIzq; //Panel diagonal inferior izquierdo.
        Panel panelOpciones; //Panel que cubre todo el Form.
        Panel panelCentro; //Panel que cubre el centro de los demas paneles. Sirve para adaptar el contenido
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
        public string Titulo
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
                    if (panelIzquierdo == null)
                    {
                        myForm.Size = new Size(myForm.Width + border.Left + margin.Left + padding.Left, myForm.Height);
                        myForm.Location = new Point(myForm.Location.X - border.Left - margin.Left - padding.Left, myForm.Location.Y);
                        panelUniversal.Size = new Size(myForm.Width, myForm.Height); 
                        panelOpciones.Size = new Size(myForm.Width, myForm.Height);
                        if (panelDerecho != null)
                            panelDerecho.Location = new Point(panelDerecho.Location.X + border.Left + margin.Left + padding.Left,panelDerecho.Location.Y);
                        if (panelSuperior != null)
                            panelSuperior.Location = new Point(panelSuperior.Location.X + border.Left + margin.Left + padding.Left, panelSuperior.Location.Y);
                        if (panelInferior != null)                                                                 
                            panelInferior.Location = new Point(panelInferior.Location.X + border.Left + margin.Left + padding.Left, panelInferior.Location.Y);
                        if (panelCentro != null)
                            panelCentro.Location = new Point(border.Left + margin.Left + padding.Left, panelCentro.Location.Y);

                        panelIzquierdo = new Panel();
                        panelUniversal.Controls.Add(panelIzquierdo);
                        panelIzquierdo.Name = "Outline - Left";
                        panelIzquierdo.Left = margin.Left;
                        panelIzquierdo.Top = panelSuperior == null ? -padding.Top : border.Top + margin.Top;
                        panelIzquierdo.Size = new Size(border.Left, OriginalSizeWindow.Height + padding.Height());
                        // panelIzquierdo.MouseMove += new MouseEventHandler(panel_MouseMove);
                        // panelIzquierdo.MouseDown += new MouseEventHandler(panel_MouseDown);
                        // panelIzquierdo.MouseUp += new MouseEventHandler(panel_MouseUp);
                        panelIzquierdo.BackColor = colorIzquierdo;
                        panelIzquierdo.TabStop = false;
                        panelIzquierdo.SendToBack();
                        //panelIzquierdo.Visible = false;
                    }
                }
                else
                {
                    if (panelIzquierdo != null)
                    {
                        panelIzquierdo.Dispose();
                        panelIzquierdo = null;
                        myForm.Size = new Size(panelDerecho == null ? OriginalSizeWindow.Width : OriginalSizeWindow.Width + padding.Right + margin.Right + border.Right, myForm.Height);
                        myForm.Location = new Point(myForm.Location.X + border.Left + margin.Left + padding.Left, myForm.Location.Y);
                        panelUniversal.Size = new Size(myForm.Width, myForm.Height);
                        panelOpciones.Size = new Size(myForm.Width, myForm.Height);

                        if (panelDerecho != null)
                            panelDerecho.Location = new Point(panelDerecho.Location.X - border.Left - margin.Left - padding.Left, panelDerecho.Location.Y);
                        if (panelSuperior != null)
                            panelSuperior.Location = new Point(panelSuperior.Location.X - border.Left - margin.Left - padding.Left, panelSuperior.Location.Y);
                        if (panelInferior != null)                                                                
                            panelInferior.Location = new Point(panelInferior.Location.X - border.Left - margin.Left - padding.Left, panelInferior.Location.Y);
                        panelCentro.Location = new Point(0, panelCentro.Location.Y);
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
                    if (panelDerecho == null)
                    {
                        myForm.Size = new Size(myForm.Width + border.Right + margin.Right + padding.Right, myForm.Height);
                        panelUniversal.Size = new Size(myForm.Width, myForm.Height);
                        panelOpciones.Size = new Size(myForm.Width, myForm.Height);

                        panelDerecho = new Panel();
                        panelUniversal.Controls.Add(panelDerecho);
                        panelDerecho.Name = "Outline - Right";
                        panelDerecho.Left = panelIzquierdo == null ? OriginalSizeWindow.Width + padding.Right : OriginalSizeWindow.Width + padding.Width() + border.Left + margin.Left;
                        panelDerecho.Top = panelSuperior == null ? -padding.Top : border.Top + margin.Top;
                        panelDerecho.Size = new Size(border.Right, OriginalSizeWindow.Height + padding.Height());
                        panelDerecho.MouseHover += new EventHandler(panel_Resize_MouseHover);
                        panelDerecho.MouseLeave += new EventHandler(panel_Resize_MouseLeave);
                        // panelDerecho.MouseMove += new MouseEventHandler(panel_MouseMove);
                        // panelDerecho.MouseDown += new MouseEventHandler(panel_MouseDown);
                        // panelDerecho.MouseUp += new MouseEventHandler(panel_MouseUp);
                        panelDerecho.BackColor = colorDerecho;
                        panelDerecho.TabStop = false;
                        panelDerecho.SendToBack();
                        //panelDerecho.Visible = false;
                    }
                }
                else
                {
                    if (panelDerecho != null)
                    {
                        panelDerecho.Dispose();
                        panelDerecho = null;
                        myForm.Size = new Size(myForm.Width - border.Right - margin.Right - padding.Right, myForm.Height);
                        panelUniversal.Size = new Size(myForm.Width, myForm.Height);
                        panelOpciones.Size = new Size(myForm.Width, myForm.Height);

                        if (panelSuperior != null)
                        {
                          //  panelSuperior.Size = new Size(panelSuperior.Width - border.Right, panelSuperior.Height);
                        }
                        if (panelInferior != null)
                        {
                           // panelInferior.Size = new Size(panelInferior.Width - border.Right, panelInferior.Height );
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
                    if (panelInferior == null)
                    {
                        myForm.Size = new Size(myForm.Width, myForm.Height + border.Bottom + margin.Bottom + padding.Bottom);
                        panelUniversal.Size = new Size(myForm.Width, myForm.Height);
                        panelOpciones.Size = new Size(myForm.Width, myForm.Height);

                        panelInferior = new Panel();
                        panelUniversal.Controls.Add(panelInferior);
                        panelInferior.Name = "Outline - Bottom";
                        panelInferior.Left = panelIzquierdo == null ? -padding.Left : border.Left + margin.Left;
                        panelInferior.Top = panelSuperior == null ? OriginalSizeWindow.Height + padding.Bottom : OriginalSizeWindow.Height + padding.Height() + border.Top + margin.Top;
                        panelInferior.Size = new Size(OriginalSizeWindow.Width + padding.Width(), border.Bottom);
                        // panelInferior.MouseMove += new MouseEventHandler(panel_MouseMove);
                        // panelInferior.MouseDown += new MouseEventHandler(panel_MouseDown);
                        // panelInferior.MouseUp += new MouseEventHandler(panel_MouseUp);
                        panelInferior.BackColor = colorInferior;
                        panelInferior.TabStop = false;
                        panelInferior.SendToBack();
                        //panelInferior.Visible = false;
                    }
                }
                else
                {
                    if (panelInferior != null)
                    {
                        panelInferior.Dispose();
                        panelInferior = null;
                        myForm.Size = new Size(myForm.Width, myForm.Height - border.Bottom - margin.Bottom - padding.Bottom);
                        panelUniversal.Size = new Size(myForm.Width, myForm.Height);
                        panelOpciones.Size = new Size(myForm.Width, myForm.Height);

                        if (panelDerecho != null)
                        {
                            //panelDerecho.Size = new Size(panelDerecho.Width, panelDerecho.Height - border.Bottom );
                        }
                        if (panelIzquierdo != null)
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
                    if (panelSuperior == null)
                    {
                        myForm.Size = new Size(myForm.Width, myForm.Height + border.Top + margin.Top + padding.Top);
                        myForm.Location = new Point(myForm.Location.X, myForm.Location.Y - border.Top - margin.Top - padding.Top);
                        panelUniversal.Size = new Size(myForm.Width, myForm.Height);
                        panelOpciones.Size = new Size(myForm.Width, myForm.Height);
                        if (panelInferior != null)
                            panelInferior.Location = new Point(panelInferior.Location.X , panelInferior.Location.Y + border.Top + margin.Top + padding.Top);
                        if (panelDerecho != null)
                            panelDerecho.Location = new Point(panelDerecho.Location.X, panelDerecho.Location.Y + border.Top + margin.Top + padding.Top);
                        if (panelIzquierdo != null)
                            panelIzquierdo.Location = new Point(panelIzquierdo.Location.X, panelIzquierdo.Location.Y + border.Top + margin.Top + padding.Top);
                        if (panelCentro != null)
                            panelCentro.Location = new Point(panelCentro.Location.X, panelCentro.Location.Y + border.Top + margin.Top + padding.Top);


                        panelSuperior = new Panel();
                        panelUniversal.Controls.Add(panelSuperior);
                        panelSuperior.Name = "Outline - Top";
                        panelSuperior.Left = panelIzquierdo == null ? -padding.Left : border.Left + margin.Left;
                        panelSuperior.Top = margin.Top;
                        panelSuperior.Size = new Size(OriginalSizeWindow.Width + padding.Width(), border.Top);
                        panelSuperior.MouseMove += new MouseEventHandler(panel_MouseMove);
                        panelSuperior.MouseDown += new MouseEventHandler(panel_MouseDown);
                        panelSuperior.MouseUp += new MouseEventHandler(panel_MouseUp);
                        panelSuperior.BackColor = colorSuperior;
                        panelSuperior.TabStop = false;
                        panelSuperior.SendToBack();
                        //panelSuperior.Visible = false;

                        CrearBotonMinimizar();
                        CrearBotonCerrar();
                        CrearBotonOpciones();
                        CrearLabelTexto();
                    }
                }
                else
                {
                    if (panelSuperior != null)
                    {
                        panelSuperior.Dispose();
                        panelSuperior = null;
                        myForm.Size = new Size(myForm.Width, panelInferior == null ? OriginalSizeWindow.Height : OriginalSizeWindow.Height + padding.Bottom + margin.Bottom + border.Bottom  );
                        myForm.Location = new Point(myForm.Location.X, myForm.Location.Y + border.Top + margin.Top + padding.Top);
                        panelUniversal.Size = new Size(myForm.Width, myForm.Height);
                        panelOpciones.Size = new Size(myForm.Width, myForm.Height);

                        if (panelInferior != null)
                            panelInferior.Location = new Point(panelInferior.Location.X, panelInferior.Location.Y - border.Top - margin.Top - padding.Top);
                        if (panelDerecho != null)
                            panelDerecho.Location = new Point(panelDerecho.Location.X, panelDerecho.Location.Y - border.Top - margin.Top - padding.Top);
                        if (panelIzquierdo != null)
                            panelIzquierdo.Location = new Point(panelIzquierdo.Location.X, panelIzquierdo.Location.Y - border.Top - margin.Top - padding.Top);
                        panelCentro.Location = new Point(panelCentro.Location.X, 0);
                    }
                }
                AcomodarEsquinas();
            }
        }      
        private bool CenterPanelVisible
        {
            set
            {
                panelCentro = new Panel();
                panelUniversal.Controls.Add(panelCentro);
                panelCentro.Name = "Outline - Center";
                panelCentro.Left = panelIzquierdo != null ? panelIzquierdo.Right + padding.Left : 0;
                panelCentro.Top = panelSuperior != null ? panelSuperior.Bottom + padding.Top : 0;
                panelCentro.Size = new Size
                    (
                        OriginalSizeWindow.Width,
                        OriginalSizeWindow.Height
                    );
                panelCentro.BackColor = colorSecundary;
                panelCentro.TabStop = false;
                panelCentro.SendToBack();

            }
        }
      
        #endregion
        #endregion
    }
}
