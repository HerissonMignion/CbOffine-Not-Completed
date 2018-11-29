using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CbOffice.PowerPoint
{

	public class Prop
	{
		public string Name = "noname";

		public enum PropType
		{
			strT,
			doubleT,
			floatT,
			colorT
		}
		public PropType pType;

		//valeur de la property
		public string vStr = "";
		public double vDouble = 0;
		public float vFloat = 0f;
		public Color vColor = Color.Black;

		public void SetValue(object newval)
		{
			if (this.pType == PropType.strT) { this.vStr = (string)newval; }
			if (this.pType == PropType.doubleT) { this.vDouble = (double)newval; }
			if (this.pType == PropType.floatT) { this.vFloat = (float)newval; }
			if (this.pType == PropType.colorT) { this.vColor = (Color)newval; }
		}
		public object GetValue()
		{
			if (this.pType == PropType.strT) { return this.vStr; }
			if (this.pType == PropType.doubleT) { return this.vDouble; }
			if (this.pType == PropType.floatT) { return this.vFloat; }
			if (this.pType == PropType.colorT) { return this.vColor; }
			return null;
		}

		//void new()
		public Prop(string StartName, PropType StartType)
		{
			this.Name = StartName;
			this.pType = StartType;
		}
	}



	public class ListProp
	{
		public List<Prop> AllProp = new List<Prop>();

		public void AddProp(Prop newprop)
		{
			this.AllProp.Add(newprop);
		}
		public void AddProp(string Name, Prop.PropType pType, object Value)
		{
			Prop newprop = new Prop(Name, pType);
			newprop.SetValue(Value);
			this.AllProp.Add(newprop);
		}

		public Prop GetPropByName(string propname)
		{
			foreach (Prop p in this.AllProp)
			{
				if (p.Name == propname) { return p; }
			}
			return null;
		}
		
		//void new()
		public ListProp()
		{

		}
		
	}
}
