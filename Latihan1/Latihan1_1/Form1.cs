﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan1_1
{
    public partial class Form1 : Form
    {
        int min = 0, max = 0;
        
        public Form1()
        {
            InitializeComponent();
            label5.Text = vScrollBar1.Value.ToString();
            label6.Text = vScrollBar2.Value.ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Vscrollbar(object sender, ScrollEventArgs e)
        {

            if (vScrollBar1.Value > vScrollBar2.Value)
            {
                max = vScrollBar1.Value;
                min = vScrollBar2.Value;
            }
            else
            {
                max = vScrollBar2.Value;
                min = vScrollBar1.Value;
            }
            label5.Text = vScrollBar1.Value.ToString();
            textBox3.Text = (vScrollBar1.Value + vScrollBar2.Value).ToString();
            label6.Text = vScrollBar2.Value.ToString();
            textBox3.Text = (vScrollBar1.Value + vScrollBar2.Value).ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime current = this.dateTimePicker1.Value.Date;
            DateTime tgl1 = new DateTime(current.Year - max, current.Month, current.Day);
            DateTime tgl2 = new DateTime(current.Year - min, current.Month, current.Day);
            textBox1.Text = tgl1.ToString("dddd,dd MMMM yyyy");
            textBox2.Text = tgl2.ToString("dddd,dd MMMM yyyy");
            dateTimePicker1.MinDate = tgl1;
            dateTimePicker1.MaxDate = tgl2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
