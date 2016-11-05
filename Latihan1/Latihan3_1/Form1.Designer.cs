namespace Latihan_3_1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rtbNote = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.font = new System.Windows.Forms.ToolStripComboBox();
            this.bold = new System.Windows.Forms.ToolStripButton();
            this.italic = new System.Windows.Forms.ToolStripButton();
            this.und = new System.Windows.Forms.ToolStripButton();
            this.ffamily = new System.Windows.Forms.ToolStripComboBox();
            this.color = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbNote
            // 
            this.rtbNote.Location = new System.Drawing.Point(0, 28);
            this.rtbNote.Name = "rtbNote";
            this.rtbNote.Size = new System.Drawing.Size(530, 381);
            this.rtbNote.TabIndex = 0;
            this.rtbNote.Text = "";
            this.rtbNote.SelectionChanged += new System.EventHandler(this.rtbNote_SelectionChanged);
            this.rtbNote.TextChanged += new System.EventHandler(this.rtbNote_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.font,
            this.bold,
            this.italic,
            this.und,
            this.ffamily,
            this.color});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(542, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // font
            // 
            this.font.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.font.Name = "font";
            this.font.Size = new System.Drawing.Size(121, 25);
            this.font.SelectedIndexChanged += new System.EventHandler(this.tscbFontSize_SelectedIndexChanged);
            this.font.Click += new System.EventHandler(this.tscbFontSize_Click);
            // 
            // bold
            // 
            this.bold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bold.Image = ((System.Drawing.Image)(resources.GetObject("bold.Image")));
            this.bold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bold.Name = "bold";
            this.bold.Size = new System.Drawing.Size(23, 22);
            this.bold.Text = "B";
            this.bold.Click += new System.EventHandler(this.tsbtnBold_Click);
            // 
            // italic
            // 
            this.italic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.italic.Image = ((System.Drawing.Image)(resources.GetObject("italic.Image")));
            this.italic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.italic.Name = "italic";
            this.italic.Size = new System.Drawing.Size(23, 22);
            this.italic.Text = "toolStripButton2";
            this.italic.Click += new System.EventHandler(this.tsbtnItalic_Click);
            // 
            // und
            // 
            this.und.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.und.Image = ((System.Drawing.Image)(resources.GetObject("und.Image")));
            this.und.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.und.Name = "und";
            this.und.Size = new System.Drawing.Size(23, 22);
            this.und.Text = "toolStripButton3";
            this.und.Click += new System.EventHandler(this.tsbtnUnderline_Click);
            // 
            // ffamily
            // 
            this.ffamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ffamily.Name = "ffamily";
            this.ffamily.Size = new System.Drawing.Size(200, 25);
            this.ffamily.SelectedIndexChanged += new System.EventHandler(this.tscbFont_SelectedIndexChanged);
            // 
            // color
            // 
            this.color.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.color.Name = "color";
            this.color.Size = new System.Drawing.Size(121, 25);
            this.color.SelectedIndexChanged += new System.EventHandler(this.tscbColor_SelectedIndexChanged);
            this.color.Click += new System.EventHandler(this.tscbColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 421);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.rtbNote);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Latihan_3_1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbNote;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox font;
        private System.Windows.Forms.ToolStripButton bold;
        private System.Windows.Forms.ToolStripButton italic;
        private System.Windows.Forms.ToolStripButton und;
        private System.Windows.Forms.ToolStripComboBox ffamily;
        private System.Windows.Forms.ToolStripComboBox color;
    }
}

