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
        List<Point> listPoints = new List<Point>(); // массив точек

        bool bButtonOn = false; // флаг кнопки 1
        enum eLineType { None, Curved, Polygone, Beizers, Filled }
        eLineType LineType = eLineType.None;
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
                    Point p = new Point(e.Location.X, e.Location.Y); // сохраняем координаты курсора и мышки
                    listPoints.Add(p); // добавляем координаты в массив точек
                    Refresh(); //перерисовываем
                }
            }

        }

       
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
                var d = e.Graphics; 
                Brush br = Brushes.Black; //кисть
            Pen pen1 = new Pen(Color.Aqua, width:2);
           
            

            if (listPoints.Count() > 0)
            {
                Point[] arrPoint = new Point[listPoints.Count()];//напрямую через List, почемуто не рисует
                int i = 0;
                foreach (Point pnt in listPoints)
                {
                    d.FillEllipse(br, pnt.X - 2, pnt.Y - 2, 4, 4); //рисуем точки
                    arrPoint[i] = pnt;//перезапись List в массив
                    i++;
                }
               
                if(LineType == eLineType.Curved) {
                   //d.DrawClosedCurve(pen1, listPoints);
                    d.DrawClosedCurve(pen1, arrPoint);
                    LineType = eLineType.None;// отключаем кривую
                    bButtonOn = false; //отключаем точки
                   
                }
                if(LineType == eLineType.Polygone)
                {
                    //d.DrawPolygon(pen1, listPoint);
                    d.DrawPolygon(pen1, arrPoint);
                    LineType = eLineType.None;
                    bButtonOn = false; //отключаем точки
                }
                if(LineType == eLineType.Beizers )
                {
                    //d.DrawBeziers(pen1, listPoints);
                    d.DrawBeziers(pen1, arrPoint);
                    LineType = eLineType.None;
                    bButtonOn = false; //отключаем точки
                }
             
                if(LineType == eLineType.Filled)
                {
                    d.FillClosedCurve(br, arrPoint);
                    LineType = eLineType.None;
                    bButtonOn = false; //отключаем точки
                }
               
            }
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!bButtonOn) {
                listPoints.Clear();
                Refresh();
            }
            bButtonOn = !bButtonOn;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) //кривая
        {
            LineType = eLineType.Curved;
            Refresh();
        }

        private void button4_Click(object sender, EventArgs e)//ломаная
        {
            LineType = eLineType.Polygone;
            Refresh();
        }

        private void button5_Click(object sender, EventArgs e)//Безье
        {
            if (listPoints.Count == 4)//рисуем безье если есть 4 точки
            {
                LineType = eLineType.Beizers;
                Refresh();
            }
            else bButtonOn = false;//отключаем точки
        }

        private void button6_Click(object sender, EventArgs e)//заполненная
        {
            LineType = eLineType.Filled;
            Refresh();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)//очистить
        {
            listPoints.Clear();
            Refresh();
        }
    }
}
