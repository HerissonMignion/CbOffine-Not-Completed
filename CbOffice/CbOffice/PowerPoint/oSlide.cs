using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CbOffice.PowerPoint.SlideControl;

namespace CbOffice.PowerPoint
{

	//un project power point est composé de "slide" qui comportent des objects sur eux

	public class oSlide
	{
		//rapport de la largeur sur la hauteur
		public float Rap
		{
			get { return this.Props.GetPropByName("rap").vFloat; }
			set { this.Props.GetPropByName("rap").vFloat = value; }
		}


		private ListProp Props = new ListProp();
		private void CreateProps()
		{
			this.Props.AddProp("rap", Prop.PropType.floatT, 1f);
			this.Props.AddProp("backcolor", Prop.PropType.colorT, Color.White);
		}

		#region ARRIERE PLAN
		public Color BackColor
		{
			get { return this.Props.GetPropByName("backcolor").vColor; }
			set { this.Props.GetPropByName("backcolor").vColor = value; }
		}





		#endregion

		#region slide control

		public List<oSlideControl> listControl = new List<oSlideControl>();
		public void AddControl(oSlideControl newc)
		{
			this.listControl.Add(newc);
		}
		public void RemoveControl(oSlideControl thec)
		{
			this.listControl.Remove(thec);
		}



		#endregion



		//void new()
		public oSlide()
		{
			this.CreateProps();
		}



	}
}
