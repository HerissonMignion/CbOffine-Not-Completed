namespace CbOffice.PowerPoint.Resource
{
	partial class pageResource
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
			this.BackButton = new CbOffice.CbButton2();
			this.SuspendLayout();
			// 
			// BackButton
			// 
			this.BackButton.BorderColor = System.Drawing.Color.DimGray;
			this.BackButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
			this.BackButton.FlatAppearance.BorderSize = 0;
			this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BackButton.IsMouseHandWhenOnButton = false;
			this.BackButton.Location = new System.Drawing.Point(2, 2);
			this.BackButton.MouseDownBorderColor = System.Drawing.Color.DimGray;
			this.BackButton.MouseOnBorderColor = System.Drawing.Color.Black;
			this.BackButton.Name = "BackButton";
			this.BackButton.Size = new System.Drawing.Size(97, 23);
			this.BackButton.TabIndex = 0;
			this.BackButton.Text = "<---   Retour";
			this.BackButton.UseVisualStyleBackColor = true;
			this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
			// 
			// pageResource
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 517);
			this.Controls.Add(this.BackButton);
			this.Name = "pageResource";
			this.Text = "Power Point Resources";
			this.Load += new System.EventHandler(this.pageResource_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private CbButton2 BackButton;
	}
}