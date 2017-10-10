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
        Random rand = new Random();

        bool bButtonOn = false; // флаг кнопки 1
        bool flagXRight = false;
        enum eLineType { None, Curved, Polygone, Beizers, Filled }
        eLineType LineType = eLineType.None;
        private Timer moveTimer = new Timer();
      
        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;
            MouseClick += Form1_MouseClick1;
            moveTimer.Interval = 30;
            moveTimer.Tick += MoveTimer_Tick;
            
        }

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
           // bool flagXRight = false;
            bool flagXLeft = false;
            bool flagY = false;
            for(int i = 0; i < listPoints.Count(); i++)
            {
                //listPoints[i].Y++;//почему не работает напрямую через список?
                Point p1 = listPoints[i];
                if (p1.X == 282 || p1.X == 50) { flagXRight = !flagXRight; }
                if (flagXRight) { p1.X--; }
                else { p1.X++; }
                //if (!flagXRight) p1.X++;
                
                //p1.Y++;
                listPoints[i] = p1;
            }
            Refresh();
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
                Brush br = new SolidBrush(Data.colDot); //кисть
                Pen pen1 = new Pen(Data.colLine, width:Data.valueLine);
           
            

            if (listPoints.Count() > 0)
            {
                Point[] arrPoint = new Point[listPoints.Count()];//напрямую через List, почемуто не рисует
                int i = 0;
                foreach (Point pnt in listPoints)
                {
                    d.FillEllipse(br, pnt.X - Data.valueDot/2, pnt.Y - Data.valueDot / 2, Data.valueDot, Data.valueDot); //рисуем точки
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
            Form2 secondForm = new Form2();
            secondForm.Show();
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
            moveTimer.Start();
        }

        private void button8_Click(object sender, EventArgs e)//очистить
        {
            listPoints.Clear();
            Refresh();
        }
    }
}
