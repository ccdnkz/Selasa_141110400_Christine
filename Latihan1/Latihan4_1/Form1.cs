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

namespace Latihan_4_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            richfield.Font = new Font("Consolas", 12.0f);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Color warna = new Color();
            PropertyInfo[] p = warna.GetType().GetProperties();
            InstalledFontCollection font = new InstalledFontCollection();

            for (int i = 8; i <= 72; i++)
            {
                fontsize.Items.Add(i);
            }

            foreach (FontFamily f in font.Families)
            {
                this.ffamily.Items.Add(f.Name);
            }

            color.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            bcolor.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;

            foreach (PropertyInfo c in p)
            {
                if (c.PropertyType == typeof(System.Drawing.Color))
                {
                    color.Items.Add(c.Name);
                    bcolor.Items.Add(c.Name);
                }
            }

            this.color.ComboBox.DrawItem += new DrawItemEventHandler(tscbColor_DItem);
            this.bcolor.ComboBox.DrawItem += new DrawItemEventHandler(tscbBackColor_DItem);

            color.SelectedIndex = 8;
            bcolor.SelectedIndex = 0;

            fontsize.Text = richfield.Font.Size.ToString();
            this.ffamily.Text = richfield.Font.Name;

            ubahSize();
            ubahFont();
            edit = false;
            fileExist = "";
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            richfield.Height = this.Height - 105;
            richfield.Width = this.Width - 35;
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

        private void tscbBackColor_DItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Graphics g = e.Graphics;
                Brush brush = new SolidBrush(e.BackColor);
                Brush tBrush = new SolidBrush(e.ForeColor);

                g.FillRectangle(brush, e.Bounds);
                string s = (string)this.bcolor.Items[e.Index].ToString();
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

            int a = richfield.SelectionStart;
            int b = richfield.SelectionLength + a;
            if (b - a != 0)
            {
                for (int i = a; i < b; i++)
                {
                    richfield.SelectionStart = i;
                    richfield.SelectionLength = 1;
                    richfield.SelectionFont = new Font(richfield.SelectionFont.FontFamily, richfield.SelectionFont.Size, richfield.SelectionFont.Style ^ FontStyle.Bold);
                }
                richfield.SelectionStart = a;
                richfield.SelectionLength = b - a;
            }
            else
            {
                FontStyle bold = richfield.SelectionFont.Style;
                bold ^= FontStyle.Bold;
                richfield.SelectionFont = new Font(richfield.SelectionFont.FontFamily, richfield.SelectionFont.Size, bold);
            }
            edit = true;
        }

        private void tsbtnItalic_Click(object sender, EventArgs e)
        {
            italic.Checked = !italic.Checked;

            int a = richfield.SelectionStart;
            int b = richfield.SelectionLength + a;
            if (b - a != 0)
            {
                for (int i = a; i < b; i++)
                {
                    richfield.SelectionStart = i;
                    richfield.SelectionLength = 1;
                    richfield.SelectionFont = new Font(richfield.SelectionFont.FontFamily, richfield.SelectionFont.Size, richfield.SelectionFont.Style ^ FontStyle.Italic);
                }
                richfield.SelectionStart = a;
                richfield.SelectionLength = b - a;
            }
            else
            {
                FontStyle italic = richfield.SelectionFont.Style;
                italic ^= FontStyle.Italic;
                richfield.SelectionFont = new Font(richfield.SelectionFont.FontFamily, richfield.SelectionFont.Size, italic);
            }
            edit = true;
        }

        private void tsbtnUnderline_Click(object sender, EventArgs e)
        {
            und.Checked = !und.Checked;

            int a = richfield.SelectionStart;
            int b = richfield.SelectionLength + a;
            if (b - a != 0)
            {
                for (int i = a; i < b; i++)
                {
                    richfield.SelectionStart = i;
                    richfield.SelectionLength = 1;
                    richfield.SelectionFont = new Font(richfield.SelectionFont.FontFamily, richfield.SelectionFont.Size, richfield.SelectionFont.Style ^ FontStyle.Underline);
                }
                richfield.SelectionStart = a;
                richfield.SelectionLength = b - a;
            }
            else
            {
                FontStyle under = richfield.SelectionFont.Style;
                under ^= FontStyle.Underline;
                richfield.SelectionFont = new Font(richfield.SelectionFont.FontFamily, richfield.SelectionFont.Size, under);
            }
            edit = true;
        }

        private void tscbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fontsize.Focused == false)
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

        private void tscbBackColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bcolor.Focused == false)
            {
                return;
            }
            ubahWarnaLatar();
        }

        private void rtbNote_SelectionChanged(object sender, EventArgs e)
        {
            bold.Checked = italic.Checked = und.Checked = false;

            if (richfield.SelectionFont == null)
            {
                fontsize.Text = "";
                ffamily.Text = "";
            }
            else
            {
                ffamily.Text = richfield.SelectionFont.Name;
                fontsize.Text = richfield.SelectionFont.Size.ToString();
                if (richfield.SelectionFont.Bold)
                {
                    bold.Checked = true;
                }
                if (richfield.SelectionFont.Italic)
                {
                    italic.Checked = true;
                }
                if (richfield.SelectionFont.Underline)
                {
                    und.Checked = true;
                }
            }

            if (richfield.SelectionColor.Name == "0")
            {
                color.Text = "";
            }
            else
            {
                color.Text = richfield.SelectionColor.Name;
            }
        }

        private void rtbNote_TextChanged(object sender, EventArgs e)
        {
            edit = true;
        }

        private void ubahSize()
        {
            try
            {
                float size = (fontsize.Text == "") ? 12 : Convert.ToInt16(fontsize.Text);
                int a = richfield.SelectionStart;
                int b = richfield.SelectionLength + a;
                if (b - a != 0)
                {
                    for (int i = a; i < b; i++)
                    {
                        richfield.SelectionStart = i;
                        richfield.SelectionLength = 1;
                        richfield.SelectionFont = new Font(richfield.SelectionFont.FontFamily, size, richfield.SelectionFont.Style);
                    }
                    richfield.SelectionStart = a;
                    richfield.SelectionLength = b - a;
                }
                else
                {
                    richfield.SelectionFont = new Font(richfield.SelectionFont.FontFamily, size, richfield.SelectionFont.Style);
                }
                edit = true;
            }
            catch
            {
                return;
            }
        }

        private void ubahFont()
        {
            int a = richfield.SelectionStart;
            int b = richfield.SelectionLength + a;
            try
            {
                if (b - a != 0)
                {
                    string fnt = ffamily.Text;
                    for (int i = a; i < b; i++)
                    {
                        richfield.SelectionStart = i;
                        richfield.SelectionLength = 1;
                        richfield.SelectionFont = new Font(fnt, richfield.SelectionFont.Size, richfield.SelectionFont.Style);
                    }
                    richfield.SelectionStart = a;
                    richfield.SelectionLength = b - a;
                }
                else
                {
                    richfield.SelectionFont = new Font(ffamily.Text, richfield.SelectionFont.Size, richfield.SelectionFont.Style);
                }
                edit = true;
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
                richfield.SelectionColor = Color.FromName(color.Text);
                edit = true;
            }
            catch
            {
                return;
            }
        }

        private void ubahWarnaLatar()
        {
            try
            {
                richfield.SelectionBackColor = Color.FromName(bcolor.Text);
                edit = true;
            }
            catch
            {
                return;
            }
        }
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                DialogResult result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    save();
                }
                else if(result == DialogResult.Cancel)
                {
                    return;
                }
            }
            Environment.Exit(0);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (changeConf() == "cancel") return;

            richfield.Clear();
            fileExist = "";
            edit = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (changeConf() == "cancel") return;

            edit = false;

            OpenFileDialog bukaFile = new OpenFileDialog();
            bukaFile.Filter = "Rich Text Format (*.rtf)|*.rtf";

            DialogResult r = bukaFile.ShowDialog();
            if (r == DialogResult.OK)
            {
                StreamReader rtb = new StreamReader(bukaFile.FileName);
                richfield.Rtf = rtb.ReadToEnd();
                rtb.Close();
                fileExist = bukaFile.FileName;

                richfield.SelectionStart = richfield.TextLength;
                fileExist = "";
            }
            else if (r == DialogResult.Cancel)
            {
                edit = true;

            }
            
        }
        
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save();
        }

        static string fileExist = "";
        static bool edit = false;

        private void save()
        {
            SaveFileDialog simpan = new SaveFileDialog();
            simpan.Filter = "Rich Text Format (*.rtf)|*.rtf";
            simpan.DefaultExt = "*.rtf";
            simpan.Title = "Save As...";

            if (fileExist == "")
            {
                if (simpan.ShowDialog() == DialogResult.OK && simpan.FileName.Length > 0)
                {
                    richfield.SaveFile(simpan.FileName);
                    fileExist = simpan.FileName;
                    edit = false;
                }
            }
            else if (File.Exists(fileExist) && edit)
            {
                richfield.SaveFile(fileExist);
                edit = false;
            }
            else if (File.Exists(fileExist) && !edit)
            {
                return;
            }
            else
            {
                MessageBox.Show("Sorry, something went wrong");
            }
        }

        private string changeConf()
        {
            if (edit)
            {
                DialogResult result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    save();
                    return "yes";
                }
                else if (result == DialogResult.Cancel)
                {
                    return "cancel";
                }
                else
                {
                    return "no";
                }
            }
            return "-";
        }
    }
}
