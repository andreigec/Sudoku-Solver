using ANDREICSLIB;

namespace SudokuSolver
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.extToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showInvalidMovesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showPossibleMovesOnHoverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.widthbox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.heightbox = new System.Windows.Forms.TextBox();
			this.creatematrixbutton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.Savebutton = new System.Windows.Forms.Button();
			this.solvebutton = new System.Windows.Forms.Button();
			this.clearmatrix = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.generaterandom = new System.Windows.Forms.Button();
			this.loadbox = new System.Windows.Forms.ComboBox();
			this.loadbutton = new System.Windows.Forms.Button();
			this.removepieces = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.grid = new ANDREICSLIB.PanelUpdates();
			this.menuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.Silver;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(326, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// extToolStripMenuItem
			// 
			this.extToolStripMenuItem.Name = "extToolStripMenuItem";
			this.extToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
			this.extToolStripMenuItem.Text = "Exit";
			this.extToolStripMenuItem.Click += new System.EventHandler(this.extToolStripMenuItem_Click);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInvalidMovesToolStripMenuItem,
            this.showPossibleMovesOnHoverToolStripMenuItem});
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.optionsToolStripMenuItem.Text = "Options";
			// 
			// showInvalidMovesToolStripMenuItem
			// 
			this.showInvalidMovesToolStripMenuItem.Checked = true;
			this.showInvalidMovesToolStripMenuItem.CheckOnClick = true;
			this.showInvalidMovesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showInvalidMovesToolStripMenuItem.Name = "showInvalidMovesToolStripMenuItem";
			this.showInvalidMovesToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
			this.showInvalidMovesToolStripMenuItem.Text = "Show invalid moves";
			this.showInvalidMovesToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showInvalidMovesToolStripMenuItem_CheckedChanged);
			// 
			// showPossibleMovesOnHoverToolStripMenuItem
			// 
			this.showPossibleMovesOnHoverToolStripMenuItem.Checked = true;
			this.showPossibleMovesOnHoverToolStripMenuItem.CheckOnClick = true;
			this.showPossibleMovesOnHoverToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showPossibleMovesOnHoverToolStripMenuItem.Name = "showPossibleMovesOnHoverToolStripMenuItem";
			this.showPossibleMovesOnHoverToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
			this.showPossibleMovesOnHoverToolStripMenuItem.Text = "Show possible moves on hover";
			// 
			// widthbox
			// 
			this.widthbox.Enabled = false;
			this.widthbox.Location = new System.Drawing.Point(9, 32);
			this.widthbox.Name = "widthbox";
			this.widthbox.Size = new System.Drawing.Size(54, 20);
			this.widthbox.TabIndex = 1;
			this.widthbox.Text = "9";
			this.widthbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.widthbox_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Width";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(63, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Height";
			// 
			// heightbox
			// 
			this.heightbox.Enabled = false;
			this.heightbox.Location = new System.Drawing.Point(66, 32);
			this.heightbox.Name = "heightbox";
			this.heightbox.Size = new System.Drawing.Size(47, 20);
			this.heightbox.TabIndex = 3;
			this.heightbox.Text = "9";
			this.heightbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.heightbox_KeyPress);
			// 
			// creatematrixbutton
			// 
			this.creatematrixbutton.Location = new System.Drawing.Point(193, 30);
			this.creatematrixbutton.Name = "creatematrixbutton";
			this.creatematrixbutton.Size = new System.Drawing.Size(109, 23);
			this.creatematrixbutton.TabIndex = 5;
			this.creatematrixbutton.Text = "Create Matrix";
			this.creatematrixbutton.UseVisualStyleBackColor = true;
			this.creatematrixbutton.Click += new System.EventHandler(this.creatematrixbutton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.Savebutton);
			this.groupBox1.Controls.Add(this.solvebutton);
			this.groupBox1.Controls.Add(this.clearmatrix);
			this.groupBox1.Location = new System.Drawing.Point(12, 157);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(305, 49);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Puzzle Operations";
			// 
			// Savebutton
			// 
			this.Savebutton.Location = new System.Drawing.Point(224, 19);
			this.Savebutton.Name = "Savebutton";
			this.Savebutton.Size = new System.Drawing.Size(75, 23);
			this.Savebutton.TabIndex = 2;
			this.Savebutton.Text = "Save Grid";
			this.Savebutton.UseVisualStyleBackColor = true;
			this.Savebutton.Click += new System.EventHandler(this.Savebutton_Click);
			// 
			// solvebutton
			// 
			this.solvebutton.Location = new System.Drawing.Point(87, 19);
			this.solvebutton.Name = "solvebutton";
			this.solvebutton.Size = new System.Drawing.Size(75, 23);
			this.solvebutton.TabIndex = 1;
			this.solvebutton.Text = "Solve";
			this.solvebutton.UseVisualStyleBackColor = true;
			this.solvebutton.Click += new System.EventHandler(this.solvebutton_Click);
			// 
			// clearmatrix
			// 
			this.clearmatrix.Location = new System.Drawing.Point(6, 19);
			this.clearmatrix.Name = "clearmatrix";
			this.clearmatrix.Size = new System.Drawing.Size(75, 23);
			this.clearmatrix.TabIndex = 0;
			this.clearmatrix.Text = "Clear Matrix";
			this.clearmatrix.UseVisualStyleBackColor = true;
			this.clearmatrix.Click += new System.EventHandler(this.clearmatrix_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 91);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(101, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Pieces To Remove:";
			// 
			// generaterandom
			// 
			this.generaterandom.Location = new System.Drawing.Point(193, 86);
			this.generaterandom.Name = "generaterandom";
			this.generaterandom.Size = new System.Drawing.Size(109, 23);
			this.generaterandom.TabIndex = 2;
			this.generaterandom.Text = "Generate Random";
			this.generaterandom.UseVisualStyleBackColor = true;
			this.generaterandom.Click += new System.EventHandler(this.generaterandom_Click);
			// 
			// loadbox
			// 
			this.loadbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.loadbox.FormattingEnabled = true;
			this.loadbox.Location = new System.Drawing.Point(9, 59);
			this.loadbox.Name = "loadbox";
			this.loadbox.Size = new System.Drawing.Size(178, 21);
			this.loadbox.TabIndex = 8;
			this.loadbox.Click += new System.EventHandler(this.loadbox_Click);
			// 
			// loadbutton
			// 
			this.loadbutton.Location = new System.Drawing.Point(193, 57);
			this.loadbutton.Name = "loadbutton";
			this.loadbutton.Size = new System.Drawing.Size(109, 23);
			this.loadbutton.TabIndex = 9;
			this.loadbutton.Text = "Load";
			this.loadbutton.UseVisualStyleBackColor = true;
			this.loadbutton.Click += new System.EventHandler(this.loadbutton_Click);
			// 
			// removepieces
			// 
			this.removepieces.Location = new System.Drawing.Point(119, 88);
			this.removepieces.MaxLength = 5;
			this.removepieces.Name = "removepieces";
			this.removepieces.Size = new System.Drawing.Size(68, 20);
			this.removepieces.TabIndex = 10;
			this.removepieces.Text = "60";
			this.removepieces.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.removepieces_KeyPress);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.removepieces);
			this.groupBox2.Controls.Add(this.widthbox);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.heightbox);
			this.groupBox2.Controls.Add(this.loadbutton);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.loadbox);
			this.groupBox2.Controls.Add(this.creatematrixbutton);
			this.groupBox2.Controls.Add(this.generaterandom);
			this.groupBox2.Location = new System.Drawing.Point(12, 27);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(305, 124);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Puzzle loading";
			// 
			// grid
			// 
			this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grid.Location = new System.Drawing.Point(12, 212);
			this.grid.Name = "grid";
			this.grid.Size = new System.Drawing.Size(305, 200);
			this.grid.TabIndex = 6;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(326, 424);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grid);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem extToolStripMenuItem;
		private System.Windows.Forms.TextBox widthbox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox heightbox;
		private System.Windows.Forms.Button creatematrixbutton;
		public PanelUpdates grid;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem showInvalidMovesToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button clearmatrix;
		private System.Windows.Forms.Button solvebutton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button generaterandom;
		public System.Windows.Forms.ToolStripMenuItem showPossibleMovesOnHoverToolStripMenuItem;
		private System.Windows.Forms.ComboBox loadbox;
		private System.Windows.Forms.Button loadbutton;
		private System.Windows.Forms.TextBox removepieces;
		private System.Windows.Forms.Button Savebutton;
		private System.Windows.Forms.GroupBox groupBox2;
	}
}

