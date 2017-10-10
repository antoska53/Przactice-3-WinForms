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
