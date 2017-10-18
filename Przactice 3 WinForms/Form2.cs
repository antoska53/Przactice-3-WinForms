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
    public partial class Form2 : Form
    {
        string[] allKnownColors = Enum.GetNames(typeof(KnownColor)); //список цветов
      
        public Form2()
        {
            InitializeComponent();
           
            foreach (var item in allKnownColors)//добавление цветов в ыпадающий список
            {
                comboBox1.Items.Add(item);
                comboBox2.Items.Add(item);
            }
            numericUpDown1.Value = Data.nemricValue1;
            numericUpDown2.Value = Data.nemricValue2;
            if (Data.moveDot) {
                checkedListBox1.SetItemChecked(1, true);
                checkedListBox1.SetItemChecked(0, false);

            }
            else { checkedListBox1.SetItemChecked(0, true);
                checkedListBox1.SetItemChecked(1, false);
                    }
           // comboBox1.SelectedIndex = comboBox1.SelectedItem;

        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void checkBox1_CheckedChanged(object sender, EventArgs e) // случайное движение точек
        //{
        //    Data.moveDot = false;
        //}

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)//размер точек
        {
            Data.valueDot = (int)numericUpDown1.Value;
            Data.nemricValue1 = (int)numericUpDown1.Value;
            
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)//толщина линий
        {
            Data.valueLine = (int)numericUpDown2.Value;
            Data.nemricValue2 = (int)numericUpDown2.Value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)//цвет точек
        {
            Data.colDot = Color.FromName(comboBox1.SelectedItem.ToString());
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)//цвет линий
        {
            Data.colLine = Color.FromName(comboBox2.SelectedItem.ToString());
        }

        //private void checkBox2_CheckedChanged(object sender, EventArgs e) //движение точек
        //{
            
        //    Data.moveDot = true;
        //}

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if(checkedListBox1.SelectedIndex == 0) {
                Data.moveDot = false;
               
                checkedListBox1.SetItemChecked(1, false);//сброс флажка
            }
            else {
                Data.moveDot = true;
                checkedListBox1.SetItemChecked(0, false);//сброс флажка
            }
           
        }
    }
}
