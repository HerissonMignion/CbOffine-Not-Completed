using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CbOffice.PowerPoint.Resource;

namespace CbOffice.PowerPoint
{
	public class oPowerPointProject
	{



		#region slide
		public List<oSlide> listSlide = new List<oSlide>(); //contien toute les slide du project

		public void AddSlide(oSlide newSlide)
		{
			this.listSlide.Add(newSlide);
			this.Raise_SlideAdded();
		}
		public void RemoveSlide(oSlide oldSlide)
		{
			int lastcount = this.listSlide.Count;
			this.listSlide.Remove(oldSlide);
			if (this.listSlide.Count != lastcount)
			{
				this.Raise_SlideRemoved();
			}
		}
		public event EventHandler SlideAdded;
		public event EventHandler SlideRemoved;
		private void Raise_SlideAdded()
		{
			if (this.SlideAdded != null)
			{
				this.SlideAdded(this, new EventArgs());
			}
		}
		private void Raise_SlideRemoved()
		{
			if (this.SlideRemoved != null)
			{
				this.SlideRemoved(this, new EventArgs());
			}
		}

		#endregion


		#region resource
		public List<oResource> listResource = new List<oResource>();

		public void AddResource(oResource newr)
		{
			this.listResource.Add(newr);
			this.Raise_ResourceAdded();
		}
		public void RemoveResource(oResource oldr)
		{
			this.listResource.Remove(oldr);
			this.Raise_ResourceRemoved();
		}
		public event EventHandler ResourceAdded;
		public event EventHandler ResourceRemoved;
		private void Raise_ResourceAdded()
		{
			if (this.ResourceAdded != null)
			{
				this.ResourceAdded(this, new EventArgs());
			}
		}
		private void Raise_ResourceRemoved()
		{
			if (this.ResourceRemoved != null)
			{
				this.ResourceRemoved(this, new EventArgs());
			}
		}

		#endregion





		//void new()
		public oPowerPointProject()
		{



		}



	}
}
