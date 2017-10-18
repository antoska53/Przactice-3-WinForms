using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Przactice_3_WinForms
{
    static class Data                         //класс для хранения данных(цвет, размер) форм(Form1, Form2)
    {
        private static int dotSiz = 4;
        private static int lineSiz = 2;
        private static Color dotColor = Color.Black;
        private static Color lineColor = Color.Black;
        private static bool randMove = true;
        private static int numericUP1 = 0;
        private static int numericUP2 = 0;
        private static int speed = 1;

        public static int speedDot
        {
            get { return speed; }
            set { speed = value; }
        }

        public static int nemricValue1
        {
            get { return numericUP1; }
            set
            {
                numericUP1 = value;
            }
        }
        public static int nemricValue2
        {
            get { return numericUP2; }
            set
            {
                numericUP2 = value;
            }
        }

        public static bool moveDot
        {
            get { return randMove; }
            set { randMove = value; }
        }

        public static int valueDot
        {
            get { return dotSiz; }
            set { dotSiz = value; }
        }
        public static int valueLine
        {
            get { return lineSiz; }
            set { lineSiz = value; }
        }
        public static Color colDot
        {
            get { return dotColor; }
            set { dotColor = value; }
        }
        public static Color colLine
        {
            get { return lineColor; }
            set { lineColor = value; }
        }
    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
