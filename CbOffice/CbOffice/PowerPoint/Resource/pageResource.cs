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

namespace CbOffice.PowerPoint.Resource
{
	public partial class pageResource : Form, iPage
	{
		public PForm pParent;
		

		public pageResource()
		{
			InitializeComponent();

		}
		public void Initialize(PForm StartPParent)
		{
			this.pParent = StartPParent;

		}
		public void Start()
		{


		}
		public void Pause()
		{

		}
		public void Destroy()
		{

		}
		private void pageResource_Load(object sender, EventArgs e)
		{

		}





		private void BackButton_Click(object sender, EventArgs e)
		{
			this.pParent.GoBack();
		}




	}
}
