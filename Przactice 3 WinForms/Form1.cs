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
        List<Point> points = new List<Point>(); // массив точек
      
        bool bButtonOn = false; // флаг кнопки 1
        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;
            MouseClick += Form1_MouseClick1;
            
        }
      
        private void Form1_MouseClick1(object sender, MouseEventArgs e)
        {
           
            if (bButtonOn)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point p = e.Location; // сохраняем координаты курсора и мышки
                    points.Add(p); // добавляем координаты в массив точек
                    Refresh(); //перерисовываем
                }
            }
        }

       
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
                var d = e.Graphics; 
                Brush br = Brushes.Black; //кисть
               
                foreach (Point pnt in points)
                {
                    d.FillEllipse(br, pnt.X, pnt.Y, 3, 3); //рисуем точку
                }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            bButtonOn = !bButtonOn;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

     
    }
}
