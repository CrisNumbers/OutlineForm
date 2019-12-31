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
            outlineForm = new OutlineForm(this);
            outlineForm.Titulo = "Ejemplo";
            bottomEnable.BackColor = outlineForm.BottomPanelVisible ? Color.Green : Color.Red;
            topEnable.BackColor = outlineForm.TopPanelVisible ? Color.Green : Color.Red;
            leftEnable.BackColor = outlineForm.LeftPanelVisible ? Color.Green : Color.Red;
            RightEnable.BackColor = outlineForm.RightPanelVisible ? Color.Green : Color.Red;
            nameTextBox.Text = outlineForm.Titulo;

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(border, "Define las medidas del contorno.");
            toolTip.SetToolTip(margin, "Define las medidas externas del contorno.");
            toolTip.SetToolTip(padding, "Define las medidas internas del contorno.");

            borderRight .Text = outlineForm.Border.Right.ToString();
            borderLeft  .Text = outlineForm.Border.Left.ToString();
            borderTop   .Text = outlineForm.Border.Top.ToString();
            borderBottom.Text = outlineForm.Border.Bottom.ToString();

            marginRight .Text = outlineForm.Margin.Right.ToString();
            marginLeft  .Text = outlineForm.Margin.Left.ToString();
            marginTop   .Text = outlineForm.Margin.Top.ToString();
            marginBottom.Text = outlineForm.Margin.Bottom.ToString();

            paddingRight .Text = outlineForm.Padding.Right.ToString();
            paddingLeft  .Text = outlineForm.Padding.Left.ToString();
            paddingTop   .Text = outlineForm.Padding.Top.ToString();
            paddingBottom.Text = outlineForm.Padding.Bottom.ToString();


        }
        














        private void Button1_Click(object sender, EventArgs e)
        {
            outlineForm.BottomPanelVisible = !outlineForm.BottomPanelVisible;
            bottomEnable.BackColor = outlineForm.BottomPanelVisible ? Color.Green : Color.Red;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            outlineForm.RightPanelVisible = !outlineForm.RightPanelVisible;
            RightEnable.BackColor = outlineForm.RightPanelVisible ? Color.Green : Color.Red;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            outlineForm.LeftPanelVisible = !outlineForm.LeftPanelVisible;
            leftEnable.BackColor = outlineForm.LeftPanelVisible ? Color.Green : Color.Red;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            outlineForm.TopPanelVisible = !outlineForm.TopPanelVisible;
            topEnable.BackColor = outlineForm.TopPanelVisible ? Color.Green : Color.Red;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            outlineForm.Titulo = nameTextBox.Text;
        }

        private void MedidasBoton_Click(object sender, EventArgs e)
        {
            outlineForm.SetBorderMarginPadding(
                new Rect(int.Parse(borderTop.Text), int.Parse(borderRight.Text), int.Parse(borderBottom.Text), int.Parse(borderLeft.Text)),
                new Rect(int.Parse(marginTop.Text), int.Parse(marginRight.Text), int.Parse(marginBottom.Text), int.Parse(marginLeft.Text)),
                new Rect(int.Parse(paddingTop.Text), int.Parse(paddingRight.Text), int.Parse(paddingBottom.Text), int.Parse(paddingLeft.Text))
                );
        }
    }
}
