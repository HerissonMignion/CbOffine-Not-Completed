using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using CbOffice.PowerPoint.SlideControl;

namespace CbOffice.PowerPoint
{

	//paneau dans lequel l'utilisateur click sur un object à ajouter à la slide

	public class uioEditerObjectSelectPanel
	{
		
		private oPowerPointProject zzzTheProject;
		public oPowerPointProject TheProject { get { return this.zzzTheProject; } }
		private oEditContext zzzTheEContext;
		public oEditContext TheEContext { get { return this.zzzTheEContext; } }




		private GroupBox MainContainer;
		private CbButton2 CancelButton;
		private CbButton2 ButtonAddText;



		public Control Parent
		{
			get { return this.MainContainer.Parent; }
			set { this.MainContainer.Parent = value; }
		}
		public int Top
		{
			get { return this.MainContainer.Top; }
			set { this.MainContainer.Top = value; }
		}
		public int Left
		{
			get { return this.MainContainer.Left; }
			set { this.MainContainer.Left = value; }
		}
		public int Width
		{
			get { return this.MainContainer.Width; }
			set { this.MainContainer.Width = value; }
		}
		public int Height
		{
			get { return this.MainContainer.Height; }
			private set { this.MainContainer.Height = value; }
		}
		public Point Location
		{
			get { return this.MainContainer.Location; }
			set { this.MainContainer.Location = value; }
		}
		public AnchorStyles Anchor
		{
			get { return this.MainContainer.Anchor; }
			set { this.MainContainer.Anchor = value; }
		}


		private int ButtonTop { get { return 15; } }



		//void new()
		public uioEditerObjectSelectPanel(oPowerPointProject StartProject, oEditContext StartEContext)
		{
			this.zzzTheProject = StartProject;
			this.zzzTheEContext = StartEContext;
			this.TheEContext.EditStateChanged += new EventHandler(this.TheEContext_EditStateChanged);


			this.MainContainer = new GroupBox();
			this.MainContainer.Text = "Objet à ajouter";
			this.Height = 50;


			this.CancelButton = new CbButton2();
			this.CancelButton.Parent = this.MainContainer;
			this.CancelButton.Text = "×";
			this.CancelButton.Size = new Size(23, 23);
			this.CancelButton.Top = 18;
			this.CancelButton.Left = 3;
			this.CancelButton.Font = new Font("consolas", 20f);
			this.CancelButton.BackColor = Color.Crimson;
			this.CancelButton.ForeColor = Color.White;
			this.CancelButton.Click += new EventHandler(this.CancelButton_Click);


			//les button
			int bheight = this.Height - this.ButtonTop - 5;

			this.ButtonAddText = new CbButton2();
			this.ButtonAddText.Parent = this.MainContainer;
			this.ButtonAddText.Top = this.ButtonTop;
			this.ButtonAddText.Left = 30;
			this.ButtonAddText.Height = bheight;
			this.ButtonAddText.Text = "texte";
			this.ButtonAddText.Click += new EventHandler(this.ButtonAddText_Click);


			this.RefreshEnabled();
		}

		private void TheEContext_EditStateChanged(object sender, EventArgs e)
		{
			this.RefreshEnabled();
		}
		public void RefreshEnabled()
		{
			this.CancelButton.Visible = this.TheEContext.ActualEditState == oEditContext.EditState.Adding;

		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.TheEContext.CancelAddMode();
		}

		private void ButtonAddText_Click(object sender, EventArgs e)
		{
			oSlideControl newsc = new scLabel();
			this.TheEContext.SetToAddMode(newsc);
		}






	}
}
