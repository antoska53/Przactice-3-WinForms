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
        int[] arrRandX; // массив рандомных направлений и скорости
        int[] arrRandY;
        bool[] flagsX; // массив флагов для Х
        bool[] flagsY; // массив флагов для У
        
        Random rand = new Random();

        bool bButtonOn = false; // флаг кнопки 1
        bool bDrag = false; //флаг для перемещения точек
        int iPointToDrag;//перемещаемая точка
        bool flagXRight = false;
        bool flagYRight = false;
        enum eLineType { None, Curved, Polygone, Beizers, Filled }
        eLineType LineType = eLineType.None;
        private Timer moveTimer = new Timer();
      
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true; // чтобы не мерцали фигуры
            Paint += Form1_Paint;
            MouseClick += Form1_MouseClick1;
            moveTimer.Interval = 30;
            moveTimer.Tick += MoveTimer_Tick;
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
            MouseUp += Form1_MouseUp;
            
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            bDrag = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (bDrag)
            {
                listPoints[iPointToDrag] = e.Location;
                Refresh();
            }
           
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < listPoints.Count(); i++)
            {
                if ((e.X <= listPoints[i].X + 5 && e.X >= listPoints[i].X - 5) && (e.Y <= listPoints[i].Y + 5 && e.Y >= listPoints[i].Y - 5))
                {
                    bDrag = true;
                    //bButtonOn = false;
                    iPointToDrag = i;
                    
                }
            }
        }

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            if (Data.moveDot)
            {
                foreach (var item in listPoints) // проверяем достигли ли края
                {
                    if (item.X == 283 || item.X == 90) { flagXRight = !flagXRight; }
                    if (item.Y == 260 || item.Y == 0) { flagYRight = !flagYRight; }
                }
                for (int i = 0; i < listPoints.Count(); i++) // меняем координаты
                {
                    //listPoints[i].Y++;
                    Point p1 = listPoints[i];//почему не работает напрямую через список?

                    if (flagXRight) { p1.X--; }
                    else { p1.X++; }
                    if (flagYRight) { p1.Y--; }
                    else { p1.Y++; }
                    //if (!flagXRight) p1.X++;

                    //p1.Y++;
                    listPoints[i] = p1;
                }
            }

          

            else
            {
                for (int i = 0; i < listPoints.Count(); i++)
                {
                    if (listPoints[i].X >= 283 || listPoints[i].X <= 90) { flagsX[i] = !flagsX[i]; }
                    if (listPoints[i].Y >= 260 || listPoints[i].Y <= 0) { flagsY[i] = !flagsY[i]; }
                }

                for (int i = 0; i < listPoints.Count(); i++)
                {
                    Point p2 = listPoints[i];               //не работает на прямую через список
                    if (flagsX[i]) { p2.X += arrRandX[i]; }
                    else { p2.X -= arrRandX[i]; }
                    if (flagsY[i]) { p2.Y += arrRandY[i]; }
                    else { p2.Y -= arrRandY[i]; }
                    listPoints[i] = p2;
                }
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
            if (bDrag)
            {

            }
           
            

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
            moveTimer.Stop();
           
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
            bButtonOn = false; //отключаем точки
            moveTimer.Enabled = !moveTimer.Enabled;
            if (moveTimer.Enabled)
            {
                flagsX = new bool[listPoints.Count()];
                flagsY = new bool[listPoints.Count()];
                arrRandX = new int[listPoints.Count()];
                arrRandY = new int[listPoints.Count()];
                for (int i = 0; i < listPoints.Count(); i++)
                {
                    arrRandX[i] = rand.Next(-5, 5);
                    arrRandY[i] = rand.Next(-5, 5);
                    flagsX[i] = true;
                    flagsY[i] = true;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)//очистить
        {
            listPoints.Clear();
            Refresh();
        }
    }
}
