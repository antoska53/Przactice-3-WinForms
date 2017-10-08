using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Przactice_3_WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var d = e.Graphics;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  MessageBox.Show("Hello");
            var g = CreateGraphics();
            g.DrawLine(Pens.Black, 200, 150, 200, 150);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
