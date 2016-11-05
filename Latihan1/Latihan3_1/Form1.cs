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

namespace Latihan_3_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            rtbNote.Font = new Font("Consolas", 12.0f);

            rtbNote.Height = this.Height;
            rtbNote.Width = this.Width;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Color warna = new Color();
            PropertyInfo[] p = warna.GetType().GetProperties();
            InstalledFontCollection font = new InstalledFontCollection();

            for (int i = 8; i <= 72; i++)
            {
                this.font.Items.Add(i);
            }

            foreach (FontFamily f in font.Families)
            {
                ffamily.Items.Add(f.Name);
            }

            color.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;

            foreach (PropertyInfo c in p)
            {
                if (c.PropertyType == typeof(System.Drawing.Color))
                {
                    color.Items.Add(c.Name);
                }
            }

            this.color.ComboBox.DrawItem += new DrawItemEventHandler(tscbColor_DItem);

            color.SelectedIndex = 8;

            this.font.Text = rtbNote.Font.Size.ToString();
            ffamily.Text = rtbNote.Font.Name;

            ubahSize();
            ubahFont();
        }

        private void tscbColor_DItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Graphics g = e.Graphics;
                Brush brush = new SolidBrush(e.BackColor);
                Brush tBrush = new SolidBrush(e.ForeColor);

                g.FillRectangle(brush, e.Bounds);
                string s = (string)this.color.Items[e.Index].ToString();
                SolidBrush b = new SolidBrush(Color.FromName(s));
                e.Graphics.DrawRectangle(Pens.Black, 2, e.Bounds.Top + 1, 20, 11);
                e.Graphics.FillRectangle(b, 3, e.Bounds.Top + 2, 19, 10);
                e.Graphics.DrawString(s, this.Font, Brushes.Black, 25, e.Bounds.Top);
                brush.Dispose();
                tBrush.Dispose();
            }
            e.DrawFocusRectangle();
        }

        private void tsbtnBold_Click(object sender, EventArgs e)
        {
            bold.Checked = !bold.Checked;

            int a = rtbNote.SelectionStart;
            int b = rtbNote.SelectionLength + a;
            if (b - a != 0)
            {
                for (int i = a; i < b; i++)
                {
                    rtbNote.SelectionStart = i;
                    rtbNote.SelectionLength = 1;
                    rtbNote.SelectionFont = new Font(rtbNote.SelectionFont.FontFamily, rtbNote.SelectionFont.Size, rtbNote.SelectionFont.Style ^ FontStyle.Bold);
                }
                rtbNote.SelectionStart = a;
                rtbNote.SelectionLength = b - a;
            }
            else
            {
                FontStyle bold = rtbNote.SelectionFont.Style;
                bold ^= FontStyle.Bold;
                rtbNote.SelectionFont = new Font(rtbNote.SelectionFont.FontFamily, rtbNote.SelectionFont.Size, bold);
            }
        }

        private void tsbtnItalic_Click(object sender, EventArgs e)
        {
            italic.Checked = !italic.Checked;

            int a = rtbNote.SelectionStart;
            int b = rtbNote.SelectionLength + a;
            if (b - a != 0)
            {
                for (int i = a; i < b; i++)
                {
                    rtbNote.SelectionStart = i;
                    rtbNote.SelectionLength = 1;
                    rtbNote.SelectionFont = new Font(rtbNote.SelectionFont.FontFamily, rtbNote.SelectionFont.Size, rtbNote.SelectionFont.Style ^ FontStyle.Italic);
                }
                rtbNote.SelectionStart = a;
                rtbNote.SelectionLength = b - a;
            }
            else
            {
                FontStyle italic = rtbNote.SelectionFont.Style;
                italic ^= FontStyle.Italic;
                rtbNote.SelectionFont = new Font(rtbNote.SelectionFont.FontFamily, rtbNote.SelectionFont.Size, italic);
            }
        }

        private void tsbtnUnderline_Click(object sender, EventArgs e)
        {
            und.Checked = !und.Checked;

            int a = rtbNote.SelectionStart;
            int b = rtbNote.SelectionLength + a;
            if (b - a != 0)
            {
                for (int i = a; i < b; i++)
                {
                    rtbNote.SelectionStart = i;
                    rtbNote.SelectionLength = 1;
                    rtbNote.SelectionFont = new Font(rtbNote.SelectionFont.FontFamily, rtbNote.SelectionFont.Size, rtbNote.SelectionFont.Style ^ FontStyle.Underline);
                }
                rtbNote.SelectionStart = a;
                rtbNote.SelectionLength = b - a;
            }
            else
            {
                FontStyle under = rtbNote.SelectionFont.Style;
                under ^= FontStyle.Underline;
                rtbNote.SelectionFont = new Font(rtbNote.SelectionFont.FontFamily, rtbNote.SelectionFont.Size, under);
            }
        }

        private void tscbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (font.Focused == false)
            {
                return;
            }
            ubahSize();
        }

        private void tscbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ffamily.Focused == false)
            {
                return;
            }
            ubahFont();
        }

        private void tscbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (color.Focused == false)
            {
                return;
            }
            ubahWarna();
        }

        private void ubahSize()
        {
            try
            {
                float size = (font.Text == "") ? 12 : Convert.ToInt16(font.Text);
                int a = rtbNote.SelectionStart;
                int b = rtbNote.SelectionLength + a;
                if (b - a != 0)
                {
                    for (int i = a; i < b; i++)
                    {
                        rtbNote.SelectionStart = i;
                        rtbNote.SelectionLength = 1;
                        rtbNote.SelectionFont = new Font(rtbNote.SelectionFont.FontFamily, size, rtbNote.SelectionFont.Style);
                    }
                    rtbNote.SelectionStart = a;
                    rtbNote.SelectionLength = b - a;
                }
                else
                {
                    rtbNote.SelectionFont = new Font(rtbNote.SelectionFont.FontFamily, size, rtbNote.SelectionFont.Style);
                }
            }
            catch
            {
                return;
            }
        }

        private void ubahFont()
        {
            int a = rtbNote.SelectionStart;
            int b = rtbNote.SelectionLength + a;
            try
            {
                if (b - a != 0)
                {
                    string fnt = ffamily.Text;
                    for (int i = a; i < b; i++)
                    {
                        rtbNote.SelectionStart = i;
                        rtbNote.SelectionLength = 1;
                        rtbNote.SelectionFont = new Font(fnt, rtbNote.SelectionFont.Size, rtbNote.SelectionFont.Style);
                    }
                    rtbNote.SelectionStart = a;
                    rtbNote.SelectionLength = b - a;
                }
                else
                {
                    rtbNote.SelectionFont = new Font(ffamily.Text, rtbNote.SelectionFont.Size, rtbNote.SelectionFont.Style);

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
                rtbNote.SelectionColor = Color.FromName(color.Text);
            }
            catch
            {
                return;
            }
        }

        private void rtbNote_SelectionChanged(object sender, EventArgs e)
        {
            bold.Checked = italic.Checked = und.Checked = false;

            if (rtbNote.SelectionFont == null)
            {
                font.Text = "";
                ffamily.Text = "";
            }
            else
            {
                ffamily.Text = rtbNote.SelectionFont.Name;
                font.Text = rtbNote.SelectionFont.Size.ToString();
                if (rtbNote.SelectionFont.Bold)
                {
                    bold.Checked = true;
                }
                if (rtbNote.SelectionFont.Italic)
                {
                    italic.Checked = true;
                }
                if (rtbNote.SelectionFont.Underline)
                {
                    und.Checked = true;
                }
            }

            if (rtbNote.SelectionColor.Name == "0")
            {
                color.Text = "";
            }
            else
            {
                color.Text = rtbNote.SelectionColor.Name;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            rtbNote.Height = this.Height;
            rtbNote.Width = this.Width;
        }

        private void rtbNote_TextChanged(object sender, EventArgs e)
        {

        }

        private void tscbColor_Click(object sender, EventArgs e)
        {

        }

        private void tscbFontSize_Click(object sender, EventArgs e)
        {

        }
    }
}
