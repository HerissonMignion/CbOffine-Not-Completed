using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PageEngine;
using CbOffice.PowerPoint.Resource;

namespace CbOffice.PowerPoint
{
	public partial class pageProgPowerPoint : Form, iPage
	{
		public PForm pParent;
		private uioProjectSlideListView SlideViewer;
		private uioEditerObjectSelectPanel TheSelectPanel = null;
		private uioProjectSlideEditer TheSlideEditer = null;




		private bool IsFileOpened = false; //indique si un fichier est ouvert
		private bool IsEditSaved = false; //indique si les modification ont ete sauvgarder
		private oPowerPointProject TheProject = null;
		private oEditContext TheEContext = null;







		public pageProgPowerPoint()
		{
			this.voidnew();
		}
		public pageProgPowerPoint(string FilePath = "")
		{
			this.voidnew();
			//charge le fichier

		}
		private void voidnew()
		{
			InitializeComponent();
			this.EditorSplitContainer.SplitterWidth = 8;

			//cree un project vierge de base
			this.TheProject = new oPowerPointProject();
			//ajoute une slide par default
			oSlide slide1 = new oSlide();
			this.TheProject.listSlide.Add(slide1);



			//cree le edit context
			this.TheEContext = new oEditContext(this.TheProject);



			this.SlideViewer = new uioProjectSlideListView(this.TheProject, this.TheEContext);
			this.SlideViewer.Parent = this.MainSplitContainer.Panel1;

			this.TheSelectPanel = new uioEditerObjectSelectPanel(this.TheProject, this.TheEContext);
			this.TheSelectPanel.Parent = this.EditorSplitContainer.Panel1;
			this.TheSelectPanel.Location = new Point(1, 1);
			this.TheSelectPanel.Width = this.EditorSplitContainer.Panel1.Width - this.TheSelectPanel.Left - 10;
			this.TheSelectPanel.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;

			this.TheSlideEditer = new uioProjectSlideEditer(this.TheProject, this.TheEContext);
			this.TheSlideEditer.Parent = this.EditorSplitContainer.Panel1;
			this.TheSlideEditer.Top = this.TheSelectPanel.Top + this.TheSelectPanel.Height + 2;
			this.TheSlideEditer.Left = 0;
			this.TheSlideEditer.Width = this.EditorSplitContainer.Panel1.Width - this.TheSlideEditer.Left - 2;
			this.TheSlideEditer.Height = this.EditorSplitContainer.Panel1.Height - this.TheSlideEditer.Top - 2;
			this.TheSlideEditer.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
			this.TheSlideEditer.BackColor = Color.DimGray;


		}



		public void Initialize(PForm StartPParent)
		{
			this.pParent = StartPParent;

		}
		public void Start()
		{
			this.RefreshTitle();
			this.RefreshEnabled();
			this.pParent.Icon = CbOffice.Properties.Resources.icoPowerPoint;


		}
		public void Pause()
		{

		}
		public void Destroy()
		{

		}
		private void pageProgPowerPoint_Load(object sender, EventArgs e)
		{

			this.RefreshSize();
		}






		public void RefreshTitle()
		{
			this.pParent.TitleMode = PForm.PFormTitleMode.PageTitleOnly;
			this.Text = "CB Power Point";
			if (!this.IsFileOpened) { this.Text += " - *Non sauvgardé"; }

		}
		//call tout les refreshenabled
		public void RefreshEnabled()
		{
			this.menuRefreshEnabled();

		}
		public void RefreshSize()
		{
			this.SlideViewer.Top = this.buttonNewSlide.Top + this.buttonNewSlide.Height + 3;
			this.SlideViewer.Left = 0;
			this.SlideViewer.Width = this.MainSplitContainer.Panel1.Width - 2;
			this.SlideViewer.Height = this.MainSplitContainer.Panel1.Height - this.SlideViewer.Top - 2;
			this.SlideViewer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;


		}

		#region MENU BAR
		private void menuRefreshEnabled()
		{

		}

		private void ddbHome_Click(object sender, EventArgs e)
		{
			this.pParent.GoBack();
		}

		private void ddbNew_Click(object sender, EventArgs e)
		{

		}
		private void ddbOpen_Click(object sender, EventArgs e)
		{

		}
		private void ddbSave_Click(object sender, EventArgs e)
		{

		}
		private void ddbSaveAs_Click(object sender, EventArgs e)
		{

		}
		
		//======= RESOURCE ========

		private void ddbViewResources_Click(object sender, EventArgs e)
		{
			pageResource newp = new pageResource();
			this.pParent.Navigate(newp);
			

		}

		



		#endregion

		#region partie gauche pour la gestion des slide

		private void buttonNewSlide_Click(object sender, EventArgs e)
		{
			oSlide news = new oSlide();
			news.Rap = 2f;
			this.TheProject.AddSlide(news);
			//this.TheProject.listSlide.Add(news);
			//this.SlideViewer.RefreshImage();


		}








		#endregion

	}
}
