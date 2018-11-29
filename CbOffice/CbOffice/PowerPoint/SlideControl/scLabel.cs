using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CbOffice.PowerPoint;

namespace CbOffice.PowerPoint.SlideControl
{
	public class scLabel : oSlideControl
	{


		//public string Text = "no text";
		//public Font Font = new Font("calibri", 20f); //la taille inscrit ici n'as pas d'importance
		//public float FontHeight = 0.03f; //% de la hauteur

		public string Text
		{
			get { return this.Props.GetPropByName("text").vStr; }
			set { this.Props.GetPropByName("text").vStr = value; }
		}
		public string FontName
		{
			get { return this.Props.GetPropByName("fontname").vStr; }
			set { this.Props.GetPropByName("fontname").vStr = value; }
		}
		public float FontHeight
		{
			get { return this.Props.GetPropByName("fontheight").vFloat; }
			set { this.Props.GetPropByName("fontheight").vFloat = value; }
		}
		public Color ForeColor
		{
			get { return this.Props.GetPropByName("forecolor").vColor; }
			set { this.Props.GetPropByName("forecolor").vColor = value; }
		}


		//void new()
		public scLabel()
		{
			this.zzzTheType = scType.Label;
			this.CreateBasicProps();

			this.Props.AddProp("text", Prop.PropType.strT, "no text");
			this.Props.AddProp("fontname", Prop.PropType.strT, "calibri");
			this.Props.AddProp("fontheight", Prop.PropType.floatT, 0.03f);
			this.Props.AddProp("forecolor", Prop.PropType.colorT, Color.Black);


		}





	}
}
