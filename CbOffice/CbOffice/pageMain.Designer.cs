namespace CbOffice
{
	partial class pageMain
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
			this.MainButtonPanel = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonPowerPoint = new CbOffice.CbButton2();
			this.MainButtonPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainButtonPanel
			// 
			this.MainButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MainButtonPanel.ColumnCount = 2;
			this.MainButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.MainButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.MainButtonPanel.Controls.Add(this.buttonPowerPoint, 0, 0);
			this.MainButtonPanel.Location = new System.Drawing.Point(12, 97);
			this.MainButtonPanel.Name = "MainButtonPanel";
			this.MainButtonPanel.RowCount = 2;
			this.MainButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.MainButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.MainButtonPanel.Size = new System.Drawing.Size(776, 437);
			this.MainButtonPanel.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(245, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(306, 73);
			this.label1.TabIndex = 1;
			this.label1.Text = "CB Office";
			// 
			// buttonPowerPoint
			// 
			this.buttonPowerPoint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
			this.buttonPowerPoint.BorderColor = System.Drawing.Color.DimGray;
			this.buttonPowerPoint.Cursor = System.Windows.Forms.Cursors.Default;
			this.buttonPowerPoint.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonPowerPoint.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
			this.buttonPowerPoint.FlatAppearance.BorderSize = 0;
			this.buttonPowerPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonPowerPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonPowerPoint.IsMouseHandWhenOnButton = false;
			this.buttonPowerPoint.Location = new System.Drawing.Point(3, 3);
			this.buttonPowerPoint.MouseDownBorderColor = System.Drawing.Color.DimGray;
			this.buttonPowerPoint.MouseOnBorderColor = System.Drawing.Color.Black;
			this.buttonPowerPoint.Name = "buttonPowerPoint";
			this.buttonPowerPoint.Size = new System.Drawing.Size(382, 212);
			this.buttonPowerPoint.TabIndex = 0;
			this.buttonPowerPoint.Text = "Power Point";
			this.buttonPowerPoint.UseVisualStyleBackColor = false;
			this.buttonPowerPoint.Click += new System.EventHandler(this.buttonPowerPoint_Click);
			// 
			// pageMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.ClientSize = new System.Drawing.Size(800, 546);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.MainButtonPanel);
			this.Name = "pageMain";
			this.Text = "Accueil";
			this.Load += new System.EventHandler(this.pageMain_Load);
			this.MainButtonPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel MainButtonPanel;
		private System.Windows.Forms.Label label1;
		private CbButton2 buttonPowerPoint;
	}
}