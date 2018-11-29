using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CbOffice.PowerPoint;

namespace CbOffice.PowerPoint.SlideControl
{

	public enum scType
	{
		none,
		Label,
		TextBlock,
		Image
	}



	// éléments qui se trouve à l'intérieure des slide

	public abstract class oSlideControl
	{
		protected scType zzzTheType = scType.none;
		public scType TheType
		{
			get { return this.zzzTheType; }
		}


		private oSlide zzzParent = null;
		public bool HasParent
		{
			get
			{
				return this.zzzParent != null;
			}
		}
		public oSlide Parent
		{
			get
			{
				return this.zzzParent;
			}
			set
			{
				this.RemoveFromParent();
				if (value != null)
				{
					this.zzzParent = value;
					value.AddControl(this);
				}
			}
		}
		
		public void RemoveFromParent()
		{
			if (this.HasParent)
			{
				this.Parent.RemoveControl(this);
				this.zzzParent = null;
			}
		}




		//toutes ces mesure sont en % (entre 0 et 1) de la taille de la slide
		//public float Top = 0f;
		//public float Left = 0f;
		//public float Width = 0.25f;
		//public float Height = 0.1f;
		public float Top
		{
			get { return this.Props.GetPropByName("top").vFloat; }
			set { this.Props.GetPropByName("top").vFloat = value; }
		}
		public float Left
		{
			get { return this.Props.GetPropByName("left").vFloat; }
			set { this.Props.GetPropByName("left").vFloat = value; }
		}
		public float Width
		{
			get { return this.Props.GetPropByName("width").vFloat; }
			set { this.Props.GetPropByName("width").vFloat = value; }
		}
		public float Height
		{
			get { return this.Props.GetPropByName("height").vFloat; }
			set { this.Props.GetPropByName("height").vFloat = value; }
		}


		protected ListProp Props = new ListProp();
		protected void CreateBasicProps()
		{
			this.Props.AddProp("top", Prop.PropType.floatT, 0f);
			this.Props.AddProp("left", Prop.PropType.floatT, 0f);
			this.Props.AddProp("width", Prop.PropType.floatT, 0.25f);
			this.Props.AddProp("height", Prop.PropType.floatT, 0.1f);
		}






	}
}
