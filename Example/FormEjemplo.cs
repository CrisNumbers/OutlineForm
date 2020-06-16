using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormDecoration
{
    public partial class FormEjemplo : Form
    {
        OutlineForm outlineForm;
        public FormEjemplo()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(border, "Define las medidas del contorno.");
            toolTip.SetToolTip(margin, "Define las medidas externas del contorno.");
            toolTip.SetToolTip(padding, "Define las medidas internas del contorno.");

            pb_ColorDer.Tag = OutlineForm.SelectPanel.Right;
            pb_ColorIzq.Tag = OutlineForm.SelectPanel.Left;
            pb_ColorSup.Tag = OutlineForm.SelectPanel.Top;
            pb_ColorInf.Tag = OutlineForm.SelectPanel.Bottom;
            pb_ColorSupDer.Tag = OutlineForm.SelectPanel.CornerTopRight;
            pb_ColorSupIzq.Tag = OutlineForm.SelectPanel.CornerTopLeft;
            pb_ColorInfDer.Tag = OutlineForm.SelectPanel.CornerBottomRight;
            pb_ColorInfIzq.Tag = OutlineForm.SelectPanel.CornerBottomLeft;

            btn_Derecho.Tag = OutlineForm.SelectPanel.Right;
            btn_Izquierdo.Tag = OutlineForm.SelectPanel.Left;
            btn_Superior.Tag = OutlineForm.SelectPanel.Top;
            btn_Inferior.Tag = OutlineForm.SelectPanel.Bottom;

            btn_Pintar.Tag = 1;

            //Ejemplo de declaracion del OutlineForm
            ReiniciarOutlineForm();
        }
        
        /// <summary>
        /// Este metodo se muestra los componentes principales de la clase OutlineForm
        /// </summary>
        private void ReiniciarOutlineForm()
        {
            //Instanciar el objeto.
            //Con solo esta linea, se crea un marco por defecto, con Border: Rect.Window, y Margin y Padding: Rect.Zero
            outlineForm = new OutlineForm(this);

            //Para comprobar la version de la clase, se usa la variable estatica.
            //Esto solo es para información.
            l_Version.Text = "Version " + OutlineForm.version;

            //Podemos especificar unas medidas a nuestro gusto
            outlineForm.SetBorder(Rect.Window);
            outlineForm.SetMargin(Rect.Zero);
            outlineForm.SetPadding(Rect.Zero);

            //O simplemente utilizar está función completa
            //En caso de que estemos usando las mismas medidas,
            //la clase no actualizará ningun aspecto.
            outlineForm.SetBorderMarginPadding(Rect.Window, Rect.Zero, Rect.Zero);

            //Asi se obtienen la visibilidad de cada panel.
            //Si se quita la visibilidad, entonces destruirá el panel correspondiente.
            btn_Inferior.BackColor = outlineForm.BottomPanelVisible ? Color.Green : Color.Red;
            btn_Superior.BackColor = outlineForm.TopPanelVisible ? Color.Green : Color.Red;
            btn_Izquierdo.BackColor = outlineForm.LeftPanelVisible ? Color.Green : Color.Red;
            btn_Derecho.BackColor = outlineForm.RightPanelVisible ? Color.Green : Color.Red;

            //Para definir un color, se utiliza un metodo.
            //Esto es para seleccionar los paneles que serán pintados.
            outlineForm.SetColorPanel(OutlineForm.SelectPanel.AllWithCorners, Color.DarkBlue);
            
            //En caso de pedir los colores de un panel que no existe, retornará un color negro.
            //(Excepto las esquinas, ya que estas estan siempre generadas)
            pb_ColorSup.BackColor = outlineForm.TopColor;
            pb_ColorInf.BackColor = outlineForm.BottomColor;
            pb_ColorIzq.BackColor = outlineForm.LeftColor;
            pb_ColorDer.BackColor = outlineForm.RightColor;
            pb_ColorSupDer.BackColor = outlineForm.TopRightColor;
            pb_ColorSupIzq.BackColor = outlineForm.TopLeftColor;
            pb_ColorInfDer.BackColor = outlineForm.BottomLeftColor;
            pb_ColorInfIzq.BackColor = outlineForm.BottomRightColor;

            

            //Establecer el titulo de la ventana
            outlineForm.Title = txt_Titulo.Text;

            //Obtener el border (las lineas) de la ventana.
            txt_Border_Derecho.Text = outlineForm.Border.Right.ToString();
            txt_Border_Izquierdo.Text = outlineForm.Border.Left.ToString();
            txt_Border_Superior.Text = outlineForm.Border.Top.ToString();
            txt_Border_Inferior.Text = outlineForm.Border.Bottom.ToString();

            //Obtener el margin (lo interno) de la ventana.
            txt_Margin_Derecho.Text = outlineForm.Margin.Right.ToString();
            txt_Margin_Izquierdo.Text = outlineForm.Margin.Left.ToString();
            txt_Margin_Superior.Text = outlineForm.Margin.Top.ToString();
            txt_Margin_Inferior.Text = outlineForm.Margin.Bottom.ToString();

            //Obtener el padding (lo externo) de la ventana.
            txt_Padding_Derecho.Text = outlineForm.Padding.Right.ToString();
            txt_Padding_Izquierdo.Text = outlineForm.Padding.Left.ToString();
            txt_Padding_Superior.Text = outlineForm.Padding.Top.ToString();
            txt_Padding_Inferior.Text = outlineForm.Padding.Bottom.ToString();
        }










        private void ActualizarTimerPintar()
        {
            int index = (int)t_Pintando.Tag;
            if (index < 0) index = 0;
            int pseudoIndex = 0;
            int total = Enum.GetValues(typeof(OutlineForm.SelectPanel)).Length;
            outlineForm.SetColorPanel(OutlineForm.SelectPanel.AllWithCorners, Color.Green);
            foreach (OutlineForm.SelectPanel number in Enum.GetValues(typeof(OutlineForm.SelectPanel)))
            {
                if (index >= total)
                {
                    gb_Medidas.Enabled = true;
                    gb_OpcionesContorno.Enabled = true;
                    gb_Titulo.Enabled = true;
                    btn_Destroy.Enabled = true;
                    btn_PintandoAnterior.Enabled = false;
                    btn_PintandoSiguiente.Enabled = false;
                    l_Pintando.Visible = false;
                    btn_Pintar.Text = "Pintar todas las combinaciones";
                    btn_Pintar.BackColor = Color.DarkGreen;

                    t_Pintando.Stop();
                    btn_Pintar.Tag = 1;
                    break;
                }
                else if (index == pseudoIndex)
                {
                    outlineForm.SetColorPanel(number, Color.Red);
                    l_Pintando.Text = "Pintando: " + number.ToString();
                    break;
                }
                else
                    pseudoIndex++;
            }

            t_Pintando.Tag = index + 1;
        }


        private void Btn_Visible_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            switch((OutlineForm.SelectPanel)bt.Tag)
            {
                case OutlineForm.SelectPanel.Right:
                    outlineForm.RightPanelVisible = !outlineForm.RightPanelVisible;
                    btn_Derecho.BackColor = outlineForm.RightPanelVisible ? Color.Green : Color.Red;
                    break;
                case OutlineForm.SelectPanel.Left:
                    outlineForm.LeftPanelVisible = !outlineForm.LeftPanelVisible;
                    btn_Izquierdo.BackColor = outlineForm.LeftPanelVisible ? Color.Green : Color.Red;
                    break;
                case OutlineForm.SelectPanel.Top:
                    outlineForm.TopPanelVisible = !outlineForm.TopPanelVisible;
                    btn_Superior.BackColor = outlineForm.TopPanelVisible ? Color.Green : Color.Red;
                    break;
                case OutlineForm.SelectPanel.Bottom:
                    outlineForm.BottomPanelVisible = !outlineForm.BottomPanelVisible;
                    btn_Inferior.BackColor = outlineForm.BottomPanelVisible ? Color.Green : Color.Red;
                    break;
            }

            
        }

        private void Txt_Titulo_TextChanged(object sender, EventArgs e)
        {
            outlineForm.Title = txt_Titulo.Text;
        }

        private void Btn_Actualizar_Click(object sender, EventArgs e)
        {
            outlineForm.SetBorderMarginPadding(
               new Rect(int.Parse(txt_Border_Superior.Text), int.Parse(txt_Border_Derecho.Text), int.Parse(txt_Border_Inferior.Text), int.Parse(txt_Border_Izquierdo.Text)),
               new Rect(int.Parse(txt_Margin_Superior.Text), int.Parse(txt_Margin_Derecho.Text), int.Parse(txt_Margin_Inferior.Text), int.Parse(txt_Margin_Izquierdo.Text)),
               new Rect(int.Parse(txt_Padding_Superior.Text), int.Parse(txt_Padding_Derecho.Text), int.Parse(txt_Padding_Inferior.Text), int.Parse(txt_Padding_Izquierdo.Text))
               );
        }

        private void Btn_Destroy_Click(object sender, EventArgs e)
        {
            if ((string)btn_Destroy.Tag == "1")
            {
                outlineForm.Destroy(true);
                btn_Destroy.Tag = "0";
                btn_Destroy.BackColor = Color.DarkGreen;
                btn_Destroy.Text = "Crear OutlineForm";
                gb_Medidas.Enabled = gb_OpcionesContorno.Enabled = gb_Titulo.Enabled = false;
            }
            else
            {
                ReiniciarOutlineForm();
                btn_Destroy.Tag = "1";
                btn_Destroy.BackColor = Color.DarkRed;
                btn_Destroy.Text = "Destruir OutlineForm";
                gb_Medidas.Enabled = gb_OpcionesContorno.Enabled = gb_Titulo.Enabled = true;
            }
        }

        private void Pb_Color_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (colorDialog_Outline.ShowDialog() == DialogResult.OK)
            {
                outlineForm.SetColorPanel((OutlineForm.SelectPanel)pb.Tag, colorDialog_Outline.Color);
                pb.BackColor = colorDialog_Outline.Color;                
            }
        }

        private void Btn_Pintar_Click(object sender, EventArgs e)
        {
            if ((int)btn_Pintar.Tag == 1)
            {
                gb_Medidas.Enabled = false;
                gb_OpcionesContorno.Enabled = false;
                gb_Titulo.Enabled = false;
                btn_Destroy.Enabled = false;
                btn_PintandoAnterior.Enabled = true;
                btn_PintandoSiguiente.Enabled = true;
                l_Pintando.Visible = true;

                btn_Pintar.Text = "Detener pintado";
                btn_Pintar.BackColor = Color.DarkRed;

                t_Pintando.Tag = 0;
                btn_Pintar.Tag = 0;
                t_Pintando.Start();
            }
            else
            {
                gb_Medidas.Enabled = true;
                gb_OpcionesContorno.Enabled = true;
                gb_Titulo.Enabled = true;
                btn_Destroy.Enabled = true;
                btn_PintandoAnterior.Enabled = false;
                btn_PintandoSiguiente.Enabled = false;
                l_Pintando.Visible = false;
                btn_Pintar.Text = "Pintar todas las combinaciones";
                btn_Pintar.BackColor = Color.DarkGreen;

                t_Pintando.Stop();
                btn_Pintar.Tag = 1;
            }
        }

        private void T_Pintando_Tick(object sender, EventArgs e)
        {
            ActualizarTimerPintar();
        }

        private void Tb_Flujo_Scroll(object sender, EventArgs e)
        {
            int valor = tb_Flujo.Value;
            int multi = tb_Flujo.Value / 500 ;
            if (valor % 500 < 250)
                valor = 500 * (multi);
            else
                valor = 500 * (multi+ 1);
            
            t_Pintando.Interval = valor;
            tb_Flujo.Value = valor;
        }

        private void Btn_PintandoSiguiente_Click(object sender, EventArgs e)
        {
            t_Pintando.Stop();
            ActualizarTimerPintar();
            t_Pintando.Start();
        }

        private void Btn_PintandoAnterior_Click(object sender, EventArgs e)
        {
            t_Pintando.Stop();
            t_Pintando.Tag = (int)t_Pintando.Tag - 2;
            ActualizarTimerPintar();
            t_Pintando.Start();
        }
    }
}
