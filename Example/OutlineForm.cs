using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OutlineForm_Example
{
    public partial class OutlineForm 
    {
        [Serializable]
        public class ExceptionOutlineForm : Exception
        {
            public ExceptionOutlineForm(string exceptionMode)
            : base(String.Format("Se produjo una excepcion: {0}", exceptionMode))
            {

            }
        }

        public enum SelectedPanel {
            Izquierdo = 1,
            Derecho = 2,
            Superior = 4,
            Inferior = 8,
            EsquinaSuperiorDerecho = 16,
            EsquinaSuperiorIzquierdo = 32,
            EsquinaInferiorDerecho = 64,
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

        #region B_Variables
        static List<Form> listaForms = new List<Form>();
        Size OriginalSizeWindow = Size.Empty;
        Point OriginalLocationWindow = Point.Empty;
        Rect border; //Define el tamaño del contorno.
        Rect margin; //Define el margin del contorno.
        Rect padding; //Define el padding del contorno.

        Color colorPrimary; //Color del border.
        Color colorIzquierdo;
        Color colorDerecho;
        Color colorSuperior;
        Color colorInferior;
        Color colorSupDer;
        Color colorSupIzq;
        Color colorInfDer;
        Color colorInfIzq;
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

        #region B_Propiedades
        /// <summary>
        /// Retorna o cambia el color de todo el contorno.
        /// </summary>
        public Color OutlineColor
        {
            get
            {
                return panelSuperior.BackColor;
            }
            set
            {
                panelSuperior.BackColor = panelInferior.BackColor = panelIzquierdo.BackColor = panelDerecho.BackColor = value;
            }
        }
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
            set
            {
                Set(nombre, colorPrimary, colorSecundary, border, margin, value, BotonMinimizar.Visible, BotonCerrar.Visible, BotonOpciones.Visible);
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
            set
            {
                Set(nombre, colorPrimary, colorSecundary, border, value, padding, BotonMinimizar.Visible, BotonCerrar.Visible, BotonOpciones.Visible);
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
            set
            {
                Set(nombre, colorPrimary, colorSecundary, value, margin, padding, BotonMinimizar.Visible, BotonCerrar.Visible, BotonOpciones.Visible);
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
                        panelIzquierdo.Name = "BarraDeTitulo - panelIzquierdo";
                        panelIzquierdo.Left = margin.Left;
                        panelIzquierdo.Top = panelSuperior == null ? -padding.Top : border.Top + margin.Top;
                        panelIzquierdo.Size = new Size(border.Left, OriginalSizeWindow.Height + padding.Height());
                        // panelIzquierdo.MouseMove += new MouseEventHandler(panel_MouseMove);
                        // panelIzquierdo.MouseDown += new MouseEventHandler(panel_MouseDown);
                        // panelIzquierdo.MouseUp += new MouseEventHandler(panel_MouseUp);
                        panelIzquierdo.BackColor = colorPrimary;
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
                        panelDerecho.Name = "BarraDeTitulo - panelDerecho";
                        panelDerecho.Left = panelIzquierdo == null ? OriginalSizeWindow.Width + padding.Right : OriginalSizeWindow.Width + padding.Width() + border.Left + margin.Left;
                        panelDerecho.Top = panelSuperior == null ? -padding.Top : border.Top + margin.Top;
                        panelDerecho.Size = new Size(border.Right, OriginalSizeWindow.Height + padding.Height());
                        panelDerecho.MouseHover += new EventHandler(panel_Resize_MouseHover);
                        panelDerecho.MouseLeave += new EventHandler(panel_Resize_MouseLeave);
                        // panelDerecho.MouseMove += new MouseEventHandler(panel_MouseMove);
                        // panelDerecho.MouseDown += new MouseEventHandler(panel_MouseDown);
                        // panelDerecho.MouseUp += new MouseEventHandler(panel_MouseUp);
                        panelDerecho.BackColor = colorPrimary;
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
                        panelInferior.Name = "BarraDeTitulo - panelInferior";
                        panelInferior.Left = panelIzquierdo == null ? -padding.Left : border.Left + margin.Left;
                        panelInferior.Top = panelSuperior == null ? OriginalSizeWindow.Height + padding.Bottom : OriginalSizeWindow.Height + padding.Height() + border.Top + margin.Top;
                        panelInferior.Size = new Size(OriginalSizeWindow.Width + padding.Width(), border.Bottom);
                        // panelInferior.MouseMove += new MouseEventHandler(panel_MouseMove);
                        // panelInferior.MouseDown += new MouseEventHandler(panel_MouseDown);
                        // panelInferior.MouseUp += new MouseEventHandler(panel_MouseUp);
                        panelInferior.BackColor = colorPrimary;
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
                        panelSuperior.Name = "BarraDeTitulo - panelSuperior";
                        panelSuperior.Left = panelIzquierdo == null ? -padding.Left : border.Left + margin.Left;
                        panelSuperior.Top = margin.Top;
                        panelSuperior.Size = new Size(OriginalSizeWindow.Width + padding.Width(), border.Top);
                        panelSuperior.MouseMove += new MouseEventHandler(panel_MouseMove);
                        panelSuperior.MouseDown += new MouseEventHandler(panel_MouseDown);
                        panelSuperior.MouseUp += new MouseEventHandler(panel_MouseUp);
                        panelSuperior.BackColor = colorPrimary;
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
                panelCentro.Name = "BarraDeTitulo - panelCentro";
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

        

        #region Constructor
        private void Destructor()
        {
            if (!Object.ReferenceEquals(null, panelUniversal)) {
                foreach(Control control in panelCentro.Controls)
                {
                    myForm.Controls.Add(control);
                }
                panelUniversal.Dispose();
                panelUniversal = null;

            }
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
            if (!OriginalLocationWindow.IsEmpty) { OriginalLocationWindow = Point.Empty; }
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
                Set("", Color.Black, myForm.BackColor, new Rect(40, 10, 10, 10), new Rect(10), new Rect(10), true, true, true);
            }
            else
                throw new ExceptionOutlineForm("No se puede instanciar el objeto con un Form anteriormente agregado");


            
        }
        #endregion

        /// <summary>
        /// Crea un marco con texto y botones alrededor del Form. En caso de existir uno, se eliminará y creará uno nuevo.
        /// </summary>
        /// <param name="formP"></param>
        /// <param name="nombreVentanaP"></param>
        /// <param name="colorP"></param>
        /// <param name="marginP"></param>
        /// <param name="botonMinimizarP"></param>
        /// <param name="botonCerrarP"></param>
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
            Set(nombre, colorPrimary, colorSecundary, newBorderP, newMarginP, newPaddingP, BotonMinimizar.Visible, BotonCerrar.Visible, BotonOpciones.Visible);
        }

        public void SetColorPanel(SelectedPanel panelP, Color colorP)
        {
            List<Panel> lista = SearchPanel(panelP);
            foreach (Panel miPanel in lista)
            {
                miPanel.BackColor = colorP;
            }
        }
    }
}
