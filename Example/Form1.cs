using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlineForm_Example
{
    public partial class Form1 : Form
    {
        OutlineForm outlineForm;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(border, "Define las medidas del contorno.");
            toolTip.SetToolTip(margin, "Define las medidas externas del contorno.");
            toolTip.SetToolTip(padding, "Define las medidas internas del contorno.");

            pb_ColorDer.Tag = OutlineForm.SelectedPanel.Derecho;
            pb_ColorIzq.Tag = OutlineForm.SelectedPanel.Izquierdo;
            pb_ColorSup.Tag = OutlineForm.SelectedPanel.Superior;
            pb_ColorInf.Tag = OutlineForm.SelectedPanel.Inferior;
            pb_ColorSupDer.Tag = OutlineForm.SelectedPanel.EsquinaSuperiorDerecho;
            pb_ColorSupIzq.Tag = OutlineForm.SelectedPanel.EsquinaSuperiorIzquierdo;
            pb_ColorInfDer.Tag = OutlineForm.SelectedPanel.EsquinaInferiorDerecho;
            pb_ColorInfIzq.Tag = OutlineForm.SelectedPanel.EsquinaInferiorIzquierdo;

            btn_Derecho.Tag = OutlineForm.SelectedPanel.Derecho;
            btn_Izquierdo.Tag = OutlineForm.SelectedPanel.Izquierdo;
            btn_Superior.Tag = OutlineForm.SelectedPanel.Superior;
            btn_Inferior.Tag = OutlineForm.SelectedPanel.Inferior;

            //Ejemplo de declaracion del OutlineForm
            ReiniciarOutlineForm();
        }
        

        private void ReiniciarOutlineForm()
        {
            //Instanciar el objeto.
            //Con solo esta linea, se crea un marco por defecto, con Border: Rect.Window, y Margin y Padding: Rect.Zero
            outlineForm = new OutlineForm(this);

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

            //Asi se obtienen los colores de cada panel.
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

            //No obstante, para definir un color, se utiliza un metodo.
            //Esto es para seleccionar los paneles que serán pintados.
            outlineForm.SetColorPanel(OutlineForm.SelectedPanel.Todos, Color.Black);

            //Establecer el titulo de la ventana
            outlineForm.Titulo = txt_Titulo.Text;

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











        private void Btn_Visible_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            switch((OutlineForm.SelectedPanel)bt.Tag)
            {
                case OutlineForm.SelectedPanel.Derecho:
                    outlineForm.RightPanelVisible = !outlineForm.RightPanelVisible;
                    btn_Derecho.BackColor = outlineForm.RightPanelVisible ? Color.Green : Color.Red;
                    break;
                case OutlineForm.SelectedPanel.Izquierdo:
                    outlineForm.LeftPanelVisible = !outlineForm.LeftPanelVisible;
                    btn_Izquierdo.BackColor = outlineForm.LeftPanelVisible ? Color.Green : Color.Red;
                    break;
                case OutlineForm.SelectedPanel.Superior:
                    outlineForm.TopPanelVisible = !outlineForm.TopPanelVisible;
                    btn_Superior.BackColor = outlineForm.TopPanelVisible ? Color.Green : Color.Red;
                    break;
                case OutlineForm.SelectedPanel.Inferior:
                    outlineForm.BottomPanelVisible = !outlineForm.BottomPanelVisible;
                    btn_Inferior.BackColor = outlineForm.BottomPanelVisible ? Color.Green : Color.Red;
                    break;
            }

            
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }


        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            outlineForm.Titulo = txt_Titulo.Text;
        }

        private void MedidasBoton_Click(object sender, EventArgs e)
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
                outlineForm.SetColorPanel((OutlineForm.SelectedPanel)pb.Tag, colorDialog_Outline.Color);
                pb.BackColor = colorDialog_Outline.Color;                
            }
        }
    }
}
