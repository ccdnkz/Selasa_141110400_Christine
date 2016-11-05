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
using System.Reflection;
using System.IO;
namespace Latihan3_1
{
    public partial class Form1 : Form
    {
        List<string> fonts = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Color wrn = new Color();
            PropertyInfo[] p = wrn.GetType().GetProperties();
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
            comboBox3.DrawMode = DrawMode.OwnerDrawFixed;

            foreach (PropertyInfo c in p)
            {
                if (c.PropertyType == typeof(System.Drawing.Color))
                {
                    comboBox3.Items.Add(c.Name);
                }
            }

            this.comboBox3.DrawItem += new DrawItemEventHandler(comboBox3_DItem);

            comboBox3.SelectedIndex = 8;
            
            comboBox2.Text = richTextBox1.Font.Size.ToString();
            comboBox1.Text = richTextBox1.Font.Name;

            ubahSize();
            ubahFont();
        }
        private void comboBox3_DItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Graphics g = e.Graphics;
                Brush brush = new SolidBrush(e.BackColor);
                Brush tBrush = new SolidBrush(e.ForeColor);

                g.FillRectangle(brush, e.Bounds);
                string s = (string)this.comboBox3.Items[e.Index].ToString();
                SolidBrush b = new SolidBrush(Color.FromName(s));
                e.Graphics.DrawRectangle(Pens.Black, 2, e.Bounds.Top + 1, 20, 11);
                e.Graphics.FillRectangle(b, 3, e.Bounds.Top + 2, 19, 10);
                e.Graphics.DrawString(s, this.Font, Brushes.Black, 25, e.Bounds.Top);
                brush.Dispose();
                tBrush.Dispose();
            }
            e.DrawFocusRectangle();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Focused == false)
            {
                return;
            }
            ubahFont();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int a = richTextBox1.SelectionStart;
            int b = richTextBox1.SelectionLength + a;
            if (b - a != 0)
            {
                for (int i = a; i < b; i++)
                {
                    richTextBox1.SelectionStart = i;
                    richTextBox1.SelectionLength = 1;
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style ^ FontStyle.Bold);
                }
                richTextBox1.SelectionStart = a;
                richTextBox1.SelectionLength = b - a;
            }
            else
            {
                FontStyle bold = richTextBox1.SelectionFont.Style;
                bold ^= FontStyle.Bold;
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, bold);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Focused == false)
            {
                return;
            }
            ubahSize();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            int a = richTextBox1.SelectionStart;
            int b = richTextBox1.SelectionLength + a;
            if (b - a != 0)
            {
                for (int i = a; i < b; i++)
                {
                    richTextBox1.SelectionStart = i;
                    richTextBox1.SelectionLength = 1;
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style ^ FontStyle.Italic);
                }
                richTextBox1.SelectionStart = a;
                richTextBox1.SelectionLength = b - a;
            }
            else
            {
                FontStyle itc = richTextBox1.SelectionFont.Style;
                itc ^= FontStyle.Italic;
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, itc);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            int a = richTextBox1.SelectionStart;
            int b = richTextBox1.SelectionLength + a;
            if (b - a != 0)
            {
                for (int i = a; i < b; i++)
                {
                    richTextBox1.SelectionStart = i;
                    richTextBox1.SelectionLength = 1;
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style ^ FontStyle.Underline);
                }
                richTextBox1.SelectionStart = a;
                richTextBox1.SelectionLength = b - a;
            }
            else
            {
                FontStyle und = richTextBox1.SelectionFont.Style;
                und ^= FontStyle.Underline;
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, und);
            }
        }
        private void ubahFont()
        {
            int a = richTextBox1.SelectionStart;
            int b = richTextBox1.SelectionLength + a;
            try
            {
                if (b - a != 0)
                {
                    string fnt = comboBox1.Text;
                    for (int i = a; i < b; i++)
                    {
                        richTextBox1.SelectionStart = i;
                        richTextBox1.SelectionLength = 1;
                        richTextBox1.SelectionFont = new Font(fnt, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
                    }
                    richTextBox1.SelectionStart = a;
                    richTextBox1.SelectionLength = b - a;
                }
                else
                {
                    richTextBox1.SelectionFont = new Font(comboBox1.Text, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);

                }
            }
            catch
            {
                return;
            }
        }

        private void ubahWarna()
        {
            try
            {
                richTextBox1.SelectionColor = Color.FromName(comboBox3.Text);
            }
            catch
            {
                return;
            }
        }
        private void ubahSize()
        {
            try
            {
                float size = (comboBox2.Text == "") ? 12 : Convert.ToInt16(comboBox2.Text);
                int a = richTextBox1.SelectionStart;
                int b = richTextBox1.SelectionLength + a;
                if (b - a != 0)
                {
                    for (int i = a; i < b; i++)
                    {
                        richTextBox1.SelectionStart = i;
                        richTextBox1.SelectionLength = 1;
                        richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, size, richTextBox1.SelectionFont.Style);
                    }
                    richTextBox1.SelectionStart = a;
                    richTextBox1.SelectionLength = b - a;
                }
                else
                {
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, size, richTextBox1.SelectionFont.Style);
                }
            }
            catch
            {
                return;
            }
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = checkBox2.Checked = checkBox3.Checked = false;

            if (richTextBox1.SelectionFont == null)
            {
                comboBox2.Text = "";
                comboBox1.Text = "";
            }
            else
            {
                comboBox1.Text = richTextBox1.SelectionFont.Name;
                comboBox2.Text = richTextBox1.SelectionFont.Size.ToString();
                if (richTextBox1.SelectionFont.Bold)
                {
                    checkBox1.Checked = true;
                }
                if (richTextBox1.SelectionFont.Italic)
                {
                    checkBox2.Checked = true;
                }
                if (richTextBox1.SelectionFont.Underline)
                {
                    checkBox3.Checked = true;
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Focused == false)
            {
                return;
            }
            ubahWarna();
        }
    }
}
