namespace CbOffice.PowerPoint
{
	partial class pageProgPowerPoint
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pageProgPowerPoint));
			this.MenuBar = new System.Windows.Forms.ToolStrip();
			this.ddbFile = new System.Windows.Forms.ToolStripDropDownButton();
			this.ddbNew = new System.Windows.Forms.ToolStripMenuItem();
			this.ddbOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.ddbSave = new System.Windows.Forms.ToolStripMenuItem();
			this.ddbSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ddbHome = new System.Windows.Forms.ToolStripMenuItem();
			this.ddbResource = new System.Windows.Forms.ToolStripDropDownButton();
			this.ddbViewResources = new System.Windows.Forms.ToolStripMenuItem();
			this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
			this.EditorSplitContainer = new System.Windows.Forms.SplitContainer();
			this.buttonNewSlide = new CbOffice.CbButton2();
			this.MenuBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
			this.MainSplitContainer.Panel1.SuspendLayout();
			this.MainSplitContainer.Panel2.SuspendLayout();
			this.MainSplitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.EditorSplitContainer)).BeginInit();
			this.EditorSplitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// MenuBar
			// 
			this.MenuBar.BackColor = System.Drawing.Color.Gainsboro;
			this.MenuBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddbFile,
            this.ddbResource});
			this.MenuBar.Location = new System.Drawing.Point(0, 0);
			this.MenuBar.Name = "MenuBar";
			this.MenuBar.ShowItemToolTips = false;
			this.MenuBar.Size = new System.Drawing.Size(800, 25);
			this.MenuBar.TabIndex = 0;
			this.MenuBar.Text = "MenuBar";
			// 
			// ddbFile
			// 
			this.ddbFile.AutoToolTip = false;
			this.ddbFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ddbFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddbNew,
            this.ddbOpen,
            this.ddbSave,
            this.ddbSaveAs,
            this.toolStripSeparator1,
            this.ddbHome});
			this.ddbFile.Image = ((System.Drawing.Image)(resources.GetObject("ddbFile.Image")));
			this.ddbFile.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ddbFile.Name = "ddbFile";
			this.ddbFile.Size = new System.Drawing.Size(55, 22);
			this.ddbFile.Text = "Fichier";
			// 
			// ddbNew
			// 
			this.ddbNew.Name = "ddbNew";
			this.ddbNew.Size = new System.Drawing.Size(166, 22);
			this.ddbNew.Text = "Nouveau";
			this.ddbNew.Click += new System.EventHandler(this.ddbNew_Click);
			// 
			// ddbOpen
			// 
			this.ddbOpen.Name = "ddbOpen";
			this.ddbOpen.Size = new System.Drawing.Size(166, 22);
			this.ddbOpen.Text = "Ouvrire";
			this.ddbOpen.Click += new System.EventHandler(this.ddbOpen_Click);
			// 
			// ddbSave
			// 
			this.ddbSave.Name = "ddbSave";
			this.ddbSave.Size = new System.Drawing.Size(166, 22);
			this.ddbSave.Text = "Enregistrer";
			this.ddbSave.Click += new System.EventHandler(this.ddbSave_Click);
			// 
			// ddbSaveAs
			// 
			this.ddbSaveAs.Name = "ddbSaveAs";
			this.ddbSaveAs.Size = new System.Drawing.Size(166, 22);
			this.ddbSaveAs.Text = "Enregistrer sous...";
			this.ddbSaveAs.Click += new System.EventHandler(this.ddbSaveAs_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(163, 6);
			// 
			// ddbHome
			// 
			this.ddbHome.Name = "ddbHome";
			this.ddbHome.Size = new System.Drawing.Size(166, 22);
			this.ddbHome.Text = "Accueil";
			this.ddbHome.Click += new System.EventHandler(this.ddbHome_Click);
			// 
			// ddbResource
			// 
			this.ddbResource.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ddbResource.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddbViewResources});
			this.ddbResource.Image = ((System.Drawing.Image)(resources.GetObject("ddbResource.Image")));
			this.ddbResource.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ddbResource.Name = "ddbResource";
			this.ddbResource.Size = new System.Drawing.Size(78, 22);
			this.ddbResource.Text = "Ressources";
			// 
			// ddbViewResources
			// 
			this.ddbViewResources.Name = "ddbViewResources";
			this.ddbViewResources.Size = new System.Drawing.Size(203, 22);
			this.ddbViewResources.Text = "Afficher les ressources ...";
			this.ddbViewResources.Click += new System.EventHandler(this.ddbViewResources_Click);
			// 
			// MainSplitContainer
			// 
			this.MainSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.MainSplitContainer.Location = new System.Drawing.Point(0, 25);
			this.MainSplitContainer.Name = "MainSplitContainer";
			// 
			// MainSplitContainer.Panel1
			// 
			this.MainSplitContainer.Panel1.BackColor = System.Drawing.Color.Gainsboro;
			this.MainSplitContainer.Panel1.Controls.Add(this.buttonNewSlide);
			// 
			// MainSplitContainer.Panel2
			// 
			this.MainSplitContainer.Panel2.Controls.Add(this.EditorSplitContainer);
			this.MainSplitContainer.Size = new System.Drawing.Size(800, 476);
			this.MainSplitContainer.SplitterDistance = 206;
			this.MainSplitContainer.SplitterWidth = 8;
			this.MainSplitContainer.TabIndex = 1;
			// 
			// EditorSplitContainer
			// 
			this.EditorSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.EditorSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EditorSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.EditorSplitContainer.Location = new System.Drawing.Point(0, 0);
			this.EditorSplitContainer.Name = "EditorSplitContainer";
			this.EditorSplitContainer.Size = new System.Drawing.Size(586, 476);
			this.EditorSplitContainer.SplitterDistance = 392;
			this.EditorSplitContainer.SplitterWidth = 8;
			this.EditorSplitContainer.TabIndex = 0;
			// 
			// buttonNewSlide
			// 
			this.buttonNewSlide.BorderColor = System.Drawing.Color.DimGray;
			this.buttonNewSlide.Cursor = System.Windows.Forms.Cursors.Default;
			this.buttonNewSlide.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
			this.buttonNewSlide.FlatAppearance.BorderSize = 0;
			this.buttonNewSlide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonNewSlide.IsMouseHandWhenOnButton = false;
			this.buttonNewSlide.Location = new System.Drawing.Point(3, 3);
			this.buttonNewSlide.MouseDownBorderColor = System.Drawing.Color.DimGray;
			this.buttonNewSlide.MouseOnBorderColor = System.Drawing.Color.Black;
			this.buttonNewSlide.Name = "buttonNewSlide";
			this.buttonNewSlide.Size = new System.Drawing.Size(88, 20);
			this.buttonNewSlide.TabIndex = 0;
			this.buttonNewSlide.Text = "Nouvelle page";
			this.buttonNewSlide.UseVisualStyleBackColor = true;
			this.buttonNewSlide.Click += new System.EventHandler(this.buttonNewSlide_Click);
			// 
			// pageProgPowerPoint
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 501);
			this.Controls.Add(this.MainSplitContainer);
			this.Controls.Add(this.MenuBar);
			this.Name = "pageProgPowerPoint";
			this.Text = "CB Power Point";
			this.Load += new System.EventHandler(this.pageProgPowerPoint_Load);
			this.MenuBar.ResumeLayout(false);
			this.MenuBar.PerformLayout();
			this.MainSplitContainer.Panel1.ResumeLayout(false);
			this.MainSplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
			this.MainSplitContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.EditorSplitContainer)).EndInit();
			this.EditorSplitContainer.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip MenuBar;
		private System.Windows.Forms.ToolStripDropDownButton ddbFile;
		private System.Windows.Forms.ToolStripMenuItem ddbNew;
		private System.Windows.Forms.ToolStripMenuItem ddbOpen;
		private System.Windows.Forms.ToolStripMenuItem ddbSave;
		private System.Windows.Forms.ToolStripMenuItem ddbSaveAs;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem ddbHome;
		private System.Windows.Forms.SplitContainer MainSplitContainer;
		private CbButton2 buttonNewSlide;
		private System.Windows.Forms.ToolStripDropDownButton ddbResource;
		private System.Windows.Forms.ToolStripMenuItem ddbViewResources;
		private System.Windows.Forms.SplitContainer EditorSplitContainer;
	}
}