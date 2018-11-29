using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PageEngine
{

	/*
	 * -les fenetre que PForm est concu pour contenir sont des object qui substituent Form et iPage. exemple : "public class PageDExemple : Form, iPage"
	 * 
	 * 
	 */




	//PForm = Page Form
	public class PForm
	{

		private Form forme;

		

		public enum PFormTitleMode
		{
			MainTitleOnly, //uniquement le titre de PForm
			PageTitleOnly, //uniquement le titre de la page
			MainAndPage //titre de PForm, chaine de separation, titre de la page
		}
		private PFormTitleMode zzzTitleMode = PFormTitleMode.MainAndPage;
		public PFormTitleMode TitleMode
		{
			get { return this.zzzTitleMode; }
			set { this.zzzTitleMode = value; this.RefreshTitle(); }
		}
		private string zzzTitle = "notitle"; //titre de PForm
		public string Title
		{
			get { return this.zzzTitle; }
			set { this.zzzTitle = value; this.RefreshTitle(); }
		}
		private string zzzSepTitle = " - "; //caractere de separation des titre
		public string SepTitle
		{
			get { return this.zzzSepTitle; }
			set
			{
				this.zzzSepTitle = value;
				if (this.zzzTitleMode == PFormTitleMode.MainAndPage) { this.RefreshTitle(); }
			}
		}
		private void RefreshTitle()
		{
			Form fActualPage = null;
			if (this.IsRunningAnyPage) { fActualPage = (Form)(this.listAllPage[this.ActualPageIndex]); }

			switch (this.TitleMode)
			{
				case PFormTitleMode.MainTitleOnly:
					this.forme.Text = this.Title;
					break;
				case PFormTitleMode.PageTitleOnly:
					if (this.IsRunningAnyPage)
					{
						this.forme.Text = fActualPage.Text;
					}
					else
					{
						this.forme.Text = "";
					}
					break;
				case PFormTitleMode.MainAndPage:
					if (this.IsRunningAnyPage && fActualPage.Text.Length > 0)
					{
						this.forme.Text = this.Title + this.SepTitle + fActualPage.Text;
					}
					else
					{
						this.forme.Text = this.Title;
					}
					break;
			}
		}
		
		public int Top
		{
			get { return this.forme.Top; }
			set { this.forme.Top = value; }
		}
		public int Left
		{
			get { return this.forme.Left; }
			set { this.forme.Left = value; }
		}
		public Point Location
		{
			get { return this.forme.Location; }
			set { this.forme.Location = value; }
		}
		public int Width
		{
			get { return this.forme.Width; }
			set { this.forme.Width = value; }
		}
		public int Height
		{
			get { return this.forme.Height; }
			set { this.forme.Height = value; }
		}
		public Size Size
		{
			get { return this.forme.Size; }
			set { this.forme.Size = value; }
		}
		public bool Visible { get { return this.forme.Visible; } }
		public Size MinimumSize
		{
			get { return this.forme.MinimumSize; }
			set { this.forme.MinimumSize = value; }
		}
		public Size MaximumSize
		{
			get { return this.forme.MaximumSize; }
			set { this.forme.MaximumSize = value; }
		}

		public FormBorderStyle FormBorderStyle
		{
			get { return this.forme.FormBorderStyle; }
			set { this.forme.FormBorderStyle = value; }
		}
		public FormWindowState WindowState
		{
			get { return this.forme.WindowState; }
			set { this.forme.WindowState = value; }
		}
		public bool MinimizeBox
		{
			get { return this.forme.MinimizeBox; }
			set { this.forme.MinimizeBox = value; }
		}
		public bool MaximizeBox
		{
			get { return this.forme.MaximizeBox; }
			set { this.forme.MaximizeBox = value; }
		}
		public bool ShowInTaskbar
		{
			get { return this.forme.ShowInTaskbar; }
			set { this.forme.ShowInTaskbar = value; }
		}
		public bool ShowIcon
		{
			get { return this.forme.ShowIcon; }
			set { this.forme.ShowIcon = value; }
		}
		public Icon Icon
		{
			get { return this.forme.Icon; }
			set { this.forme.Icon = value; }
		}
		public bool TopMost
		{
			get { return this.forme.TopMost; }
			set { this.forme.TopMost = value; }
		}





		#region public events
		public event EventHandler SizeChanged;
		private void Raise_SizeChanged(EventArgs e)
		{
			if (this.SizeChanged != null)
			{
				this.SizeChanged(this, e);
			}
		}
		public event EventHandler LocationChanged;
		private void Raise_LocationChanged(EventArgs e)
		{
			if (this.LocationChanged != null)
			{
				this.LocationChanged(this, e);
			}
		}


		#endregion


		public void Show()
		{
			this.forme.Show();
		}
		public void ShowDialog()
		{
			this.forme.ShowDialog();
		}
		public void Hide()
		{
			this.forme.Hide();
		}
		public void Close()
		{
			this.forme.Close();
		}
		


		//void new()
		public PForm()
		{
			this.forme = new Form();
			this.forme.Size = new Size(500, 500); //pour avoir une taille par default resonable
			this.forme.Text = "notitle"; //un titre par default
			this.forme.IsMdiContainer = true; //essentiel pour pouvoir contenir les autre formulaire

			this.forme.Load += new EventHandler(this.forme_Load);
			this.forme.SizeChanged += new EventHandler(this.forme_SizeChanged);
			this.forme.LocationChanged += new EventHandler(this.forme_LocationChanged);
			
		}
		private void forme_Load(object sender, EventArgs e)
		{
			this.RefreshTitle();
			this.RefreshPageVisibility();
		}
		private void forme_SizeChanged(object sender, EventArgs e)
		{
			this.RefreshActualPageSize();
			this.Raise_SizeChanged(e);
		}
		private void forme_LocationChanged(object sender, EventArgs e)
		{
			this.Raise_LocationChanged(e);
		}
		
		private void AnyPageForm_TextChanged(object sender, EventArgs e)
		{
			if (this.TitleMode != PFormTitleMode.MainTitleOnly)
			{
				this.RefreshTitle();
			}
		}




		#region PAGE
		private void RefreshActualPageSize()
		{
			if (this.IsRunningAnyPage)
			{
				Form fActualPage = (Form)(this.listAllPage[this.ActualPageIndex]);
				this.RefreshPageSize(fActualPage);

				//fActualPage.Location = new Point(0, 0);
				////fActualPage.Width = this.forme.Width - fActualPage.Left - 20;
				////fActualPage.Height = this.forme.Height - fActualPage.Top - 43;
				//fActualPage.Size = new Size(this.forme.Width - fActualPage.Left - 20, this.forme.Height - fActualPage.Top - 43);

			}
		}
		private void RefreshPageSize(iPage ThePage)
		{
			this.RefreshPageSize((Form)ThePage);
		}
		private void RefreshPageSize(Form TheForm)
		{
			TheForm.Location = new Point(0, 0);
			TheForm.Size = new Size(this.forme.Width - TheForm.Left - 20, this.forme.Height - TheForm.Top - 43);
		}


		private int ActualPageIndex = -1; //index, dans l'historique, de la page actuellement loader
		public bool IsRunningAnyPage
		{
			get
			{
				bool rep = false;
				if (this.ActualPageIndex >= 0) { rep = true; }
				return rep;
			}
		}
		private List<iPage> listAllPage = new List<iPage>(); //cette list est "l'historique" de tout les formulaire
		private int MinPageIndex { get { return 0; } }
		private int MaxPageIndex { get { return this.listAllPage.Count - 1; } }





		public void GoBack()
		{
			if (this.IsRunningAnyPage)
			{
				int PreviousIndex = this.ActualPageIndex - 1;

				//met en pause la page actuel
				this.PauseActualPage();

				//load l'index precedent
				if (PreviousIndex >= this.MinPageIndex)
				{
					this.ActivatePageAtIndex(PreviousIndex, false);
				}

				this.RefreshActualPageSize();
				this.RefreshTitle();
			}
		}
		public void GoForward()
		{
			if (this.CanGoForward)
			{
				int NextIndex = this.ActualPageIndex + 1;

				//met en pause la page actuel
				this.PauseActualPage();

				//load l'index suivant
				this.ActivatePageAtIndex(NextIndex, false);

				this.RefreshActualPageSize();
				this.RefreshTitle();
			}
		}
		public bool CanGoForward
		{
			get
			{
				bool rep = false;
				if (this.ActualPageIndex < this.MaxPageIndex) { rep = true; }
				return rep;
			}
		}

		public void Navigate(iPage NextPage)
		{
			int saveActualPageIndex = this.ActualPageIndex; //effectue une save parce qu'il va surement changer

			//s'il y a deja une page en execution, il va la mettre en pause
			if (this.IsRunningAnyPage)
			{
				this.PauseActualPage();
			}

			//s'il y a des page qui suive l'index actuel, il les delete
			if (this.MaxPageIndex > saveActualPageIndex)
			{
				this.RemoveAllPageAfterIndex(saveActualPageIndex);
			}

			//ajoute la prochaine page
			this.listAllPage.Add(NextPage);
			Form fNextPage = (Form)NextPage;
			fNextPage.MdiParent = this.forme;
			fNextPage.StartPosition = FormStartPosition.Manual;
			//this.ActualPageIndex = this.listAllPage.IndexOf(NextPage);
			NextPage.Initialize(this);
			this.ActivatePageAtIndex(this.listAllPage.Count - 1); //NextPage est actuellement a la fin de la liste

			fNextPage.TextChanged += new EventHandler(this.AnyPageForm_TextChanged);

			

			this.RefreshActualPageSize();
			this.RefreshTitle();
		}

		//ces void servent a la gestion des page
		private void PauseActualPage()
		{
			if (this.IsRunningAnyPage)
			{
				iPage ActualPage = this.listAllPage[this.ActualPageIndex];
				ActualPage.Pause();
				this.ActualPageIndex = -1;
				Form fActualPage = (Form)ActualPage;
				//make sure qu'elle a la bonne visibiliter
				if (fActualPage.Visible) { fActualPage.Hide(); }
			}
		}
		private void ActivatePageAtIndex(int IndexToActivate, bool IgnoreAlreadyActivatedPage = false)
		{
			//met en pause la page actuellement executer s'il y en a une
			if (!IgnoreAlreadyActivatedPage)
			{
				if (this.IsRunningAnyPage)
				{
					this.PauseActualPage();
				}
			}

			//active l'index en question s'il existe
			if (IndexToActivate >= this.MinPageIndex && IndexToActivate <= this.MaxPageIndex)
			{
				iPage ActualPage = this.listAllPage[IndexToActivate];
				Form fActualPage = (Form)ActualPage;
				this.ActualPageIndex = IndexToActivate;
				ActualPage.Start();
				//make sure que les bordure sont les bonne
				if (fActualPage.FormBorderStyle != FormBorderStyle.None) { fActualPage.FormBorderStyle = FormBorderStyle.None; }
				//make sure qu'elle a la bonne visibiliter
				if (!fActualPage.Visible) { fActualPage.Show(); }
			}
			
		}

		//delete toute les page qui se trouve APRES EndIndex
		private void RemoveAllPageAfterIndex(int EndIndex)
		{
			while (this.MaxPageIndex > EndIndex)
			{
				iPage ActualPage = this.listAllPage[this.listAllPage.Count - 1];
				Form fActualPage = (Form)ActualPage;
				fActualPage.TextChanged -= new EventHandler(this.AnyPageForm_TextChanged);
				ActualPage.Destroy();

				this.listAllPage.RemoveAt(this.listAllPage.Count - 1);
			}
			GC.Collect(); //pour debarasser la memoire des page deleter
		}

		//make sure qu'il n'y a QUE la page en cour qui est visible et qu'elle a la bonne position
		private void RefreshPageVisibility()
		{
			if (this.IsRunningAnyPage)
			{
				for (int TheIndex = 0; TheIndex <= this.listAllPage.Count - 1; TheIndex++)
				{
					iPage p = this.listAllPage[TheIndex];
					Form fp = (Form)p;
					if (TheIndex == this.ActualPageIndex)
					{
						if (!fp.Visible)
						{
							fp.Show();
							this.RefreshPageSize(fp);
						}
					}
					else
					{
						if (fp.Visible)
						{
							fp.Hide();
						}
					}
				}
			}
		}



		#endregion




	}
}
