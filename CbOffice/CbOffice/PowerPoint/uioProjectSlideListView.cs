using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CbOffice.PowerPoint
{

	// affichage à l'utilisateur une liste de tout les slide du project. il donne aussi à l'utilisateur des option de gestion avec le click-droit

	public class uioProjectSlideListView
	{
		public Point MousePos { get { return this.ImageBox.PointToClient(Cursor.Position); } }
		public Rectangle MouseRec { get { return new Rectangle(this.MousePos, new Size(1, 1)); } }
		//position dans la liste
		public Rectangle vMouseRec
		{
			get
			{
				Rectangle rep = this.MouseRec;
				rep.Y += this.ActualScrollY;
				return rep;
			}
		}

		private bool isMouseLeftDown = false;


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
		public uioProjectSlideListView(oPowerPointProject StartProject, oEditContext StartEContext)
		{
			this.zzzTheProject = StartProject;
			this.zzzTheEContext = StartEContext;
			this.TheProject.SlideAdded += new EventHandler(this.TheProject_SlideAdded);
			this.TheProject.SlideRemoved += new EventHandler(this.TheProject_SlideRemoved);
			this.TheEContext.EditingSlideChanged += new EventHandler(this.TheEContext_EditingSlideChanged);

			this.ImageBox = new PictureBox();
			this.ImageBox.BorderStyle = BorderStyle.FixedSingle;
			this.ImageBox.BackColor = Color.LightGray; // Gainsboro
			this.ImageBox.SizeChanged += new EventHandler(this.ImageBox_SizeChanged);
			this.ImageBox.MouseWheel += new MouseEventHandler(this.ImageBox_MouseWheel);
			this.ImageBox.MouseDown += new MouseEventHandler(this.ImageBox_MouseDown);
			this.ImageBox.MouseUp += new MouseEventHandler(this.ImageBox_MouseUp);
			this.ImageBox.MouseMove += new MouseEventHandler(this.ImageBox_MouseMove);
			this.ImageBox.MouseLeave += new EventHandler(this.ImageBox_MouseLeave);


			//end
			this.CreateScroll();

			this.RefreshAddButton();
		}
		private void ImageBox_SizeChanged(object sender, EventArgs e)
		{
			this.CheckScroll();
			this.ResizeScroll();

			this.RefreshImage();
		}
		private void ImageBox_MouseWheel(object sender, MouseEventArgs e)
		{
			int scrolldelta = (e.Delta / 119) * 30;
			this.ActualScrollY -= scrolldelta;
			this.CheckScroll();
			this.ResizeScroll();
			this.RefreshImage();
		}
		private void ImageBox_MouseDown(object sender, MouseEventArgs e)
		{
			Rectangle mrec = this.MouseRec;
			Rectangle vmrec = this.vMouseRec;
			if (e.Button == MouseButtons.Left)
			{
				this.isMouseLeftDown = true;

				//si la sourie est sur un button
				if (this.IsMouseOnAnyControl())
				{
					this.Button_ExecMouseDown();

				} //addbutton qui cree une nouvelle slide
				else if (this.recAddButton.IntersectsWith(vmrec))
				{
					oSlide news = new oSlide();
					this.TheProject.AddSlide(news);

				}
				else
				{
					//check si le click est fait dans la zone de la scroll bar
					if (mrec.X < this.Width - this.uiScrollZoneWidth)
					{
						//Program.wdebug("Click On Thumb");
						int mouseindex = this.GetIndexOfMouse();
						if (mouseindex != -1)
						{
							this.TheEContext.SetEditingSlide(mouseindex);


						}

					}
					else
					{

						if (this.recScrollBarRec.IntersectsWith(this.MouseRec))
						{
							int my = this.MousePos.Y;
							int delta = my - this.recScrollBarRec.Y - 1;
							this.AutoScrollMouseBarDelta = delta;

						}
						else
						{
							this.AutoScrollMouseBarDelta = this.recScrollBarRec.Height / 2;
						}
						this.Exec_MouseClickScroll();
						this.StartAutoScroll(ScrollDir.mouse);
					}
				}


			}
			if (e.Button == MouseButtons.Right)
			{
				int mouseindex = this.GetIndexOfMouse();
				if (mouseindex != -1)
				{
					string optDelete = "Supprimer";

					string optMoveUp = "Move up";
					string optMoveDown = "Move down";
					string optMoveTo = "Move to ...";


					oRightClick2 rc = new oRightClick2();
					if (this.TheProject.listSlide.Count > 1)
					{
						rc.AddSeparator();
						rc.AddChoice(optDelete);
					}
					rc.AddSeparator();

					if (mouseindex > 0)
					{
						rc.AddChoice(optMoveUp);
					}
					if (mouseindex < this.TheProject.listSlide.Count - 1)
					{
						rc.AddChoice(optMoveDown);
					}
					if (this.TheProject.listSlide.Count > 3)
					{
						rc.AddChoice(optMoveTo);
					}


					////execution du choix
					string rep = rc.GetChoice();




				}
				
			}
			this.RefreshImage();
		}
		private void ImageBox_MouseUp(object sender, MouseEventArgs e)
		{
			Rectangle mrec = this.MouseRec;
			if (e.Button == MouseButtons.Left)
			{
				this.isMouseLeftDown = false;
				this.Button_GeneralMouseUp();
			}

			//si c'etait la sourie que l'autoscroll suivait
			this.ScrollTimer.Stop();

			this.RefreshImage();
		}
		private int ImageBox_MouseMove_FrameSkip = 0; //compte actuel
		private int ImageBox_MouseMove_FrameSkip_Bound = 3; //à combien de frame il faut executer mousemove
		private void ImageBox_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.ImageBox_MouseMove_FrameSkip >= this.ImageBox_MouseMove_FrameSkip_Bound)
			{



				//end
				this.RefreshImage();
				this.ImageBox_MouseMove_FrameSkip = 0;
			}
			this.ImageBox_MouseMove_FrameSkip++;
		}
		private void ImageBox_MouseLeave(object sender, EventArgs e)
		{
			this.RefreshImage();
		}
		
		private void TheProject_SlideAdded(object sender, EventArgs e)
		{

			this.RefreshAddButton();
			this.ResizeScroll();
			this.RefreshImage();
		}
		private void TheProject_SlideRemoved(object sender, EventArgs e)
		{

			this.RefreshAddButton();
			this.ResizeScroll();
			this.RefreshImage();
		}

		private void TheEContext_EditingSlideChanged(object sender, EventArgs e)
		{
			this.RefreshImage();

		}





		//:///////// quelque parametre graphique
		private int uiItemHeight = 130; // 100 hauteur complete de tout les item
		private Font uiItemFont = new Font("consolas", 10);



		
		#region Scrolling
		private int ActualScrollY = 0;
		private int MinScrollY { get { return 0; } }
		private int MaxScrollY
		{
			get
			{
				int rep = this.TheProject.listSlide.Count * this.uiItemHeight;
				rep -= this.Height;
				rep += 150; // += 100
				if (rep < this.MinScrollY) { rep = this.MinScrollY; }
				return rep;
			}
		}

		private void CheckScroll()
		{
			if (this.ActualScrollY < this.MinScrollY) { this.ActualScrollY = this.MinScrollY; }
			if (this.ActualScrollY > this.MaxScrollY) { this.ActualScrollY = this.MaxScrollY; }
		}
		private void ScrollUp(int length = 20)
		{
			this.ActualScrollY -= length;
			if (this.ActualScrollY < this.MinScrollY) { this.ActualScrollY = this.MinScrollY; }
			this.ResizeScroll();
		}
		private void ScrollDown(int length = 20)
		{
			this.ActualScrollY += length;
			if (this.ActualScrollY > this.MaxScrollY) { this.ActualScrollY = this.MaxScrollY; }
			this.ResizeScroll();
		}
		
		//optien l'item qui est actuellement en haut de la zone graphique
		private int GetIndexOfTopItem()
		{
			int rep = (int)((double)(this.ActualScrollY) / (double)(this.uiItemHeight));
			return rep;
		}
		private int GetUiPosYOfItem(int index)
		{
			return (index * this.uiItemHeight) - this.ActualScrollY;
		}


		//obtien l'index qui se situe juste en dessous de la souris
		private int GetIndexOfMouse()
		{
			int rep = 0;

			Point mpos = this.MousePos;
			//check élémentaire
			if (mpos.X > this.Width - this.uiScrollZoneWidth) { return -1; }

			//calcul
			int ActualIndex = 0;
			int ActualVMY = mpos.Y + this.ActualScrollY; //this.vMouseRec.Y;
			while (ActualVMY > this.uiItemHeight)
			{
				//TopIndexDownY += this.uiItemHeight;
				ActualVMY -= this.uiItemHeight;
				ActualIndex++;
			}
			rep = ActualIndex;

			//check élémentaire
			if (rep > this.TheProject.listSlide.Count - 1) { return -1; }
			if (rep < 0) { return -1; }

			return rep;
		}


		//graphique
		private int uiScrollZoneWidth = 26; // 26
		private Rectangle recScrollZoneRec = new Rectangle(0, 0, 10, 10);
		private Rectangle recScrollBarRec = new Rectangle(0, 0, 10, 10);

		

		private void ResizeScroll()
		{

			int buttonwidth = this.uiScrollZoneWidth - 4;
			int buttonheight = 28; // 28


			this.btnScrollUp.Width = buttonwidth;
			this.btnScrollUp.Height = buttonheight;
			this.btnScrollUp.Top = 1;
			this.btnScrollUp.Left = this.Width - 3 - buttonwidth;
			this.btnScrollUp.Text = "/\\";

			this.btnScrollDown.Top = this.btnScrollUp.Top + this.btnScrollUp.Height + 1;
			this.btnScrollDown.Left = this.btnScrollUp.Left;
			this.btnScrollDown.Width = buttonwidth;
			this.btnScrollDown.Height = buttonheight;
			this.btnScrollDown.Text = "\\/";

			//////// refresh les rectangle du scrolling
			this.recScrollZoneRec.X = this.btnScrollDown.Left;
			this.recScrollZoneRec.Y = this.btnScrollDown.Top + this.btnScrollDown.Height + 1;
			this.recScrollZoneRec.Width = buttonwidth;
			this.recScrollZoneRec.Height = this.Height - 3 - this.recScrollZoneRec.Y;



			int ZoneHeight = this.recScrollZoneRec.Height - 4;

			int ScreenHeight = this.Height;
			int TotalHeight = this.MaxScrollY + ScreenHeight; //nombre de pixel total de la zone de scroll

			//calcul le height de la bar avec un seuil minimum
			int BarHeight = ZoneHeight * ScreenHeight / TotalHeight;
			if (BarHeight < 25) { BarHeight = 25; }
			if (BarHeight > ZoneHeight) { BarHeight = ZoneHeight; }

			int MaxY = ZoneHeight - BarHeight;
			int BarY = 0;
			if (this.MaxScrollY > 0)
			{
				BarY = MaxY * this.ActualScrollY / this.MaxScrollY;
			}


			if (BarY > MaxY) { BarY = MaxY; }
			if (BarY < 0) { BarY = 0; }

			this.recScrollBarRec.Width = buttonwidth - 4;
			this.recScrollBarRec.Height = BarHeight;
			this.recScrollBarRec.X = this.recScrollZoneRec.X + 2;
			this.recScrollBarRec.Y = this.recScrollZoneRec.Y + 2 + BarY;


		}
		private void CreateScroll()
		{
			this.btnScrollUp = new uiButton(this);
			this.btnScrollUp.MouseDown += new EventHandler(this.btnScrollUp_Down);
			this.btnScrollUp.MouseUp += new EventHandler(this.btnScrollUp_Up);
			this.btnScrollUp.Font = new Font("lucida console", 10f);

			this.btnScrollDown = new uiButton(this);
			this.btnScrollDown.MouseDown += new EventHandler(this.btnScrollDown_Down);
			this.btnScrollDown.MouseUp += new EventHandler(this.btnScrollDown_Up);
			this.btnScrollDown.Font = new Font("lucida console", 10f);



			this.ScrollTimer = new Timer();
			//this.ScrollTimer.Interval = 1000;
			this.ScrollTimer.Tick += new EventHandler(this.ScrollTimer_Tick);



		}

		private uiButton btnScrollUp;
		private uiButton btnScrollDown;

		private int ButtonScrollLength = 30;

		private void btnScrollUp_Down(object sender, EventArgs e)
		{
			//Program.wdebug("UP down");
			this.ScrollUp(this.ButtonScrollLength);
			this.StartAutoScroll(ScrollDir.up);
		}
		private void btnScrollUp_Up(object sender, EventArgs e)
		{
			this.StopAutoScroll();
		}
		private void btnScrollDown_Down(object sender, EventArgs e)
		{
			//Program.wdebug("DOWN down");
			this.ScrollDown(this.ButtonScrollLength);
			this.StartAutoScroll(ScrollDir.down);
		}
		private void btnScrollDown_Up(object sender, EventArgs e)
		{
			this.StopAutoScroll();
		}


		private void Exec_MouseClickScroll()
		{
			int BarHeight = this.recScrollBarRec.Height;
			int clicky = this.MousePos.Y - this.recScrollZoneRec.Y - 2 - this.AutoScrollMouseBarDelta; //  - (BarHeight / 2)

			int ZoneHeight = this.recScrollZoneRec.Height - 4;
			int ScreenHeight = this.Height;
			int TotalHeight = this.MaxScrollY + ScreenHeight; //nombre de pixel total de la zone de scroll

			int MaxY = ZoneHeight - BarHeight;

			//check de base
			if (clicky < 0) { this.ActualScrollY = 0; }
			else if (clicky > MaxY) { this.ActualScrollY = this.MaxScrollY; }
			else
			{
				if (this.MaxScrollY > this.MinScrollY)
				{
					int newscrolly = clicky * this.MaxScrollY / MaxY;
					//Program.wdebug(newscrolly);
					this.ActualScrollY = newscrolly;
				}
			}


			
			this.ResizeScroll();
		}

		private enum ScrollDir
		{
			none,

			up,
			down,
			mouse
		}
		private ScrollDir ActualScrollDir = ScrollDir.none;
		private void StartAutoScroll(ScrollDir TheDir)
		{
			this.ActualScrollDir = TheDir;
			this.ScrollTimer.Interval = 500; // 750
			if (TheDir == ScrollDir.mouse) { this.ScrollTimer.Interval = 30; }
			this.ScrollTimer.Start();
		}
		private void StopAutoScroll()
		{
			this.ScrollTimer.Stop();
			this.ActualScrollDir = ScrollDir.none;
		}
		private int AutoScrollMouseBarDelta = 0;

		private Timer ScrollTimer;
		private void ScrollTimer_Tick(object sender, EventArgs e)
		{
			this.ScrollTimer.Interval = 30;

			if (this.ActualScrollDir == ScrollDir.up)
			{
				this.ScrollUp((int)((double)this.ButtonScrollLength / 1));
			}
			if (this.ActualScrollDir == ScrollDir.down)
			{
				this.ScrollDown((int)((double)this.ButtonScrollLength / 1));
			}
			if (this.ActualScrollDir == ScrollDir.mouse)
			{
				this.Exec_MouseClickScroll();
			}

			this.RefreshImage();
		}

		#endregion



		private Rectangle recAddButton = new Rectangle(0, 0, 50, 50); //la taille est conservé
		private void RefreshAddButton()
		{
			this.recAddButton.Y = this.TheProject.listSlide.Count * this.uiItemHeight + 5;
			this.recAddButton.X = 40;
		}






		public void RefreshImage()
		{
			int imgWidth = this.Width;
			int imgHeight = this.Height;
			if (imgWidth < 50) { imgWidth = 50; }
			if (imgHeight < 100) { imgHeight = 100; }
			Bitmap img = new Bitmap(imgWidth, imgHeight);

			using (Graphics g = Graphics.FromImage(img))
			{
				g.Clear(this.BackColor);
				
				if (this.TheProject.listSlide.Count > 0)
				{

					int ActualIndex = this.GetIndexOfTopItem();
					int actualY = this.GetUiPosYOfItem(ActualIndex);

					//largeur et hauteur maximale que peuvent avoir les thumbnail
					int ThumbnailMaxHeight = this.uiItemHeight - 6;
					int ThumbnailMaxWidth = imgWidth - 3 - this.uiScrollZoneWidth - 40;
					RapRect ThumbnailRect = new RapRect(); //ceci sert à calculer la taille graphique maximale de chaque thumbnail celon leur rapport et l'espace disponible
					oSlideDrawer sd = new oSlideDrawer(); //sert à obtenir les thumbnail

					////dessin de l'image
					while (ActualIndex <= this.TheProject.listSlide.Count - 1 && actualY < imgHeight)
					{

						Rectangle recFullBack = new Rectangle(0, actualY, 1, 1);
						recFullBack.Width = imgWidth - 3 - this.uiScrollZoneWidth;
						recFullBack.Height = this.uiItemHeight;
						g.DrawRectangle(Pens.Black, recFullBack);

						////index
						string strIndex = ActualIndex.ToString().PadLeft(3);
						SizeF strIndexSize = g.MeasureString(strIndex, this.uiItemFont);
						float TextY = (float)(recFullBack.Y + (recFullBack.Height / 2) - (strIndexSize.Height / 2));

						//si c'est l'index "en cour d'édition", alors il met le backcolor du text en bleu
						if (ActualIndex == this.TheEContext.UserEditingSlide)
						{
							g.FillRectangle(Brushes.SkyBlue, 1, (int)TextY, strIndexSize.Width, strIndexSize.Height);
						}
						g.DrawString(strIndex, this.uiItemFont, Brushes.Black, 1f, TextY);


						////thumbnail
						//obtien la taille graphique de la thumbnail
						ThumbnailRect.rap = this.TheProject.listSlide[ActualIndex].Rap;
						ThumbnailRect.SetToMaxSize(ThumbnailMaxWidth, ThumbnailMaxHeight); //cette void met le rectangle à la taille maximale

						//position up-left du rectangle
						int uirectY = actualY + ((this.uiItemHeight / 2) - (ThumbnailRect.Height / 2));
						int uirectX = imgWidth - 7 - this.uiScrollZoneWidth - (ThumbnailMaxWidth / 2) - (ThumbnailRect.Width / 2);

						//dessine la thumb
						Bitmap thumbimg = sd.GetThumbnailImage(this.TheProject.listSlide[ActualIndex], ThumbnailRect.Height);
						g.DrawImage(thumbimg, uirectX, uirectY);
						thumbimg.Dispose();

						//dessine le rectangle noir qui l'entoure
						g.DrawRectangle(Pens.Black, uirectX, uirectY, ThumbnailRect.Width, ThumbnailRect.Height);




						//next iteration
						ActualIndex++;
						actualY += this.uiItemHeight;

					}





				}


				//add button
				int addbuttonY = this.recAddButton.Y - this.ActualScrollY;
				if (addbuttonY < imgHeight)
				{
					this.recAddButton.Y -= this.ActualScrollY;
					g.DrawRectangle(Pens.Black, this.recAddButton);
					string addbtext = "+";
					Font addbfont = new Font("consolas", 40);
					Point textpos = module.GetCenteredTextPos(addbtext, addbfont, g, this.recAddButton);
					g.DrawString(addbtext, addbfont, Brushes.Black, (float)(textpos.X), (float)(textpos.Y));
					this.recAddButton.Y += this.ActualScrollY;
				}




				//======================= UI CONTROL =====================
				Rectangle mrec = this.MouseRec;
				//button
				foreach (uiButton b in this.listAllButton)
				{
					Brush BackBrush = Brushes.Silver;
					Pen BorderPen = Pens.DimGray;
					//set les bon BackBrush et borderpen
					if (b.rec.IntersectsWith(mrec))
					{
						BackBrush = Brushes.Gainsboro;
						BorderPen = Pens.Black;
					}
					if (b.IsMouseLeftDown)
					{
						BackBrush = Brushes.DarkGray;
						BorderPen = Pens.Black;
					}
					g.FillRectangle(BackBrush, b.rec);
					g.DrawRectangle(BorderPen, b.Left, b.Top, b.Width - 1, b.Height - 1);

					Point TextPos = module.GetCenteredTextPos(b.Text, b.Font, b.rec);
					g.DrawString(b.Text, b.Font, Brushes.Black, (PointF)TextPos);
					
				}


				//================ dessine la zone de scrolling
				g.FillRectangle(Brushes.Gainsboro, this.recScrollZoneRec);
				Pen ScrollBorderPen = Pens.DimGray;
				if (this.recScrollZoneRec.IntersectsWith(mrec)) { ScrollBorderPen = Pens.Black; }
				g.DrawRectangle(ScrollBorderPen, this.recScrollZoneRec.X, this.recScrollZoneRec.Y, this.recScrollZoneRec.Width - 1, this.recScrollZoneRec.Height - 1);

				Brush BarBrush = Brushes.DimGray;
				g.FillRectangle(BarBrush, this.recScrollBarRec);


			}
			if (this.ImageBox.Image != null) { this.ImageBox.Image.Dispose(); }
			this.ImageBox.Image = img;
			GC.Collect();
		}

		//cette classe existe aussi dans uioProjectSlideEditer
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





		//========================== UI CONTROLS
		private bool IsMouseOnAnyControl()
		{
			bool rep = false;
			Rectangle mrec = this.MouseRec;
			foreach (uiButton b in this.listAllButton)
			{
				if (b.rec.IntersectsWith(mrec) && b.Visible)
				{
					return true;
				}
			}

			return rep;
		}
		private void Button_ExecMouseDown()
		{
			Rectangle mrec = this.MouseRec;
			foreach (uiButton b in this.listAllButton)
			{
				if (b.rec.IntersectsWith(mrec) && b.Visible)
				{
					b.Exec_MouseDown();
					break;
				}
			}
		}
		private void Button_GeneralMouseUp()
		{
			foreach (uiButton b in this.listAllButton)
			{
				b.Exec_GeneralMouseUp();
			}
		}

		private List<uiButton> listAllButton = new List<uiButton>();

		private class uiButton
		{
			public Rectangle rec = new Rectangle(0, 0, 100, 50);
			public int Top
			{
				get { return this.rec.Y; }
				set { this.rec.Y = value; }
			}
			public int Left
			{
				get { return this.rec.X; }
				set { this.rec.X = value; }
			}
			public int Width
			{
				get { return this.rec.Width; }
				set { this.rec.Width = value; }
			}
			public int Height
			{
				get { return this.rec.Height; }
				set { this.rec.Height = value; }
			}
			public bool Visible = true;
			public Font Font = new Font("consolas", 13f);

			public string Text = "notext";


			//void new()
			public uiButton(uioProjectSlideListView StartParent)
			{
				StartParent.listAllButton.Add(this);
			}


			public event EventHandler MouseDown;
			public event EventHandler MouseUp;
			private void Raise_MouseDown()
			{
				if (this.MouseDown != null)
				{
					this.MouseDown(this, new EventArgs());
				}
			}
			private void Raise_MouseUp()
			{
				if (this.MouseUp != null)
				{
					this.MouseUp(this, new EventArgs());
				}
			}



			public bool IsMouseLeftDown = false;

			public void Exec_MouseDown()
			{
				this.IsMouseLeftDown = true;
				this.Raise_MouseDown();
			}
			public void Exec_GeneralMouseUp()
			{
				if (this.IsMouseLeftDown)
				{
					this.Raise_MouseUp();
					this.IsMouseLeftDown = false;
				}
				this.IsMouseLeftDown = false; //obligatoire à la fin de cette void
			}




		}

	}
}
