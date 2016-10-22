using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Latihan3_1
{
    public partial class Form1 : Form
    {
        List<string> fonts = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }
        public sealed class ColorPalette
        {

        }
            private void Form1_Load(object sender, EventArgs e)
        {
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                fonts.Add(font.Name);
            }
            for (int i = 8; i <= 54; i += 2)
            {
                comboBox2.Items.Add(i);
            }
            foreach (string font in fonts)
            {
                comboBox1.Items.Add(font);
            }
            checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            checkBox2.Appearance = System.Windows.Forms.Appearance.Button;
            checkBox3.Appearance = System.Windows.Forms.Appearance.Button;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(comboBox1.SelectedItem.ToString(),12);
        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int angka;
            angka = (int)comboBox2.SelectedItem;
            richTextBox1.Font = new Font(comboBox1.SelectedItem.ToString(), angka);
        }
    }
}
