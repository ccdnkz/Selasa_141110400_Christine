namespace Latihan_5_1
{
    partial class frmEditor
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("BackColor");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Theme", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeConfig = new System.Windows.Forms.TreeView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.BackColor = new System.Windows.Forms.TabPage();
            this.lblBackColor = new System.Windows.Forms.Label();
            this.cbBackColor = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.BackColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeConfig
            // 
            this.treeConfig.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeConfig.Location = new System.Drawing.Point(0, 0);
            this.treeConfig.Name = "treeConfig";
            treeNode1.Name = "Node1";
            treeNode1.Text = "BackColor";
            treeNode2.Name = "Node0";
            treeNode2.Text = "Theme";
            this.treeConfig.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeConfig.Size = new System.Drawing.Size(183, 239);
            this.treeConfig.TabIndex = 1;
            this.treeConfig.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 201);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 201);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.BackColor);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl1.Location = new System.Drawing.Point(183, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(346, 239);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 5;
            // 
            // BackColor
            // 
            this.BackColor.Controls.Add(this.lblBackColor);
            this.BackColor.Controls.Add(this.cbBackColor);
            this.BackColor.Location = new System.Drawing.Point(4, 5);
            this.BackColor.Name = "BackColor";
            this.BackColor.Padding = new System.Windows.Forms.Padding(3);
            this.BackColor.Size = new System.Drawing.Size(338, 230);
            this.BackColor.TabIndex = 0;
            this.BackColor.Text = "BackColor";
            this.BackColor.UseVisualStyleBackColor = true;
            // 
            // lblBackColor
            // 
            this.lblBackColor.AutoSize = true;
            this.lblBackColor.Location = new System.Drawing.Point(17, 10);
            this.lblBackColor.Name = "lblBackColor";
            this.lblBackColor.Size = new System.Drawing.Size(65, 13);
            this.lblBackColor.TabIndex = 1;
            this.lblBackColor.Text = "Background";
            // 
            // cbBackColor
            // 
            this.cbBackColor.DropDownHeight = 175;
            this.cbBackColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBackColor.FormattingEnabled = true;
            this.cbBackColor.IntegralHeight = false;
            this.cbBackColor.Location = new System.Drawing.Point(92, 7);
            this.cbBackColor.Name = "cbBackColor";
            this.cbBackColor.Size = new System.Drawing.Size(150, 21);
            this.cbBackColor.TabIndex = 0;
            // 
            // frmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 239);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.treeConfig);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEditor_FormClosed);
            this.Load += new System.EventHandler(this.frmEditor_Load);
            this.tabControl1.ResumeLayout(false);
            this.BackColor.ResumeLayout(false);
            this.BackColor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeConfig;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage BackColor;
        private System.Windows.Forms.Label lblBackColor;
        private System.Windows.Forms.ComboBox cbBackColor;
    }
}