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

	//ce control est supposé prendre beaucoup de place à l'ecran. c'est le principale éditeur grahique de slide

	public class uioProjectSlideEditer
	{
		public Point MousePos { get { return this.ImageBox.PointToClient(Cursor.Position); } }
		public Rectangle MouseRec { get { return new Rectangle(this.MousePos, new Size(1, 1)); } }


		private oPowerPointProject zzzTheProject;
		public oPowerPointProject TheProject { get { return this.zzzTheProject; } }
		private oEditContext zzzTheEContext;
		public oEditContext TheEContext { get { return this.zzzTheEContext; } }


		private PictureBox ImageBox;
		public Control Parent
		{
			get { return this.ImageBox.Parent; }
			set { this.ImageBox.Parent = value; }
		}
		public int Top
		{
			get { return this.ImageBox.Top; }
			set { this.ImageBox.Top = value; }
		}
		public int Left
		{
			get { return this.ImageBox.Left; }
			set { this.ImageBox.Left = value; }
		}
		public int Width
		{
			get { return this.ImageBox.Width; }
			set { this.ImageBox.Width = value; }
		}
		public int Height
		{
			get { return this.ImageBox.Height; }
			set { this.ImageBox.Height = value; }
		}
		public AnchorStyles Anchor
		{
			get { return this.ImageBox.Anchor; }
			set { this.ImageBox.Anchor = value; }
		}
		public Color BackColor
		{
			get { return this.ImageBox.BackColor; }
			set { this.ImageBox.BackColor = value; }
		}






		//void new()
		public uioProjectSlideEditer(oPowerPointProject StartProject, oEditContext StartEContext)
		{
			this.zzzTheProject = StartProject;
			this.zzzTheEContext = StartEContext;

			this.TheEContext.EditingSlideChanged += new EventHandler(this.TheEContext_EditingSlideChanged);
			this.TheEContext.EditStateChanged += new EventHandler(this.TheEContext_EditStateChanged);

			this.ImageBox = new PictureBox();
			this.ImageBox.BorderStyle = BorderStyle.FixedSingle;
			this.ImageBox.BackgroundImageLayout = ImageLayout.Center;
			this.ImageBox.SizeChanged += new EventHandler(this.ImageBox_SizeChanged);
			this.ImageBox.MouseMove += new MouseEventHandler(this.ImageBox_MouseMove);
			this.ImageBox.MouseDown += new MouseEventHandler(this.ImageBox_MouseDown);
			this.ImageBox.MouseUp += new MouseEventHandler(this.ImageBox_MouseUp);


			this.RefreshSize();
			this.RefreshImage();
		}
		private void ImageBox_SizeChanged(object sender, EventArgs e)
		{
			this.RefreshSize();
			this.RefreshImage();
		}
		private void ImageBox_MouseMove(object sender, MouseEventArgs e)
		{
			//si la souris bouge alors que l'utilisateur est en adding mode, alors il fait dessiner le truc "simpa", je sais pas comment le dire
			if (this.TheEContext.ActualEditState == oEditContext.EditState.Adding)
			{
				this.addmode_SimpaDraw();
			}


		}
		private void ImageBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (this.TheEContext.ActualEditState == oEditContext.EditState.none)
			{

			}
			else if (this.TheEContext.ActualEditState == oEditContext.EditState.Adding)
			{

				//dépose le nouveau control seulement si la souris est dans la slide
				if (this.IsMouseOnSlide)
				{
					PointF smpos = this.SlideMousePos;
					//défini la position du control
					oSlideControl newsc = this.TheEContext.addmodeNewSC;
					newsc.Top = smpos.Y;
					newsc.Left = smpos.X;

					//l'ajoute à la slide
					this.ActualSlide.AddControl(newsc);

					//termine l'addition
					this.TheEContext.FinishAddMode();
					
				}



			}
		}
		private void ImageBox_MouseUp(object sender, MouseEventArgs e)
		{

		}



		private void TheEContext_EditingSlideChanged(object sender, EventArgs e)
		{
			this.RefreshSize();
			this.RefreshImage();
		}
		private void TheEContext_EditStateChanged(object sender, EventArgs e)
		{
			this.RefreshImage();
			this.TrueRefresh();

		}



		private int ActualSlideId
		{
			get { return this.TheEContext.UserEditingSlide; }
		}
		private oSlide ActualSlide
		{
			get
			{
				return this.TheProject.listSlide[this.ActualSlideId];
			}
		}





		private class RapRect
		{
			public float rap = 1f; //rapport de la largeur sur la hauteur

			private int zzzWidth = 100;
			public int Width
			{
				get { return this.zzzWidth; }
			}
			private int zzzHeight = 100;
			public int Height
			{
				get { return this.zzzHeight; }
			}

			public void SetWidth(int newwidth)
			{
				this.zzzWidth = newwidth;
				this.zzzHeight = (int)((float)newwidth / this.rap + 0.5f);
			}
			public void SetHeight(int newheight)
			{
				this.zzzHeight = newheight;
				this.zzzWidth = (int)((float)newheight * this.rap + 0.5f);
			}
			public void SetToMaxSize(int MaxWidth, int MaxHeight)
			{
				float tr = (float)MaxWidth / (float)MaxHeight;

				if (tr > this.rap)
				{
					this.SetHeight(MaxHeight);
				}
				else
				{
					this.SetWidth(MaxWidth);
				}
				
			}
		}
		private RapRect SlideRect = new RapRect(); //taille graphique de la slide actuel
		private PointF SlideMousePos
		{
			get
			{
				PointF rep = new PointF(0f, 0f);
				Point mpos = this.MousePos;
				float mleft = (float)(mpos.X + 2) - (((float)this.Width / 2f) - ((float)this.SlideRect.Width / 2f));
				float mtop = (float)(mpos.Y + 2) - (((float)this.Height / 2f) - ((float)this.SlideRect.Height / 2f));

				rep.X = mleft / (float)this.SlideRect.Width;
				rep.Y = mtop / (float)this.SlideRect.Height;
				return rep;
			}
		}
		private bool IsMouseOnSlide
		{
			get
			{
				PointF smpos = this.SlideMousePos;
				if (smpos.X >= 0 && smpos.X <= 1)
				{
					if (smpos.Y >= 0 && smpos.Y <= 1)
					{
						return true;
					}
				}
				return false;
			}
		}
		private oSlideDrawer TheDrawer = new oSlideDrawer();



		private void RefreshSize()
		{
			this.SlideRect.rap = this.ActualSlide.Rap;
			this.SlideRect.SetToMaxSize(this.Width - 12, this.Height - 12);

		}
		public void RefreshImage()
		{

			int uiHeight = this.SlideRect.Height;
			if (uiHeight < 10) { uiHeight = 10; }
			Bitmap img = this.TheDrawer.GetImage(this.ActualSlide, uiHeight);



			if (this.ImageBox.BackgroundImage != null) { this.ImageBox.BackgroundImage.Dispose(); }
			this.ImageBox.BackgroundImage = img;

		}
		public void TrueRefresh()
		{
			this.ImageBox.Refresh();
		}





		#region adding mode
		//si la souris bouge alors que l'utilisateur est en adding mode, alors il faut dessiner un truc simpa
		private void addmode_SimpaDraw()
		{
			if (this.TheEContext.ActualEditState == oEditContext.EditState.Adding)
			{
				this.TrueRefresh();

				Graphics g = this.ImageBox.CreateGraphics();

				Point mpos = this.MousePos;
				g.DrawRectangle(Pens.Red, mpos.X, mpos.Y, (int)(this.TheEContext.addmodeNewSC.Width * (float)this.SlideRect.Width), (int)(this.TheEContext.addmodeNewSC.Height * (float)this.SlideRect.Height));


			}
		}



		#endregion




	}
}
