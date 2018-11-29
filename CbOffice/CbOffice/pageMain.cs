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

namespace CbOffice
{
	public partial class pageMain : Form, iPage
	{
		public PForm pParent;


		public pageMain()
		{
			InitializeComponent();
		}
		public void Initialize(PForm StartPParent)
		{
			this.pParent = StartPParent;

		}
		public void Start()
		{
			this.pParent.TitleMode = PForm.PFormTitleMode.MainAndPage;
			this.pParent.Icon = CbOffice.Properties.Resources.icoOffice;

		}
		public void Pause()
		{

		}
		public void Destroy()
		{

		}
		private void pageMain_Load(object sender, EventArgs e)
		{

		}

		private void buttonPowerPoint_Click(object sender, EventArgs e)
		{
			PowerPoint.pageProgPowerPoint newp = new PowerPoint.pageProgPowerPoint();
			this.pParent.Navigate(newp);

		}








	}
}
